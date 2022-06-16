using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public bool isRunning
        {
            get
            {
                return model.isRunning;
            }
            set
            {
                model.isRunning = value;
                OnPropertyChanged(nameof(isRunning));
            }

        }
        public bool Whichlabel
        {
            get
            {
                return model.Whichlabel;
            }
            set
            {
                model.Whichlabel = value;
                OnPropertyChanged(nameof(Whichlabel));
            }

        }

        public ICommand ChangeLabel1 { get; }
        public ICommand ChangeLabel2 { get; }
        public ICommand CopyCommand { get; }
        public ICommand WirteThread { get; }

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

            ChangeLabel1 = new RelayCommand(obj =>
            {
                changeLabel("Button 1 was pressed");
            }, (object param)=> { return !Whichlabel; }
            );

            ChangeLabel2 = new RelayCommand(obj =>
            {
                changeLabel("Button 2 was pressed");
            }, (object param) => { return Whichlabel; }
            );

            CopyCommand = new RelayCommand(obj =>
            {
                Copy();
            }, (object param)=> { return !isRunning; });

            WirteThread = new RelayCommand(obj =>
            {
                writeThread();
            }, (object param) => { return !isRunning; });
        }

        public void Copy()
        {
            model.LaggyCopy(this);
        }

        public void changeLabel(string newLabel)
        {
            if (!Whichlabel)
            {
                model.changeLabel(this, newLabel);
                Whichlabel = true;
            }
            else
            {
                model.changeLabel(this, newLabel);
                Whichlabel = false;
            }
        }

        public void writeThread()
        {
            Thread thread = new Thread(() => model.writeToFileThread1(this));
            thread.Start();
        }
    }
}
