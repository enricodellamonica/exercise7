using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataLayer;


namespace WpfEntity {
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window {
        public Login() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var users = new User(textbox1.Text,textbox2.Text);
            //label1.Content=users.UserName;

            var conn = Db.GetSqlConnection();
            var sda = new SqlDataAdapter("Select Count(*) From Users where UserName='" + textbox1.Text + "'And Password='" + textbox2.Text + "'", conn);
            var dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1") {

                Hide();
                var win = new MainWindow();
                win.Show();
                }
            else {
                MessageBox.Show("username or password is invalid");
                }
        }


        }
    }
