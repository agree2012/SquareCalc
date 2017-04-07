using DataBase.DataContexts;
using System.Windows;

namespace DbAddSave
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AppViewModel();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //ViewModelButton.UpdateButton();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //using (sampleEntities db = new sampleEntities())
            //{
            //    IEnumerable<employee> res = db.employee.Where(c => c.emp_no.ToString() == textbox5.Text).Select(c => c);
            //    db.employee.RemoveRange(res);
            //    db.SaveChanges();
            //}
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            //using (sampleEntities db = new sampleEntities())
            //{
            //    IEnumerable<employee> res = db.employee.Where(c => c.emp_no.ToString() == textbox5.Text).Select(c => c);
            //    db.employee.RemoveRange(res);
            //    db.employee.Add(new employee
            //    {
            //        emp_no = Int32.Parse(textbox5.Text),
            //        emp_fname = textbox1.Text,
            //        emp_lname = textbox2.Text,
            //        salary = Int32.Parse(textbox3.Text),
            //        dept_no = Int32.Parse(textbox4.Text)
            //    });
            //    db.SaveChanges();
            //}
        }
    }
}








