using System.Windows;

//using MySql.Data.MySqlClient;

namespace SecondAttempt
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private int _count;

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            RadListBox.Items.Add($"Count is: {_count++}");
        }

        private void Connect_OnClick(object sender, RoutedEventArgs e)
        {
            var connectionString = "server = 127.0.0.1; user id = root; password = userx";
            //using (var mySQLConnecton = new MySqlConnection())
            //{
            //    if (mySQLConnecton.State == ConnectionState.Closed)
            //    {
            //        mySQLConnecton.Open();
            //    }

            //    RadListBox.Items.Add("Connected");
            //}
        }

        #endregion
    }
}