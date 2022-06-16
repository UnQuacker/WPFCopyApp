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
                ChangeLabel("Button 1 was pressed");
            }, (obj)=> { return !Whichlabel; }
            );

            ChangeLabel2 = new RelayCommand(obj =>
            {
                ChangeLabel("Button 2 was pressed");
            }, (obj) => { return Whichlabel; }
            );

            CopyCommand = new RelayCommand(obj =>
            {
                Copy();
            }, (obj)=> { return !isRunning; });

            WirteThread = new RelayCommand(obj =>
            {
                WriteThread();
            }, (ob) => { return !isRunning; });
        }

        public void Copy()
        {
            model.LaggyCopy(this);
        }

        public void ChangeLabel(string newLabel)
        {
            if (!Whichlabel)
            {
                model.ChangeLabel(this, newLabel);
                Whichlabel = true;
            }
            else
            {
                model.ChangeLabel(this, newLabel);
                Whichlabel = false;
            }
        }

        public void WriteThread()
        {
            Thread thread = new(() => model.WriteToFileThread1(this));
            thread.Start();
        }
    }
}
