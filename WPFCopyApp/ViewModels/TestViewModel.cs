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
    public class TestViewModel:ViewModelBase
    {
        private  Model model;
        private int _progressbar = 0;
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

        public void moveProgressBar()
        {
            model.Copy(this);
        }
        public string label1
        {
            get
            {
                return model.label;
            }
            set
            {
                model.label = value;
                OnPropertyChanged(nameof(label1));
            }
        }
        public ICommand TestCommand { get; }

        public TestViewModel()
        {
            model = new Model();
            TestCommand = new TestCommand(this);
        }
    }
}
