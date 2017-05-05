using DataBase.DataContexts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DbAddSave
{
    public static class DbMethods
    {
        public static void Addtodb(Employee e)
        {
             /// <param name="Int2">Used to indicate status.</param>
            using (sampleEntities db = new sampleEntities())
            {
                db.employee.Add(new employee
                {
                    emp_no = e.Emp_no,
                    emp_fname = e.Emp_fname,
                    emp_lname = e.Emp_lname,
                    salary = e.Salary,
                    dept_no = e.Dept_no
                });
                db.SaveChanges();
            }
        }

        public static void Removefromdb(Employee Selectedemp)
        {
            if (Selectedemp == null)
                return;
            using (sampleEntities db = new sampleEntities())
            {
                db.employee.RemoveRange(db.employee.Where(c => c.emp_no == Selectedemp.Emp_no));
                db.SaveChanges();
            }
        }

        public static ObservableCollection<Employee> EmpsConstruct()
        {
            using (var db = new sampleEntities())
            {
                var res = (db.employee.Select(c => new Employee
                {
                    Emp_no = c.emp_no,
                    Emp_fname = c.emp_fname,
                    Emp_lname = c.emp_lname,
                    Salary = c.salary,
                    Dept_no = c.dept_no
                })).ToList();
                ObservableCollection<Employee> emptable = new ObservableCollection<Employee>(res);
                return emptable;
            }
        }
    }
}
