using SquareCalculator.BI;
using System.Windows;
using System.Data.Entity;
using System.Collections.Generic;
using DataBase.DataContexts;
using System.Linq;

namespace DatabaseOutput
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
             var res = DbReader.ReadEmployee("B",500);
             DbGrid.ItemsSource=res.ToList();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            sampleEntities db = new sampleEntities();
            var res =
            from em in db.employee
            join dept in db.Departament on em.dept_no equals dept.dept_no
            join work in db.works_on on em.emp_no equals work.emp_no
            orderby em.emp_fname
            select new { em.emp_fname, em.emp_lname, em.salary, work.job, dept.dept_no, dept.dept_name, dept.location };
            DbGrid.ItemsSource = res.ToList();
        }
        private void but_work_Click(object sender, RoutedEventArgs e)
        {
            var res = DbReader.ReadWork();
            DbGrid.ItemsSource = res.ToList();
        }
        private void but_project_Click(object sender, RoutedEventArgs e)
        {
            var res = DbReader.ReadProject();
            DbGrid.ItemsSource = res.ToList();
        }
        private void but_dept_Click_1(object sender, RoutedEventArgs e)
        {
            var res = DbReader.ReadDepartment();
            DbGrid.ItemsSource = res.ToList();
        }

        private void but_emp_Click_1(object sender, RoutedEventArgs e)
        {
            var res = DbReader.ReadEmployee();
            DbGrid.ItemsSource = res.ToList();
        }
        private void dataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) { }
    }
}

