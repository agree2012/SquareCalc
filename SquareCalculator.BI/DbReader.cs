using DataBase.DataContexts;
using System.Collections.Generic;
using System.Linq;


namespace SquareCalculator.BI
{
    public static class DbReader
    {
        static sampleEntities db = new sampleEntities();
        public static IEnumerable<employee> ReadEmployee(string employee)
        {
           return db.employee.Where(p => p.emp_fname.Contains(employee)).Select(p => p).ToList();
        }
        public static IEnumerable<employee> ReadEmployee(string employee, int salary)
        {
            var res = (from c in db.employee where c.emp_fname.Contains(employee) && c.salary >= salary select c).ToList();
            return res;
        }
        public static IEnumerable<employee> ReadEmployee()
        {
            return db.employee.Select(p =>p).ToList();
        }
        public static IEnumerable<Departament> ReadDepartment()
        {
            return db.Departament.ToList();
        }
        public static IEnumerable<works_on> ReadWork()
        {
            return db.works_on.ToList();
        }
        public static IEnumerable<project> ReadProject()
        {
            return db.project.ToList();
        }
        /*
        public static IEnumerable<employee> ReadAllTable()
        {
            var res = db.employee.Join(db.Departament, em => em.dept_no, d => d.dept_no, (em, d) => new
            { emp_fname = em.emp_fname, emp_lname = em.emp_lname, salary = em.salary, dept_no = d.dept_no, dept_name = d.dept_name, location = d.location }).ToList
            ();
            foreach (var r in res)
                
        }*/
        /*
        var res =
        from em in db.employee
        join dept in db.Departament on em.dept_no equals dept.dept_no
        join work in db.works_on on em.emp_no equals work.emp_no
        orderby em.emp_fname
        select new { em.emp_fname, em.emp_lname, em.salary, work.job, dept.dept_no, dept.dept_name, dept.location };
        */
   
        public static IEnumerable<PropAllTable> ReadAllTAble()
        {
            var res =
            from em in db.employee
            join dept in db.Departament on em.dept_no equals dept.dept_no
            join work in db.works_on on em.emp_no equals work.emp_no
            orderby em.emp_fname
            select new PropAllTable()
            {
                Emp_fname = em.emp_fname,
                Emp_lname = em.emp_lname,
                Salary = em.salary,
                Job = work.job,
                Dept_no = dept.dept_no,
                Dept_name = dept.dept_name,
                Location = dept.location };
            
            return res.ToList();
        }
    }
    public class PropAllTable
    {
        public string Emp_fname { get; set; }
        public string Emp_lname { get; set; }
        public int Salary { get; set; }
        public string Job { get; set; }
        public int Dept_no { get; set; }
        public string Dept_name { get; set; }
        public string Location { get; set; }
    }
}
