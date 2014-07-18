using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public class Db {
        //public static int UserId { get; set; }
        public static string ConnectionString {
            get
            {
                var connStr= ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                var sb = new SqlConnectionStringBuilder(connStr);
                return sb.ToString();


            }
            }

        public static SqlConnection GetSqlConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
        }
    }
