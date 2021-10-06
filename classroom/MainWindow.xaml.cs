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



namespace classroom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Views.Login w2 = new Views.Login();


            List<string> items = new List<string>();
            
            items.Add("hello");
            items.Add("hi");
            items.Add("arko");
            lb.ItemsSource = items;


        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
