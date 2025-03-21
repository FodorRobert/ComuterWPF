using MySqlConnector;
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
        }

        public const string ConnectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";

        public static void connect()
        {
            using (var connection = new MySqlConnection(ConnectionString)
            {

                connection.Open();

            string sql = "select accounts.roles_id from accounts where accounts.username = @username and accounts.pass = @password";
            using (var command = new MySqlCommand(sql, connection))
            {

                using (var reader = command.ExecuteReader())
                {


                }
            }

        }

    }
}