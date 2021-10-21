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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //auth 
            if (program.UserLogin(namebox.Text, pwbox.Password.ToString()))
            {
                var mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong username of password");
            }
            program.status += UpdateStatus;
        }
        private void UpdateStatus(object sender, string s)
        {
            MessageBox.Show(s);
        }
    }
}
