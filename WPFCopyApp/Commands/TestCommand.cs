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

        private readonly TestViewModel testViewModel;
        public override void Execute(object parameter)
        {
            testViewModel.label1 = "Label after change";
            testViewModel.moveProgressBar();
        }

        public TestCommand(TestViewModel testViewModel)
        {
            this.testViewModel = testViewModel;
        }

    }

    
}
