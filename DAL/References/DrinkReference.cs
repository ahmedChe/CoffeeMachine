using BaverageApp;
using DataModel;
using Npgsql;
using System.Data;


namespace DAL.References
{
    public class DrinkReference
    {
        public void InsertChoice(Choice c,string username)
        {
            var sql = "INSERT INTO DRINK (DRINK,CLIENT,SUGAR,MUG) VALUES (@drink,(SELECT ID FROM CLIENT WHERE USERNAME=@username or EMAIL=@username),@sugar,@mug);";
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("drink", c.Drink);
                cmd.Parameters.AddWithValue("mug", c.Mug);
                cmd.Parameters.AddWithValue("sugar", c.Sugar);
                cmd.Parameters.AddWithValue("username", username);
                ConnectDb.ExecuteWithoutResult(cmd);
            }
        }
        public Choice ReturningUserChoice(string username)
        {
            var sql = "SELECT D.DRINK,D.SUGAR,D.MUG FROM DRINK D JOIN CLIENT C  ON (D.CLIENT=C.ID) WHERE (C.USERNAME=@username OR C.EMAIL=@username) ORDER BY D.ID DESC LIMIT 1";

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("username", username);


                using (var con = new NpgsqlConnection(ConnectDb.GetConnectionString()))
                {
                    cmd.Connection = con;
                    con.Open();                
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return null;
                        }
                        reader.Read();
                        return new Choice(reader.GetString(0), reader.GetInt32(1), reader.GetBoolean(2));
                    }
                }
            }
        }
    }
}
