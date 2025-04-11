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
    /// Interaction logic for Regisztracio.xaml
    /// </summary>
    public partial class Regisztracio : Window
    {

        public const string ConnectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";


        public Regisztracio()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                if (Reg_Username.Text == "" || Reg_Password.Password == "" || Reg_Password_Again.Password == "")
                {
                    MessageBox.Show("Sikertelen regisztráció!\nA mezők nem lehetnek üresek!");
                    return;
                }

                else if (Reg_Password.Password != Reg_Password_Again.Password)
                {
                    MessageBox.Show("Sikertelen regisztráció!\nA két jelszó nem egyezik!");
                    Reg_Password.Password = "";
                    Reg_Password_Again.Password = "";
                    return;
                }

                var sql = $"SELECT * FROM users WHERE UserName = '{Reg_Username.Text}'";
                var lekerdezes = new MySqlCommand(sql, connection).ExecuteReader();
                if (lekerdezes.Read())
                {
                    MessageBox.Show("Sikertelen regisztráció!\nA felhasználó már létezik! Jelentkezzen be!");

                    Belepes subwindow = new Belepes();
                    subwindow.Show();
                    this.Close();

                    connection.Close();
                    return;
                }
                lekerdezes.Close();

                sql = $"INSERT INTO users (UserName,FullName,Password) VALUES ('{Reg_Username.Text}','{Reg_FullName.Text}','{Reg_Password.Password}')";
                var beszuras = new MySqlCommand(sql, connection).ExecuteNonQuery();
                if (beszuras == 1)
                {
                    MessageBox.Show("Sikeres regisztráció!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sikertelen regisztráció!");
                }
                connection.Close();
            }
        }
    }
}
