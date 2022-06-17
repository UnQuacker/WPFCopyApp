using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCopyApp.ViewModels;

namespace WPFCopyApp.Stores
{
    public class NavigationStore
    {
        public ViewModelBase _CurrentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set
            {
                _CurrentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
