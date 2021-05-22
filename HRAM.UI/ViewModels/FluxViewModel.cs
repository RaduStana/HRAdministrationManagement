using Convertor.ViewModels.Commands;
using HRAM.UI.ViewModels.Commands;
using HRAM.UI.ViewModels.Flux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRAM.UI.ViewModels
{
    public class FluxViewModel : BindableBase
    {
        public object CurrentView { get; set; }
        public ICommand HolidayCommand { get; }
        public ICommand MPDCommand { get; }
        public ICommand CertificatesCommand { get; }
        public FluxViewModel()
        {
            HolidayCommand = new ViewModelCommands(HolidayComm);
            MPDCommand = new ViewModelCommands(MPDComm);
            CertificatesCommand = new ViewModelCommands(CertificatesComm);
        }
        public void HolidayComm()
        {
            CurrentView = new HolidaysViewModel();
            OnPropertyChanged("CurrentView");
        }
        public void MPDComm()
        {
            CurrentView = new ModifyPersDataViewModel();
            OnPropertyChanged("CurrentView");
        }
        public void CertificatesComm()
        {
            CurrentView = new CertificatesViewModel();
            OnPropertyChanged("CurrentView");
        }
    }
}
