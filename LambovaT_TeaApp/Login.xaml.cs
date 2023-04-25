using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LambovaT_TeaApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string PassTable { get; private set; }

        public Login()
        {
            InitializeComponent();
        }
        private void Confirm(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\2022_2023\Informatics\Applications\FinalTeaApp\LambovaT_TeaApp\LambovaT_TeaApp\TeaDB.mdf;Integrated Security=True");
            try
            {
                sqlCon.Open();
                string query = "SELECT Pass FROM Users WHERE Email='this.Email'";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                object result = cmd.ExecuteScalar();
                string passTable = (result == null ? "" : result.ToString());
                cmd.ExecuteNonQuery();

                if (!(GetPassword() == passTable))
                {
                    MessageBox.Show("Passwords don't match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Welcome back!");

                    TeaCatalogue mwC = new TeaCatalogue();
                    mwC.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string GetPassword()
            {
                return Pass.Password;
            }
        }
    }
}
