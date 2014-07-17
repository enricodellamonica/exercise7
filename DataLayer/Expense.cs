using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public class Expense {
        public void SendToDb() 
        {
        using(var conn = Db.GetSqlConnection()) {
            using(var cmd = conn.CreateCommand()) {
                cmd.CommandText = @"Insert Into Expenses (Date,Product,Remark,Price,User_Id) values('{0}','{1}','{2}','{3}','{4}')";
                cmd.CommandText = string.Format(cmd.CommandText, Date, Product, Remark,
                    Price.ToString(CultureInfo.InvariantCulture), UserId.ToString(CultureInfo.InvariantCulture));
                 cmd.ExecuteNonQuery();
                

                }
            }
        }
        public string Date { get; set; }
        public string Product {
            get;
            set;
            }
        public string Remark {
            get;
            set;
            }
        public float Price {
            get;
            set;
            }
        public int UserId {
            get;
            set;
            }
        }
    }
