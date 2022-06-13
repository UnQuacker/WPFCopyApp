using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCopyApp.Commands;

namespace WPFCopyApp.ViewModels
{
    class TestViewModel:ViewModelBase
    {
        private string _label1 = "Label before change";

        public string label1
        {
            get
            {
                return _label1;
            }
            set
            {
                _label1 = value;
                OnPropertyChanged(nameof(label1));
            }
        }
        public ICommand TestCommand { get; }

        public TestViewModel()
        {
            TestCommand = new TestCommand(this, label1);
        }
    }
}
