using System;
using System.Collections.Generic;
using System.Collections;
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
            Firestore.Firestore.Init();

            Views.Login w2 = new Views.Login();
            lb_rooms.ItemsSource = classes.User.Allrooms;


        }



        private void lb_students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void lb_rooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_remove(object sender, RoutedEventArgs e)
        {

        }

        private void Button_add(object sender, RoutedEventArgs e)
        {

        }

        private async void Create_Class_Button_Click(object sender, RoutedEventArgs e)
        {

            var tsk = program.CreateRoom(classnamebox.Text);
            var x = await tsk;
            lb_rooms.Items.Refresh();

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

