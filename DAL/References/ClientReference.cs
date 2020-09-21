using System.Data;
using DataModel;
using System.Data.SqlClient;
using Npgsql;

namespace DAL.References
{
    public class ClientReference
    {
        public void InsertUSer(Client c)
        {
            var sql = "INSERT INTO CLIENT(USERNAME, EMAIL,PASSWORD) VALUES(@pseudo, @email,@pwd)";
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("pseudo", c.USERNAME);
                cmd.Parameters.AddWithValue("email", c.EMAIL);
                cmd.Parameters.AddWithValue("pwd", c.PASSWORD);
                ConnectDb.ExecuteWithoutResult(cmd);
            }
        }
        public bool CheckExistingUser(string field,string user)
        {
            var sql = string.Format("SELECT Count(*) FROM CLIENT WHERE LOWER({0})=LOWER(@client)", field);
         
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("client", user);

                    return ConnectDb.ExecuteCheckRequest(cmd) == 0 ? false : true;

                }         
        }
        public bool CheckValidUser(string username, string password)
        {
            var sql = "SELECT Count(*) FROM CLIENT WHERE PASSWORD=@pwd and (LOWER(EMAIL)=LOWER(@client) or LOWER(USERNAME)=LOWER(@client)) ";
            
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("client", username);
                    cmd.Parameters.AddWithValue("pwd", password);

                    return ConnectDb.ExecuteCheckRequest(cmd) == 0 ? false : true;

            }
        }
    }
}
