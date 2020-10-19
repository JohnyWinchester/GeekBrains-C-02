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

namespace DZ0501AndreyMatveew
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataBase staffDataBase;
        EmployeeEditing employeeEditingWindow;
        DepartmentEditing departmentEditingWindow;
        AddEmployee addEmployee;
        AddDepartment addDepartment;

       public MainWindow()
       {
            InitializeComponent();
            staffDataBase = new DataBase();
            boxDepartment.ItemsSource = staffDataBase.departments.Select(e => e.DepartmentName);
            listEmployes.ItemsSource = staffDataBase.employees.Select(e => $"{e.Name} {e.Surname} {e.Department}");
       }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(boxDepartment.SelectedItem != null)
            {
                listEmployes.ItemsSource = staffDataBase.employees.Where(t => t.Department == boxDepartment.SelectedItem.ToString())
                                                  .Select(t => $"{t.Name}  {t.Surname}  {t.Department}");
            }
        }

        private void editingEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            employeeEditingWindow = new EmployeeEditing(this, listEmployes.SelectedItem.ToString());
            employeeEditingWindow.Show();
        }

        private void editingDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            departmentEditingWindow = new DepartmentEditing(this, boxDepartment.SelectedItem.ToString());
            boxDepartment.SelectedValue = null;
            departmentEditingWindow.Show();
        }

        private void newEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            addEmployee = new AddEmployee(this);
            addEmployee.Show();
        }

        private void newDepartmenteBtn_Click(object sender, RoutedEventArgs e)
        {
            addDepartment = new AddDepartment(this);
            addDepartment.Show();

        }
    }
}
