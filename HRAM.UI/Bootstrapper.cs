using Caliburn.Micro;
using HRAM.UI.Helpers;
using HRAM.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HRAM.UI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();

            //ConventionManager.AddElementConvention<PasswordBox>(
            //PasswordBoxHelper.BoundPasswordProperty,
            //"Password",
            //"PasswordChanged");
        }
    }
}
