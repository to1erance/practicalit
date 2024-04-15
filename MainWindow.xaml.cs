using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Praktika1
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
   
        public int checkgege;

        private async void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = auth.Text;
            var password = pwdPasswordBox.Password;

            var context = new AppDbContext();

            var user = context.Users.FirstOrDefault(x => x.Login == login || x.Email == login && x.Password == password);
             
        if(user == null)
        {
            osh1.Text = "Неверный логин или пароль";
            checkgege += 1;
                auth.BorderBrush = Brushes.Red;
            if (checkgege == 3)
            {
                AuthBtn.Visibility = Visibility.Hidden;
                osh1.Text = "Три неверных попытки ввода";
                await Task.Delay(15000);
                AuthBtn.Visibility = Visibility.Visible;
                checkgege = 0;

            }
            return;
        }
            

            Window2 window2 = new Window2(login, password);
            window2.Show();
            this.Close();
        }


        private void ToRegBtn_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }

        private void EyeBtn_Click(object sender, RoutedEventArgs e)
        {
                if (pwdTextBox.Visibility == Visibility.Collapsed)
                {
                    pwdTextBox.Text = pwdPasswordBox.Password; 
                    pwdTextBox.Visibility = Visibility.Visible; 
                    pwdPasswordBox.Visibility = Visibility.Collapsed; 
                }
                else
                {
                    pwdPasswordBox.Password = pwdTextBox.Text; 
                    pwdTextBox.Visibility = Visibility.Collapsed; 
                    pwdPasswordBox.Visibility = Visibility.Visible; 
                }
        }

    }
}