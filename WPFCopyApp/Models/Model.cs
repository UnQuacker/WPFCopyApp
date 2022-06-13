using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCopyApp.Models
{
    public class Model
    {
        private string _label1 = "Label before change";
        private string _label2;
        public string label1 {
            get
            {
                return _label1;
            }
            set
            {
                _label1 = value;
            }
        }

        public string label2
        {
            get
            {
                return _label2;
            }
            set
            {
                _label2 = value;
            }
        }

        public Model()
        {
            label1 = "Label 1 before change";
            label2 = "Label 2 before change";
        }
    }
}
