﻿using System;
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
using System.Windows.Shapes;
using System.Data;
using DataLayer;

namespace WpfEntity {
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window {
        FetchData fetch = new FetchData(Expense.Id);

        public Reports() {
            InitializeComponent();
            }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            
            DataGrid1.ItemsSource = fetch.dt.DefaultView;
            

        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            fetch.ExportToExcel();
            }
        }
    }
