using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using MySql.Data.MySqlClient;

namespace SecondAttempt
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _count;

        private MD5 _md5;

        internal const string Salt = "EDFD68E2-F74F-4FB0-B541-4572561F5FA7";

        public MainWindow()
        {
            InitializeComponent();

            _md5 = MD5.Create();
            var passwordHash = Convert.ToBase64String(_md5.ComputeHash(Encoding.UTF8.GetBytes("wasabionasmallplate" + Salt)));

            MessageBox.Show("passwordHash");

            _md5.

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            RadListBox.Items.Add($"Count is: {_count++}");
        }

        private void Connect_OnClick(object sender, RoutedEventArgs e)
        {
            var connectionString = "server = 127.0.0.1; user id = root; password = userx";
            using (var mySQLConnecton = new MySqlConnection())
            {
                if (mySQLConnecton.State == ConnectionState.Closed)
                {
                    mySQLConnecton.Open();
                }

                RadListBox.Items.Add("Connected");
            }
        }
    }
}