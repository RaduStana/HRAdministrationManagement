using Convertor.ViewModels.Commands;
using DynamicData;
using HRAM.UI.Helpers;
using HRAM.UI.Models;
using HRAM.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HRAM.UI.ViewModels.Flux 
{
    public class HolidaysViewModel : BindableBase
    {
        public HolidaysViewModel()
        {
            RequestHolidayCommand = new ViewModelCommands(ReqHolComm);
            PopulateHoliday();
            PopulateScales();
        }
        public static List<Holiday> holidays = DataAccess.GetHolidays();
        public static ObservableCollection<Holiday> holidaysObservableCollection = new ObservableCollection<Holiday>(holidays);
        private ObservableCollection<CountHolidayScales> scaleObsColl = new ObservableCollection<CountHolidayScales>();
        public ICommand RequestHolidayCommand { get; }
        public void PopulateScales()
        {
            CountHolidayScales HolYear = new CountHolidayScales();
            CountHolidayScales TotalHol = new CountHolidayScales();
            CountHolidayScales RemainingHol = new CountHolidayScales();
            HolYear.TotalDays = 25;
            foreach(var item in holidays)
                HolYear.TakenDays += item.DiffDays;
            TotalHol.TotalDays = 45;
            TotalHol.TakenDays = 0;
            RemainingHol.TotalDays = TotalHol.TotalDays - HolYear.TotalDays;
            RemainingHol.TakenDays = 0;
            scaleObsColl.Add(HolYear);
            scaleObsColl.Add(TotalHol);
            scaleObsColl.Add(RemainingHol);
        }
        public void ReqHolComm()
        {
            var diagScriptView = new RequestHoliday();
            Window window = new Window()
            {
                Content = diagScriptView,
                Title = $"Request Holiday",
                Height = 550,
                Width = 1000
            };
            try
            {
                window.ShowDialog();
            }
            catch
            {
                System.Windows.MessageBox.Show("Request Holiday Window didn't pop-up.");
            }
        }
        public int AvailableDays(Holiday item)
        {
            TimeSpan diff;
            diff = item.DateOfFinish - item.DateOfStart;
            return diff.Days;
        }
        public void PopulateHoliday()
        {
            foreach (var item in holidays)
                item.DiffDays = AvailableDays(item);
        }
        public ObservableCollection<CountHolidayScales> ScaleObsColl
        {
            get => scaleObsColl;
            set
            {
                scaleObsColl = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Holiday> HolidaysObservableCollection
        {
            get => holidaysObservableCollection;
            set
            {
                holidaysObservableCollection = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<string> yearCombo = new ObservableCollection<string>() { "2021" };
        public ObservableCollection<string> YearCombo
        {
            get => yearCombo;
            set
            {
                yearCombo = value;
            }
        }
    }
}
