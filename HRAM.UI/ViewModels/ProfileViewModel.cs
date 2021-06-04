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
            PopulateEm();
            lastName = employee.LastName;
        }
        private static Employee employee = new Employee();
        public static int GetEmployeeUserId()
        {
            return employee.UserId;
        }
        public static Employee GetEmployee()
        {
            return employee;
        }
        public void PopulateEm()
        {
            employee = DataAccess.GetEmployee(email);
        }
        public string Schedule
        {
            get => employee.Schedule;
            set
            {
                OnPropertyChanged();
            }
        }
        public DateTime EmploymentDate
        {
            get => employee.EmploymentDate;
            set
            {
                OnPropertyChanged();
            }
        }
        public string Position
        {
            get => employee.Position;
            set
            {
                OnPropertyChanged();
            }
        }
        public string Language
        {
            get => employee.Languages;
            set
            {
                OnPropertyChanged();
            }
        }
        public string Nationality
        {
            get => employee.Nationality;
            set
            {
                OnPropertyChanged();
            }
        }
        public string CivilStatus
        {
            get => employee.CivilStatus;
            set
            {
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get => employee.Gender;
            set
            {
                OnPropertyChanged();
            }
        }
        public int Salary
        {
            get => employee.Salary;
            set
            {
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => employee.PhoneNumber;
            set
            {
                OnPropertyChanged();
            }
        }
        public string IdBatch
        {
            get => employee.IdBatch;
            set
            {
                OnPropertyChanged();
            }
        }
        public int IdNum
        {
            get => employee.IdNumber;
            set
            {
                OnPropertyChanged();
            }
        }
        public DateTime BDay
        {
            get => employee.Bday;
            set
            {
                OnPropertyChanged();
            }
        }
        public long CNP 
        { 
            get => employee.CNP; 
            set
            {
                OnPropertyChanged();
            }
        }
        public string Add
        {
            get => employee.Adress; 
            set
            {
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
        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get => employee.FirstName;
            set
            {
                OnPropertyChanged();
            }
        }
    }
}
