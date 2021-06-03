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

namespace HRAM.UI.ViewModels
{
    public class RequestHolidayViewModel : BindableBase
    {
        public static RequestHolidayViewModel Instance { get; } = new RequestHolidayViewModel();
        public ICommand GenerateHolidayCommand { get; }
        public RequestHolidayViewModel()
        {
            GenerateHolidayCommand = new ViewModelCommands(ButtonGenerateHoliday);
        }
        private static Holiday hol = null;
        public void ButtonGenerateHoliday()
        {
            hol = new Holiday
            {
                Type = tip,
                DateOfStart = start,
                DateOfFinish = finish,
                Reason = comm
            };
            TimeSpan diff;
            diff = hol.DateOfFinish - hol.DateOfStart;
            hol.DiffDays = diff.Days;
            HolidaysViewModel.holidaysObservableCollection.Add(hol);
            System.Windows.MessageBox.Show("Cererea de concediu a fost generata!");
        }
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
