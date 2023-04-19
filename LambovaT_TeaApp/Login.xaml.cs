using System;
using System.Collections.Generic;
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
    public partial class Login: Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Confirm(object sender, RoutedEventArgs e)
        {
            TeaCatalogue mwC = new TeaCatalogue();
            mwC.Show();
            this.Close();
        }
    }
}
