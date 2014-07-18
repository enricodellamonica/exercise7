using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer
{
    public class User
    {
        public bool Login = false;
        public static int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string box1, string box2)
        {
            using (var conn = Db.GetSqlConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Select * From Users where UserName='{0}' And Password='{1}'";
                    cmd.CommandText = string.Format(cmd.CommandText, box1, box2);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Id = Int32.Parse(reader["Id"].ToString());
                        Login = true;
                    }
                }
            }
        }
    }
}