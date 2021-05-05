using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace HRAM.UI.ViewModels
{
    public class BaseViewModel : ReactiveObject, IDisposable
    {
        protected CompositeDisposable Disposables;

        public BaseViewModel()
        {
            Disposables = new CompositeDisposable();
        }

        public void Dispose()
        {
            Disposables.Dispose();
        }
    }
}
