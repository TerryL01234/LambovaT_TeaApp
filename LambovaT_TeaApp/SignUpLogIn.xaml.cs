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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LambovaT_TeaApp
{
    /// <summary>
    /// Interaction logic for SignUpLogIn.xaml
    /// </summary>
    public partial class SignUpLogIn : Window
    {
        public SignUpLogIn()
        {
            InitializeComponent();
        }
        private void GoSignUp(object sender, RoutedEventArgs e)
        {
            SignUp mwSU = new SignUp();
            mwSU.Show();
            this.Close();
        }

        private void GoLogin(object sender, RoutedEventArgs e)
        {
            Login mwLI = new Login();
            mwLI.Show();
            this.Close();
        }

    }
}
