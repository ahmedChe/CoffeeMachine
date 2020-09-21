using DAL.Extensions;
using Npgsql;
using System;
using System.Data.SqlClient;

namespace DAL
{
    public class ConnectDb
    {
        private static readonly string cnx = "Host=localhost;Username=postgres;Password=amd;Database=Baverage";
        public static string GetConnectionString()
        {
            return cnx;
        }
        public static void ExecuteWithoutResult(NpgsqlCommand cmd)
        {
            using (var con = new NpgsqlConnection(cnx))
            {
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public static int ExecuteCheckRequest(NpgsqlCommand cmd)
        {
            using (var con = new NpgsqlConnection(cnx))
            {
                cmd.Connection = con;
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }
        public static object ReturningOneResult<T>(NpgsqlCommand cmd)
        {
            using (var con = new NpgsqlConnection(cnx))
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
                    return reader.CreateModel<T>();
                }
            }
        }
        

    }
}
