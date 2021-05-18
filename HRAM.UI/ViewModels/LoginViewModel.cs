using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set {
                if (password != value)
                    password = value;
                OnPropertyChanged();
            }
        }

        public bool LoginCheck
        {
            get
            {
                bool output = false;
                if (emailAddress?.Length > 0 && password?.Length > 0)
                    return true;

                return output;
            }
        }

        public void Login()
        {
            Console.WriteLine("LOGIN");
        }

    }
}
