using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DZ0501AndreyMatveew
{
    /// <summary>
    /// Логика взаимодействия для EmployeeEditing.xaml
    /// </summary>
    public partial class EmployeeEditing : Window
    {
        string employee;
        MainWindow window;
        public EmployeeEditing(MainWindow mainWindow,string employeeEdit)
        {
            InitializeComponent();
            employee = employeeEdit;
            window = mainWindow;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        { 
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var emp = employee.Split(' ');

            foreach (var el in window.staffDataBase.employees)
            {
                if (el.Name == emp[0] && el.Surname == emp[1] && el.Department == emp[2])
                {
                    el.Name = textBoxName.Text;
                    el.Surname = textBoxSurname.Text;
                    el.Department = textBoxDepartment.Text;
                }
            }

            int amountDepartments = 0;
            foreach(var el in window.staffDataBase.departments)
            {
                if (el.DepartmentName == textBoxDepartment.Text) amountDepartments++;
            }
            if (amountDepartments == 0) window.staffDataBase.departments.Add(new Department(textBoxDepartment.Text));

            window.boxDepartment.ItemsSource = window.staffDataBase.departments.Select(t => t.DepartmentName);
            window.listEmployes.ItemsSource = window.staffDataBase.employees.Select(t => $"{t.Name} {t.Surname} {t.Department}");

            MessageBox.Show("Сотрудник изменён");
        }
    }
}
