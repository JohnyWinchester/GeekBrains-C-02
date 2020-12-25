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

namespace DZ0601AndreyMatveew
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    //Изменить WPF-приложение для ведения списка сотрудников компании(из урока 5), 
    //используя связывание данных, ListView, ObservableCollection и INotifyPropertyChanged.

    //Создать сущности Employee и Department и заполнить списки сущностей начальными данными.

    //Для списка сотрудников и списка департаментов предусмотреть визуализацию(отображение).
    //Это можно сделать, например, с использованием ComboBox или ListView.

    //Предусмотреть редактирование сотрудников и департаментов.Должна быть возможность изменить департамент у сотрудника.
    //Список департаментов для выбора можно выводить в ComboBox, и все это можно выводить на дополнительной форме.

    //Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать данную возможность либо на форме редактирования, либо сделать новую форму.

    public partial class MainWindow : Window
    {
        public static DataBase DataBase { get; set; }
        DepartmentEditing departmentEditing;
        EmployeeEditing employeeEditing;
        AddEmployee addEmployee;
        AddDepartment addDepartment;

        public MainWindow()
        {
            InitializeComponent();
            DataBase = new DataBase();
            this.DataContext = DataBase;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBox.SelectedItem != null)
            {
                //BindingOperations.ClearAllBindings(listView);
                //var employees = DataBase.Employees.Where(t => t.Department == comboBox.SelectedItem.ToString());
                //listView.ItemsSource = employees;
                //Binding bindingListView = new Binding();
                //bindingListView.Source = employees;
                ////listView.SetBinding(listView.ItemsSource, bindingListView);
                //nameColumn.DisplayMemberBinding = bindingListView;
                //BindingOperations.ClearBinding(listView,ItemsControl.ItemsSourceProperty);

                var employees = DataBase.Employees.Where(t => t.Department == ((Department)comboBox.SelectedItem).DepartmentName);
                Binding bindingListView = new Binding
                {
                    Source = employees
                };
                listView.SetBinding(ItemsControl.ItemsSourceProperty, bindingListView);
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedItem != null)
            {
                departmentEditing = new DepartmentEditing(((Department)comboBox.SelectedItem).DepartmentName);
                departmentEditing.Show();
            }
            else MessageBox.Show("Выберите департамент из выпадающего списка");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                employeeEditing = new EmployeeEditing((Employee)listView.SelectedItem);
                employeeEditing.Show();
            }
            else MessageBox.Show("Выберите сотрудника из списка");
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            addEmployee = new AddEmployee();
            addEmployee.Show();
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            addDepartment = new AddDepartment();
            addDepartment.Show();
        }
    }
}
