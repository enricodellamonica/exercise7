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

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool CheckUserAuthetication(string box1, string box2)
        {
            try
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
                            Expense.Id = Int32.Parse(reader["Id"].ToString());
                            return true;
                        }
                    }
                }
            }
            catch (Exception exp)
            {

                return false;
            }
            return false;
        }

    }
}