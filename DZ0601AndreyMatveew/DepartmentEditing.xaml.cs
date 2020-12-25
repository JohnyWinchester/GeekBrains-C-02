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
    /// Логика взаимодействия для DepartmentEditing.xaml
    /// </summary>
    public partial class DepartmentEditing : Window
    {
        public DepartmentEditing(string oldDepartmentName)
        {
            InitializeComponent();
            oldName.Text = oldDepartmentName;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (newNameTextBox.Text != "")
            {
                foreach (var el in MainWindow.DataBase.Departments)
                    if (el.DepartmentName == oldName.Text) el.DepartmentName = newNameTextBox.Text;

                foreach (var el in MainWindow.DataBase.Employees)
                    if (el.Department == oldName.Text) el.Department = newNameTextBox.Text;
                MessageBox.Show("Департамент изменён");
            }
            else MessageBox.Show("Введите новое название департамента");
        }
    }
}
