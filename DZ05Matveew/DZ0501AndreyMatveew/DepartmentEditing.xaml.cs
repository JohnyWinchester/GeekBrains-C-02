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
    /// Логика взаимодействия для DepartmentEditing.xaml
    /// </summary>
    public partial class DepartmentEditing : Window
    {
        MainWindow window;
        string departmentEdit;
        public DepartmentEditing(MainWindow mainWindow,string department)
        {
            InitializeComponent();
            window = mainWindow;
            departmentEdit = department;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(var el in window.staffDataBase.departments)
            {
                if (el.DepartmentName == departmentEdit) el.DepartmentName = departmentNameBox.Text;
            }

            foreach(var el in window.staffDataBase.employees)
            {
                if(el.Department == departmentEdit) el.Department = departmentNameBox.Text;
            }

            window.boxDepartment.ItemsSource = window.staffDataBase.departments.Select(t => t.DepartmentName);
            window.listEmployes.ItemsSource = window.staffDataBase.employees.Select(t => $"{t.Name} {t.Surname} {t.Department}");
            MessageBox.Show("Вы изменили название департамента");
        }
    }
}
