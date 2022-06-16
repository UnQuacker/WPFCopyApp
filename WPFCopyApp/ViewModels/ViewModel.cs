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
        
        
        public ViewModel()
        {
            model = new Model();
            //model.PropertyChanged += myModel_PropertyChanged; 
            // ломает функционал кнопок Change Label

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
        }

        public void WriteToFileLaggy()
        {
            model.WriteToFileLaggy(this);
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
        //public void testChangeLabel(string newLabel)
        //{
        //    if (!Whichlabel)
        //    {
        //        model.testLabelChange(newLabel);
        //        Whichlabel = true;
        //    }
        //    else
        //    {
        //        model.testLabelChange(newLabel);
        //        Whichlabel = false;
        //    }
        //}

        public void WriteThread()
        {
            Thread thread = new(() => model.WriteToFileThread1(this));
            thread.Start();
        }

        public void WriteAsync()
        {
            model.WritetoFileAsync(this);
        }

        public void Copy()
        {
            string source = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Thread.txt";
            string destination = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Thread3.txt";

            Thread thread = new(() => model.Copy(this));
            thread.Start();
        }

        //private void myModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == "label")
        //    {
        //        ChangeLabel2.CanExecuteChanged += ChangeLabel2_CanExecuteChanged;
        //    }
        //    else if (e.PropertyName == "progressbar")
        //    {
        //        progressbar = model.progressbar;
        //    }
        //}

        //private void ChangeLabel2_CanExecuteChanged(object sender, EventArgs e)
        //{
        //    if(e.ToString() == "label")
        //    {

        //    }
        //}
    }
}
