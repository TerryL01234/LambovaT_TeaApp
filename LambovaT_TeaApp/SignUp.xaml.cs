using System;
using System.Collections.Generic;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private void Confirm(object sender, RoutedEventArgs e)
        {
            if (First.Text.Equals("") || Last.Text.Equals(""))
            {
                MessageBox.Show("The fields 'First Name' and 'Last Name' shouldn't be left empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Email.Text.Contains("@"))
            {
                MessageBox.Show("The fields 'Email' needs to conatain '@'.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!(PassRep.Password == Pass.Password))
            {
                MessageBox.Show("Passwords don't match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\2022_2023\Informatics\Applications\FinalTeaApp\LambovaT_TeaApp\LambovaT_TeaApp\TeaDB.mdf;Integrated Security=True");
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO Users(FirstName,LastName,Email,Pass)values ('" + this.First.Text + "','" + this.Last.Text + "','" + this.Email.Text + "','" + this.Pass.Password + "') ";

                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Account created");

                    TeaCatalogue mwC = new TeaCatalogue();
                    mwC.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            
        }

    }
}
