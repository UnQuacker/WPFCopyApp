using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCopyApp.ViewModels;

namespace WPFCopyApp.Commands
{
    public class TestCommand : CommandBase
    {
        Action<object> execteMethod;

        public override void Execute(object parameter)
        {
            execteMethod(parameter);
        }

        public TestCommand(Action<object> execteMethod)
        {
            this.execteMethod = execteMethod;
        }

    }

    
}
