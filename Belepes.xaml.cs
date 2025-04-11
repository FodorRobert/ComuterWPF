using MySqlConnector;
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
using System.Windows.Shapes;

namespace ComuterWPF
{
    /// <summary>
    /// Interaction logic for Belepes.xaml
    /// </summary>
    public partial class Belepes : Window
    {

        public const string ConnectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";


        public Belepes()
        {
            InitializeComponent();
        }

        private void Belepes_belepes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    var nev = txtUsername.Text;
                    var jelszo = txtPassword.Password;
                    var sql = $"SELECT * FROM users WHERE UserName = '{nev}' AND Password = '{jelszo}'";
                    var lekerdezes = new MySqlCommand(sql, connection).ExecuteReader();
                    if (lekerdezes.Read())
                    {
                        MessageBox.Show("Sikeres bejelentkezés!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sikertelen bejelentkezés!\nHibás felhasználónév vagy jelszó!");
                    }
                    lekerdezes.Close();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
    }
}
