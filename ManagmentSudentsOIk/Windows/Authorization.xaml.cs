using ManagmentSudentsOIk.Clases;
using ManagmentSudentsOIk.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace ManagmentSudentsOIk.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }
        public static int counter = 5;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase.Преподаватели authUser = null;
            using (var entities = new Entities()) 
            {
                authUser = entities.Преподаватели.FirstOrDefault(b => (b.Логин == tbLogin.Text || b.ЭлектроннаяПочта == tbLogin.Text) && (b.Пароль == tbPassword.Password || tbPassword.Password == Access.RecoveryPas));
            }
            if (authUser == null)
            {
                MessageBox.Show("Вы ввели неверный логин или пароль");
                tbPassword.Password = "";
                counter--;
                if (counter == 0)
                {
                    Bloked bloked = new Bloked();
                    bloked.BlokedGrid(_grid, 5);
                    counter = 5; 
                }
            }
            else
            {
                //Переход
                MessageBox.Show("Успешно");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Recovery recovery = new Recovery();
            recovery.Show();
            Close();
        }
    }
}
