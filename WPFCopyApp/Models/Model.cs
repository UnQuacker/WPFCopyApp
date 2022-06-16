using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCopyApp.ViewModels;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Input;

namespace WPFCopyApp.Models
{
    public class Model
    {
        public string label="Label before the change";

        public bool isRunning = false;
        public bool Whichlabel = false;
        public Model()
        {
        }

        public void changeLabel(ViewModel ViewModel, string newLabel)
        {
            isRunning = true;
            ViewModel.label = newLabel;
            isRunning = false;
        }

        public void LaggyCopy(ViewModel testViewModel)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Thread.txt";
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    isRunning = true;
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

            isRunning = false;

        }
        public void writeToFileThread1(ViewModel testViewModel)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Thread1.txt";
            try
            {
                testViewModel.isRunning = true;
                using (StreamWriter sw = File.AppendText(path))
                {
                    testViewModel.progressbar = 0;
                    for (int i = 0; i < 100; i++)
                    {
                        sw.WriteLine(i.ToString());
                        if (testViewModel.progressbar != 100) {
                            testViewModel.progressbar++;
                        }

                        Thread.Sleep(50);
                    }
                }

            }
            catch (Exception e)
            {

            }
            testViewModel.isRunning = false;
        }
    }
}
