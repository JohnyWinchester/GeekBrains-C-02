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

namespace DZ0501AndreyMatveew
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        MainWindow window;
        public AddEmployee(MainWindow mainWindow)
        {
            InitializeComponent();
            window = mainWindow;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            window.staffDataBase.employees.Add(new Employee(nameTextBox.Text.ToString(), surnameTextBox.Text.ToString(), departmentTextBox.Text.ToString()));

            int amountDepartments = 0;
            foreach (var el in window.staffDataBase.departments)
            {
                if (el.DepartmentName == departmentTextBox.Text) amountDepartments++;
            }
            if (amountDepartments == 0) window.staffDataBase.departments.Add(new Department(departmentTextBox.Text));

            window.boxDepartment.ItemsSource = window.staffDataBase.departments.Select(t => t.DepartmentName);
            window.listEmployes.ItemsSource = window.staffDataBase.employees.Select(t => $"{t.Name} {t.Surname} {t.Department}");

            MessageBox.Show("Сотрудник добавлен");
        }
    }
}
