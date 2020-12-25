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
    /// Логика взаимодействия для EmployeeEditing.xaml
    /// </summary>
    public partial class EmployeeEditing : Window
    {
        readonly Employee oldEmployee;
        public EmployeeEditing(Employee employee)
        {
            InitializeComponent();
            oldEmployee = employee;

            nameBox.Text = employee.Name;
            surnameBox.Text = employee.Surname;
            departmentBox.Text = employee.Department;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var el in MainWindow.DataBase.Employees)
            {
                if(el.Name == oldEmployee.Name && el.Surname == oldEmployee.Surname && el.Department == oldEmployee.Department)
                {
                    if (nameBox.Text != "") el.Name = nameBox.Text;
                    if (surnameBox.Text != "") el.Surname = surnameBox.Text;
                    if (departmentBox.Text != "")
                    {
                        el.Department = departmentBox.Text;
                        if (!(MainWindow.DataBase.ContainsDepartment(departmentBox.Text))) 
                            MainWindow.DataBase.Departments.Add(new Department(departmentBox.Text));    
                    }
                }
            }
            MessageBox.Show("Сотрудник изменён");
        }
    }
}
