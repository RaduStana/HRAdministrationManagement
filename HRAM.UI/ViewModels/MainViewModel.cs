using Convertor.ViewModels.Commands;
using HRAM.UI.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRAM.UI.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public ICommand LoginCommand { get; }
        public ICommand AdminCommand { get; }
        public object CurrentView { get; set; }
        public static MainViewModel Instance { get; } = new MainViewModel();
        public ICommand ListSelectionChangedCommand { get; set; }
        public MainViewModel()
        {
            CurrentView = new HomeViewModel();
            LoginCommand = new ViewModelCommands(LoginComm);
            AdminCommand = new ViewModelCommands(AdminComm);
            ListSelectionChangedCommand = new DelegateCommand(Comm);
        }
        private void Comm(object args)
        {
            SelectionChangedEventArgs a = (SelectionChangedEventArgs)args;
            ListViewItem listViewItem = (ListViewItem)a.AddedItems[0];  
            if("Dashboard".Equals(listViewItem.Name))
                CurrentView = new HomeViewModel();
            else if ("Profile".Equals(listViewItem.Name))
                CurrentView = new ProfileViewModel();
            else
                CurrentView = new FluxViewModel();
            OnPropertyChanged("CurrentView");
        }
        public void AdminComm()
        {
            CurrentView = new AdminViewModel();
            OnPropertyChanged("CurrentView");
        }
        public void LoginComm()
        {
            CurrentView = new LoginViewModel();
            OnPropertyChanged("CurrentView");
        }
    }
}
