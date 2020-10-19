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
    /// Логика взаимодействия для AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window
    {
        MainWindow window;
        public AddDepartment(MainWindow mainWindow)
        {
            InitializeComponent();

            window = mainWindow;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            int amountDepartments = 0;
            foreach (var el in window.staffDataBase.departments)
            {
                if (el.DepartmentName == departmentNameTextBox.Text) amountDepartments++;
            }
            if (amountDepartments == 0) window.staffDataBase.departments.Add(new Department(departmentNameTextBox.Text));

            window.boxDepartment.ItemsSource = window.staffDataBase.departments.Select(t => t.DepartmentName);
            MessageBox.Show("Департамент добавлен");
        }

        private void departmentNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
