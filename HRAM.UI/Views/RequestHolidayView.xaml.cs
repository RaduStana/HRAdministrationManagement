using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRAM.UI.Views
{
    /// <summary>
    /// Interaction logic for RequestHoliday.xaml
    /// </summary>
    public partial class RequestHoliday : UserControl
    {
        public RequestHoliday()
        {
            InitializeComponent();
        }
        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
