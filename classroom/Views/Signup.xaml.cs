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

namespace classroom.Views
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public Signup()
        {
            InitializeComponent();
        }

        //public event EventHandler PasswordsDontMatch;


        private void SigupClick(object sender, RoutedEventArgs e)
        {

            program.UserSignup(namebox.Text, pwbox.Password.ToString());

        }

        private void GotToLoginClick(object sender, RoutedEventArgs e)
        {
            Views.Login lw = new Login();
            lw.Show();
            this.Close();
        }

        private void passchanged(object sender, RoutedEventArgs e)
        {
            if (pwbox2.Password != pwbox.Password)
            {
                passdontmatch.Visibility = Visibility.Visible;
                Signupbutton.IsEnabled = false;

            }
            else
            {
                passdontmatch.Visibility = Visibility.Hidden;
                Signupbutton.IsEnabled = true;
            }
        }
    }
}
