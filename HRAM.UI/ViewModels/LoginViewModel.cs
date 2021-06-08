using Caliburn.Micro;
using Convertor.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HRAM.UI.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set {
                if (emailAddress != value)
                    emailAddress = value;
                
                //NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        private string password; 
        public string Password
        {
            get { return password; }
            set {
                if (password != value)
                    password = value;
                //NotifyOfPropertyChange(() => CanLogIn);
            }
        }
        /*public bool CanLogIn
        {
            get
            {
                bool output = false;

                if (EmailAddress?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public void LogIn(string email, string password)
        {
            Console.WriteLine();
        }*/
    }
}
