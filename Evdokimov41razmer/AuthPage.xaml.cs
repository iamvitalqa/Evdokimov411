using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Evdokimov41razmer
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        
        
        public AuthPage()
        {
            InitializeComponent();
        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTBox.Text;
            string password = PassTBox.Text;
            User user = Evdokimov41Entities.GetContext().User.ToList().Find(p => p.UserLogin == login && p.UserPassword == password);

            if (user == null)
            {
                Manager.MainFrame.Navigate(new ProductPage(user));
                LoginTBox.Text = "";
                PassTBox.Text = "";
            }
        }
        

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTBox.Text;
            string password = PassTBox.Text;
            if (login == "" || password == "")
            {
                MessageBox.Show("Есть пустые поля");
                return;
            }

            User user = Evdokimov41Entities.GetContext().User.ToList().Find(p => p.UserLogin == login && p.UserPassword == password);
            if (user != null)
            {
                Manager.MainFrame.Navigate(new ProductPage(user));
                LoginTBox.Text = "";
                PassTBox.Text = "";
            }
            else
            {
                MessageBox.Show("Введены неверные данные");
                LoginBtn.IsEnabled = false;
                await Task.Delay(TimeSpan.FromSeconds(10));
                LoginBtn.IsEnabled = true;
            }
        }
       


    }
}
