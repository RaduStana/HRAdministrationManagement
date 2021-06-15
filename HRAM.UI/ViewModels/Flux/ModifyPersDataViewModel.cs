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

namespace HRAM.UI.ViewModels.Flux
{
    public class ModifyPersDataViewModel : BindableBase{
        public static ModifyPersDataViewModel Instance { get; } = new ModifyPersDataViewModel();
        public ICommand SubmitUpdateCommand { get; }
        public ModifyPersDataViewModel(){
            SubmitUpdateCommand = new ViewModelCommands(ButtonSubmitUpdateCommand);
        }
        public void ButtonSubmitUpdateCommand() {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=HRAMDATA; Integrated Security=True;");
            int userId = ProfileViewModel.GetEmployeeUserId();
            try {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = "UPDATE dbo.[User] SET FirstName = '"+firstName+ "', LastName = '"+lastName+"', Adress = '"+address+"', PhoneNumber = '"+phoneNumber+"' WHERE UserId = '"+userId+"' ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Updates have been made!", "Updated" , MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex){
                MessageBox.Show(ex.Message);
            }
            finally{
                sqlCon.Close();
            }
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
        private string address;
        public string Address
        {
            get => address;
            set
            {
                if (address != value)
                    address = value;
                OnPropertyChanged();
            }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (phoneNumber != value)
                    phoneNumber = value;
                OnPropertyChanged();
            }
        }
    }
}
