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
    /// Interaction logic for PersonalTea.xaml
    /// </summary>
    public partial class PersonalTea : Window
    {
        public PersonalTea()
        {
            InitializeComponent();
        }
        private void Catalogue(object sender, RoutedEventArgs e)
        {
            TeaCatalogue mwC = new TeaCatalogue();
            mwC.Show();
            this.Close();
        }
        private void BubbleTeaSpec(object sender, RoutedEventArgs e)
        {
            BubbleTeaSpecifics mwBC = new BubbleTeaSpecifics();
            mwBC.Show();
            this.Close();
        }
        private void PersTea(object sender, RoutedEventArgs e)
        {
            PersonalTea mwPT = new PersonalTea();
            mwPT.Show();
            this.Close();
        }
        private void AbUs(object sender, RoutedEventArgs e)
        {
            AboutUs mwAU = new AboutUs();
            mwAU.Show();
            this.Close();
        }

        private void Entry(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-SDEJ6HG; Initial Catalog=Tea; Integrated Security=True");
            try
            {
                sqlCon.Open();
                string dateToday = DateTime.Now.ToString("dd/MM/yyyy");
                string query = "INSERT INTO AllTheTea(EntryDate,EntryNotes)values ('" + dateToday + "','" + this.TeaEntry.Text + "') ";

                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully saved");

                PersonalTea mwPT = new PersonalTea();
                mwPT.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source = DESKTOP-SDEJ6HG; Initial Catalog=Tea; Integrated Security=True");
            try
            {
                string query = "SELECT * FROM AllTheTea";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlCon);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                PreviousTea.ItemsSource = dataSet.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
