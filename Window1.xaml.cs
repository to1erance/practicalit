using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Praktika1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private List<char> chars = new List<char>
        {
            '!','#','$','%','&','*','(',')','{','}','/'
        };
        //private List<char> sobakamail = new List<char>
        //{
        //    '@'
        //};

        public Window1()
        {
            InitializeComponent();
        }

        private void nazad_Click(object sender, RoutedEventArgs e) 
        {
            MainWindow main = new();
            main.Show();
           this.Close();
        }

        private void voyti_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = reglogin.Text;

            var pwd = password.Text;

            var email = mail.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(X=>X.Login == login);

            if (user_exists != null)
            {
                nereg.Text = "Такой пользователь уже существует";
                reglogin.BorderBrush = Brushes.Red;
                return;
            }
            if (!email.Contains("@"))
            {
                nereg.Text = "Некорректная почта";
                mail.BorderBrush = Brushes.Red;
                return;
            }
            if (chars.Any(x => pwd.Contains(x)))
            {
                nereg.Text = "Введены некорректные данные";
                password.BorderBrush = Brushes.Red;
                return;
            }
            if(password.Text.Length > 10)
            {
                nereg.Text = "Пароль больше допустимых значений";
                return;
            }
            if (password.Text.Length < 4)
            {
                nereg.Text = "Пароль меньше допустимых значений";
                return;
            }
            if (password != repeatpassword )
            {
                nereg.Text = "Несовпадение пароля";
                repeatpassword.BorderBrush = Brushes.Red;
                return;
            }
            var user = new User
            {
                Login = login,
                Password = pwd,
                Email = email
            };

            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Регистрация успешна");
            MainWindow main = new();
            main.Show();
            this.Close();

            //if (pwd == repeatpassword.Text)
            //{
            //    for (int i = 0; i < pwd.Length; i++)
            //    {
            //        if (pwd[i] == '@' || pwd[i] == '+')
            //        {
            //            break;
            //        }

            //    }
            //}
            //else
            //{
            //    nereg.Text = "Введено неверное значение";
            //}

        }

    }
}
