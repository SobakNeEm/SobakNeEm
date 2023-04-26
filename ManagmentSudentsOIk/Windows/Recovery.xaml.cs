using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace ManagmentSudentsOIk.Windows
{
    /// <summary>
    /// Логика взаимодействия для Recovery.xaml
    /// </summary>
    public partial class Recovery : Window
    {
        public Recovery()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase.Преподаватели user = null;
            using (DataBase.Entities entities = new DataBase.Entities())
            {
                user = entities.Преподаватели.FirstOrDefault(b => b.ЭлектроннаяПочта == tbMail.Text && b.Логин == tbLogin.Text);
            }
            if (user == null)
            {
                MessageBox.Show("Неправильно введены данные");
                return;
            }
            string mail = user.ЭлектроннаяПочта;
            MailAddress from = new MailAddress("ravil.ignatiev2002@mail.ru", "Ravil");
            MailAddress to = new MailAddress(mail);
            MailMessage m = new MailMessage(from, to);
            const string valid = "abcdefghijklmnopqrstuvwyzABCDEFGHIJKLMOPQRSTUVWXYZ1234567890";
            var res = new List<char>();
            Random rnd = new Random();
            int length = 14;
            while (0 < length--)
            {
                res.Add(valid[rnd.Next(valid.Length)]);
            }
            m.Subject = $"Восстановление";
            m.Body = $"Придурок, ты и вправду забыл свой пароль? + \t Вот держи новый {string.Join("", res)}";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("ravil.ignatiev2002@mail.ru", "HxXtB4MdAa8K95iwekxx");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Clases.Access.RecoveryPas = string.Join("",res);
            var auth = new Authorization();
            auth.Show();
            Close();
        }
    }
}
