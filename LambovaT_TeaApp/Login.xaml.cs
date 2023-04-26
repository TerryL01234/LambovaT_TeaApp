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
            try
            {
                // Code to retrieve user's entered email and password from the login form
                string enteredEmail = Email.Text;
                string enteredPassword = Pass.Password;

                // Retrieve user's email and password from the database
                string emailRetrieved = "";
                string passRetrieved = "";

                using (SqlConnection cnxn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\2022_2023\Informatics\Applications\FinalTeaApp\LambovaT_TeaApp\LambovaT_TeaApp\TeaDB.mdf;Integrated Security=True"))
                {
                    // Create a SqlCommand to retrieve the email and password from the Users table
                    SqlCommand cmd = new SqlCommand("SELECT Email, Pass FROM Users WHERE Email=@Email", cnxn);
                    cmd.Parameters.AddWithValue("@Email", enteredEmail);

                    cnxn.Open();

                    // Execute the SqlCommand and retrieve the email and password from the database
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        emailRetrieved = reader["Email"].ToString();
                        if (enteredEmail == emailRetrieved)
                        {
                            passRetrieved = reader["Pass"].ToString();
                            if (enteredPassword == passRetrieved)
                            {
                                MessageBox.Show("Welcome back!");
                                reader.Close();
                                cnxn.Close();
                                TeaCatalogue mwC = new TeaCatalogue();
                                mwC.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect password, login unsuccessful.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email not found, login unsuccessful.");
                        }
                    }
                    reader.Close();
                    cnxn.Close();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
