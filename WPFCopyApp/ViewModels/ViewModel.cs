using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCopyApp.Commands;
using WPFCopyApp.Models;
using WPFCopyApp.Stores;

namespace WPFCopyApp.ViewModels
{
    public class ViewModel : ViewModelBase
    {
        private  Model model;
        private int _progressbar = 0;
        private NavigationStore _navigationStore;
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

        public ICommand ChangeLabel1 { get; }
        public ICommand ChangeLabel2 { get; }
        public ICommand WriteLaggyCommand { get; }
        public ICommand WriteThreadCommand { get; }
        public ICommand WriteAsyncCommand { get; }
        public ICommand CopyCommand { get; }
        public ICommand NavigateCommand { get; }
        
        
        public ViewModel(NavigationStore navigationStore)
        {
            model = new Model();
            _navigationStore = navigationStore;
            ChangeLabel1 = new RelayCommand(obj =>
            {
                ChangeLabel("Button 1 was pressed");
            }, (obj)=> !Whichlabel
            );

            ChangeLabel2 = new RelayCommand(obj =>
            {
                ChangeLabel("Button 2 was pressed");
                //testChangeLabel("Button 2 was pressed");
            }, (obj) => Whichlabel
            );

            WriteLaggyCommand = new RelayCommand(obj =>
            {
                WriteToFileLaggy();
            }, (obj)=> !isRunning
            );

            WriteThreadCommand = new RelayCommand(obj =>
            {
                WriteThread();
            }, (obj) => !isRunning
            );

            WriteAsyncCommand = new RelayCommand(obj =>
            {
                WriteAsync();
            }, (obj) => !isRunning
            );

            CopyCommand = new RelayCommand(obj =>
            {
                Copy();
            }, (obj) => !isRunning
            );

            NavigateCommand = new RelayCommand(obj =>
            {
                Navigate();
            }, (obj) => !isRunning
            );


        }

        private void WriteToFileLaggy()
        {
            model.WriteToFileLaggy(this);
        }

        private void ChangeLabel(string newLabel)
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

        private void WriteThread()
        {
            Thread thread = new(() => model.WriteToFileThread1(this));
            thread.Start();
        }

        private void WriteAsync()
        {
            model.WritetoFileAsync(this);
        }

        private void Copy()
        {
            string source = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Thread.txt";
            string destination = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Thread3.txt";

            Thread thread = new(() => model.Copy(this));
            thread.Start();
        }

        private void Navigate()
        {
            _navigationStore.CurrentViewModel = new FileReaderViewModel(_navigationStore);
        }

    }
}
