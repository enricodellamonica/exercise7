using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer;

namespace WpfEntity {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
            
            
        }



        private void Report_Click(object sender, RoutedEventArgs e) {
            Hide();
            var win = new Reports();
            win.Show();

            }

        private void Submit_Click(object sender, RoutedEventArgs e) {
            var exp = new Expense();
            exp.Date = BoxDay.Text;
            exp.Product = (string)Combo.SelectedItem;
            exp.Price = float.Parse(BoxPrice.Text);
            exp.Remark = BoxRemark.Text;
            exp.SendToDb();
        }

     

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var oi = OtherItem.Text;
            if(!Combo.Items.Contains(oi)) {
                Combo.Items.Add(oi);
                }
            

        }
        }
    }
