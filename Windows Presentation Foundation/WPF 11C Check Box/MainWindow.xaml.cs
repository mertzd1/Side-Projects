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

namespace WPF_11C_Check_Box
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

        private void cbAllCheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newval = (cbAllToppings.IsChecked == true);
            cbHam.IsChecked = newval;
            cbBacon.IsChecked = newval;
            cbPineapple.IsChecked = newval;
            cbMotzerella.IsChecked = newval;
        }
        private void cbSingleCheckChanged(object sender, RoutedEventArgs e)
        {
            cbAllToppings.IsChecked = null;
            if((cbHam.IsChecked==true) && (cbBacon.IsChecked==true) && (cbPineapple.IsChecked==true)&& (cbMotzerella.IsChecked==true)) 
            {
                cbAllToppings.IsChecked =true;
            }
            if ((cbHam.IsChecked) == false && (cbBacon.IsChecked == false) && (cbPineapple.IsChecked == false) && (cbMotzerella.IsChecked == false))
            {
                cbAllToppings.IsChecked = false;
            }


        }
    }
}
