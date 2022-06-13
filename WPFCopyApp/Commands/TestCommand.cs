using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCopyApp.ViewModels;

namespace WPFCopyApp.Commands
{
    class TestCommand : CommandBase
    {
        private readonly string label1;
        private readonly TestViewModel testViewModel;
        public override void Execute(object parameter)
        {
            testViewModel.label1 = "Label after change";
        }

        public TestCommand(TestViewModel testViewModel, string label1)
        {
            this.label1 = label1;
            this.testViewModel = testViewModel;
        }
    }

    
}
