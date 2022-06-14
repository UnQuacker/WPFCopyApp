using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCopyApp.Commands;
using WPFCopyApp.Models;

namespace WPFCopyApp.ViewModels
{
    public class ViewModel : ViewModelBase
    {
        private  Model model;
        private int _progressbar = 0;
        public ICommand ChangeLabel { get; }
        public ICommand CopyCommand { get; }

        public int progressbar
        {
            get 
            {
                return _progressbar;
            }
            set
            {   
                if (_progressbar != value)
                {
                    _progressbar = value;
                }
                OnPropertyChanged(nameof(progressbar));
            }
        }

        public string label
        {
            get
            {
                return model.label;
            }
            set
            {
                model.label = value;
                OnPropertyChanged(nameof(label));
            }
        }
        
        public ViewModel()
        {
            model = new Model();
            ChangeLabel = new TestCommand(this, obj =>
            {
                changeLabel("Label after the change");
            });
            CopyCommand = new TestCommand(this, obj =>
            {
                Copy();
            });
        }

        public void Copy()
        {
            model.Copy(this);
        }

        public void changeLabel(string newLabel)
        {
            model.changeLabel(this, newLabel);
        }
    }
}
