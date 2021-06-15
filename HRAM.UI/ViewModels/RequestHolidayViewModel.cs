using Convertor.ViewModels.Commands;
using HRAM.UI.Models;
using HRAM.UI.ViewModels.Flux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

    namespace HRAM.UI.ViewModels
{
    public class RequestHolidayViewModel : BindableBase
    {
        public ICommand GenerateHolidayCommand { get; }
        public RequestHolidayViewModel()
        {
            GenerateHolidayCommand = new ViewModelCommands(ButtonGenerateHolidayComm);
        }
        public void InsertObjIntoDb(Holiday hol){
            HolidaysViewModel.holidaysObservableCollection.Add(hol);
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=HRAMDATA; Integrated Security=True;");
            try{
                string q = "INSERT INTO Holiday (DateOfStart, DateOfFinish, Type, Reason, UserId, State) VALUES (@DateOfStart, @DateOfFinish, @Type, @Reason, @UserId, @State)";
                SqlCommand sqlCommand = new SqlCommand(q, sqlCon);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@DateOfStart", hol.DateOfStart.Date);
                sqlCommand.Parameters.AddWithValue("@DateOfFinish", hol.DateOfFinish.Date);
                sqlCommand.Parameters.AddWithValue("@Type", hol.Type);
                sqlCommand.Parameters.AddWithValue("@Reason", hol.Reason);
                sqlCommand.Parameters.AddWithValue("@UserId", ProfileViewModel.GetEmployeeUserId());
                sqlCommand.Parameters.AddWithValue("@State", "neaprobat");
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex){
                MessageBox.Show(ex.Message);
            }
            finally{
                sqlCon.Close();
            }
        }
        public void ButtonGenerateHolidayComm() {
            Holiday hol = new Holiday{
                Type = tip,
                DateOfStart = start,
                DateOfFinish = finish,
                Reason = comm,
                State = "neaprobat"
            };
            TimeSpan diff;
            diff = hol.DateOfFinish - hol.DateOfStart;
            hol.DiffDays = diff.Days;
            InsertObjIntoDb(hol);
            MessageBox.Show("Cererea de concediu a fost generata!");
        }
        public static RequestHolidayViewModel Instance { get; } = new RequestHolidayViewModel();
        private string comm;
        public string Comm
        {
            get => comm;
            set
            {
                if (comm != value)
                    comm = value;
                OnPropertyChanged();
            }
        }
        private string tip;
        public string Tip 
        {
            get=>tip; 
            set
            {
                if (tip != value)
                    tip = value;
                OnPropertyChanged();
            }
        }
        private DateTime start = DateTime.Now;
        public DateTime Start 
        { 
            get => start;
            set
            {
                if (start != value)
                    start = value;
                OnPropertyChanged();
            } 
        }
        private DateTime finish = DateTime.Now;
        public DateTime Finish 
        { 
            get=>finish; 
            set
            {
                if (finish != value)
                    finish = value;
                OnPropertyChanged();
            }
        }
        private string inlocuitor;
        public string Inlocuitor
        {
            get => inlocuitor;
            set
            {
                if (inlocuitor != value)
                    inlocuitor = value;
                OnPropertyChanged();
            }
        }
    }
}
