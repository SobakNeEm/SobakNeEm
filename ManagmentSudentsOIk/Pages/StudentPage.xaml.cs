using ManagmentSudentsOIk.DataBase;
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

namespace ManagmentSudentsOIk.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            using (var context = new Entities())
            {
                dgStudent.ItemsSource = context.Студенты.ToList();
                cbAddStatus.ItemsSource = context.СтудентаСтатус.ToList();
                var selectedItem = dgStudent.SelectedItem;
                if (selectedItem != null) 
                {
                    dgPropuski.ItemsSource = selectedItem.ToString();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(tbAddDate.Text);
            Random rnd = new Random();
            //int Status = Convert.ToInt32(cbAddStatus.Text);
            DataBase.Студенты Student = new DataBase.Студенты()
            {
                СтудентаId = rnd.Next(20, 9999999),
                Фамилия = tbAddFamily.Text,
                Имя = tbAddName.Text,
                Отчество = tbAddOtche.Text,
                //СтатусСтудента = Status,
                ДатаРождения = date,
            };
            using (var context = new Entities())
            {
                context.Студенты.Add(Student);
                context.SaveChanges();
                dgStudent.ItemsSource = context.Студенты.ToList();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
