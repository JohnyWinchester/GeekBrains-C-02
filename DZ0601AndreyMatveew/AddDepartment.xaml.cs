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
    /// Логика взаимодействия для AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window
    {
        public AddDepartment()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if ((MainWindow.DataBase.ContainsDepartment(NameTextBox.Text)))
            {
                MessageBox.Show("Такой департамент уже существует");
            }

            else if (NameTextBox.Text == "") MessageBox.Show("Заполните поле с названием департамента");
            else
            {
                MainWindow.DataBase.Departments.Add(new Department(NameTextBox.Text));
                MessageBox.Show("Департамент успешно добавлен");
            }
        }
    }
}
