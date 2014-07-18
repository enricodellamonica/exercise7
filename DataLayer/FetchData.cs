using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace DataLayer {
    public class FetchData
    {
        public DataTable dt { get; set; }
        public  FetchData(int userid)
        {
            using (var conn = Db.GetSqlConnection())
            {

                var query = @"Select Date,Product,Remark,Price From Expenses where User_Id='{0}'";
                var formatQuery = string.Format(query, userid.ToString(CultureInfo.InvariantCulture));
                var cmd = new SqlCommand(formatQuery, conn);
            
                cmd.ExecuteNonQuery();
            var adapter = new SqlDataAdapter(cmd);

            dt = new DataTable("Expenses");
                adapter.Fill(dt);
            }
            
        }
        }
    }
