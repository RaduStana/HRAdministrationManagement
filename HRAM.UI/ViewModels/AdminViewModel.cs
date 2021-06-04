using Convertor.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HRAM.UI.ViewModels.Admin;

namespace HRAM.UI.ViewModels
{
    public class AdminViewModel : BindableBase
    {
        public object CurrentView { get; set; }
        public ICommand OverviewCommand { get; }
        public ICommand ReportsCommand { get; }
        public ICommand HolidayCheckCommand { get; }
        public AdminViewModel()
        {
            OverviewCommand = new ViewModelCommands(OverviewComm);
            ReportsCommand = new ViewModelCommands(ReportsComm);
            HolidayCheckCommand = new ViewModelCommands(HolidayCheckComm);
        }
        public void OverviewComm()
        {
            CurrentView = new OverviewViewModel();
            OnPropertyChanged("CurrentView");
        }
        public void ReportsComm()
        {
            CurrentView = new ReportsViewModel();
            OnPropertyChanged("CurrentView");
        }
        public void HolidayCheckComm()
        {
            CurrentView = new HolidayCheckViewModel();
            OnPropertyChanged("CurrentView");
        }
    }
}
