using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer {
 

    public class User {
        public User(string box1, string box2) {
            
            using(var conn = Db.GetSqlConnection()) {
                using(var cmd = conn.CreateCommand()) {
                    cmd.CommandText = @"Select * From Users where UserName='{0}' And Password='{1}'";
                    cmd.CommandText = string.Format(cmd.CommandText, box1.ToString(CultureInfo.InvariantCulture), box2.ToString(CultureInfo.InvariantCulture));
                    var reader = cmd.ExecuteReader();
                    if(reader.Read()) {
                        this.Fetch(reader);

                        }

                    }
                }
            
            }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void Fetch(SqlDataReader reader)
        {
            Id = Int32.Parse(reader["Id"].ToString());
            UserName = reader["UserName"].ToString();
            Password = (string) reader["Password"];
        }
        }
    }
