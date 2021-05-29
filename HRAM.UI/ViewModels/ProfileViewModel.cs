using HRAM.UI.Helpers;
using HRAM.UI.Models;
using HRAM.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAM.UI.ViewModels
{
    public class ProfileViewModel : BindableBase
    {
        public ProfileViewModel()
        {
            email = LoginView._EmailLog;
            populateEm();
            lastname = employee.LastName;
            add = employee.Adress;
            cnp = employee.CNP;
            bday = employee.Bday;
        }
        private static Employee employee = new Employee();
        public void populateEm()
        {
            employee = DataAccess.GetEmployee(email);
        }
        private DateTime bday;
        public DateTime BDay
        {
            get => bday;
            set
            {
                bday = value;
                OnPropertyChanged();
            }
        }
        private long cnp;
        public long CNP 
        { 
            get => cnp; 
            set
            {
                cnp = value;
                OnPropertyChanged();
            }
        }
        private string add = "";
        public string Add
        {
            get { return add; }
            set
            {
                add = value;
                OnPropertyChanged();
            }
        }
        private string email = "";
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        private string lastname = "";
        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged();
            }
        }
    }
}
