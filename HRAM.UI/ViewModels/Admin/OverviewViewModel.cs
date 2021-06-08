using Convertor.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRAM.UI.ViewModels.Admin
{
    public class OverviewViewModel : BindableBase
    {
        public static RequestHolidayViewModel Instance { get; } = new RequestHolidayViewModel();
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand InsertCommand { get; }
        public OverviewViewModel()
        {
            UpdateCommand = new ViewModelCommands(UpdateComm);
            DeleteCommand = new ViewModelCommands(DeleteComm);
            InsertCommand = new ViewModelCommands(InsertComm);
        }
        public void UpdateComm()
        {

        }
        public void DeleteComm()
        {

        }
        public void InsertComm()
        {

        }
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                    firstName = value;
                OnPropertyChanged();
            }
        }
        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                    lastName = value;
                OnPropertyChanged();
            }
        }
        private string email;
        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                    email = value;
                OnPropertyChanged();
            }
        }
        private string password;
        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                    password = value;
                OnPropertyChanged();
            }
        }
    }
}
