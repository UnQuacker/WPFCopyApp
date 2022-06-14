using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCopyApp.ViewModels;

namespace WPFCopyApp.Models
{
    public class Model
    {
        public string label="Label before change";

        public Model()
        {
        }

        public void changeLabel(TestViewModel testViewModel, string newLabel)
        {
            testViewModel.label1 = newLabel;
        }

        public void Copy(TestViewModel testViewModel)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Thread1.txt";
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    testViewModel.progressbar = 0;
                    for (int i = 0; i < 10000000; i++)
                    {
                        sw.WriteLine(i.ToString());
                        if (i % 100000 == 0 || testViewModel.progressbar != 100)
                        {
                            if (testViewModel.progressbar != 100)
                            {
                                testViewModel.progressbar++;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }


        }
    }
}
