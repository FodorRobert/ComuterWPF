using MySqlConnector;
using System.Data;
using System.Windows;

namespace ComuterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListComputers();
        }

        public const string ConnectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";

        private void ListComputers()
        {
            try
            {
                
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM comp";

                    using (MySqlCommand cmdSel = new MySqlCommand(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                        da.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;
                    }

                    connection.Close();

                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ListOs()
        {
            try
            {

                using (var connection = new MySqlConnection(ConnectionString))

                {
                    connection.Open();
                    string sql = "SELECT * FROM osystem";

                    using (MySqlCommand cmdSel = new MySqlCommand(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                        da.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;
                    }

                    connection.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ops_Click(object sender, RoutedEventArgs e)
        {
            ListOs();
        }

        private void comp_Click(object sender, RoutedEventArgs e)
        {
            ListComputers();
        }

        private void Reg_button_Click(object sender, RoutedEventArgs e)
        {
            Regisztracio subwindow = new Regisztracio();
            subwindow.Show();
        }

        private void Belepes_button_Click(object sender, RoutedEventArgs e)
        {
            Belepes subwindow = new Belepes();
            subwindow.Show();
        }
    }
}