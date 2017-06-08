using DataBase.DataContexts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DbAddSave
{
    public class Employee : INotifyPropertyChanged
    {
     /// <param name="Int1">Used to indicate status.</param>
        private int emp_no;
        private string emp_fname;
        private string emp_lname;
        private int salary;
        private int dept_no;
       
        public int Emp_no
        {
            get { return emp_no; }
            set
            {
                emp_no = value;
                OnPropertyChanged("Emp_no");
            }
        }
        public string Emp_fname
        {
            get { return emp_fname; }
            set
            {
                emp_fname = value;
                OnPropertyChanged("Emp_fname");
            }
        } 
        public string Emp_lname
        {
            get { return emp_lname; }
            set
            {
                emp_lname = value;
                OnPropertyChanged("Emp_lname");
            }
         }
         public int Salary
         {
             get { return salary; }
             set
             {
                 salary = value;
                 OnPropertyChanged("Salary");
             }
         }
        public int Dept_no
        {
            get { return dept_no; }
            set
            {
                dept_no = value;
                OnPropertyChanged("Dept_no");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
         public void OnPropertyChanged([CallerMemberName]string prop = "")
         {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
                
            }
         }
     } 
}

