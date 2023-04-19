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
    /// Interaction logic for BubbleTeaSpecifics.xaml
    /// </summary>
    public partial class BubbleTeaSpecifics : Window
    {
        public BubbleTeaSpecifics()
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
    }
}
