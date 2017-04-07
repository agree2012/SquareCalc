using DataBase.DataContexts;
using DbAddSave;
using MVVM;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DbAddSave
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Emps { get; set; }
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                (saveCommand = new RelayCommand(obj =>
                {
                    DbMethods.Addtodb(Selectedemp);
                }));
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                (removeCommand = new RelayCommand(obj =>
                {
                    DbMethods.Removefromdb(Selectedemp);
                    Emps.Remove(Selectedemp);
                },(obj) => Emps.Count > 0));
            }
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                (addCommand = new RelayCommand(obj =>
                {
                    Employee emp = new Employee();
                    Emps.Insert(0, emp);
                    Selectedemp = emp;
                }));
            }
        }
        private Employee selectedemp;
        public Employee Selectedemp
        {
            get { return selectedemp; }
            set
            {
                selectedemp = value;
                OnPropertyChanged("Selectedemp");
            }
        }
        public AppViewModel()
        {
            Emps = DbMethods.EmpsConstruct();
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