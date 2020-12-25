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

namespace DZ0601AndreyMatveew
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainWindow.DataBase.ContainsDepartment(departmentBox.Text)))
            {
                MessageBox.Show("Вначале создайте такой отдел");
            }

            else if(nameBox.Text == "" || surnameBox.Text == "" || departmentBox.Text == "")
            {
                MessageBox.Show("Все поля необходимо заполнить");
            }

            else
            {
                foreach (var el in MainWindow.DataBase.Employees)
                {
                    if (nameBox.Text == el.Name &&
                       surnameBox.Text == el.Surname &&
                       departmentBox.Text == el.Department)
                    {
                        MessageBox.Show("Такой сотрудник уже существует");
                        break;
                    }
                    else
                    {
                        MainWindow.DataBase.Employees.Add(new Employee(nameBox.Text, surnameBox.Text, departmentBox.Text));
                        MessageBox.Show("Новый сотрудник создан");
                        break;
                    }

                }
            }

        }
    }
}
