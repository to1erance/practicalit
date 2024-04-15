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

namespace Praktika1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void newbtn_Click(object sender, RoutedEventArgs e)
        {
            var login = newlogin.Text;
            var pass = newpwd.Text;
            var mail = newmail.Text;
            var context = new AppDbContext();
            var user = new User { Login = login , Email = mail, Password = pass  };
            var users = context.Users.SingleOrDefault(x => x.Login==login);
            if (users != null)
            {
                context.Users.Remove(users);
                context.SaveChanges();
            }
            context.Users.Add(user);
            context.SaveChanges();
            vivod.Text = "Успешно";
        }
    }
}
