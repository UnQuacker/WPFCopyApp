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
using System.Runtime.CompilerServices;

namespace WPFCopyApp.Models
{
    public class Model: INotifyPropertyChanged
    {
        private string _label="Label before the change";
        public string label
        {
            get { return _label; }
            set 
            {
                _label = value;
                OnPropertyChanged(nameof(label));
            }
        }

        public bool isRunning = false;
        public bool Whichlabel = false;
        public int progressbar;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Model()
        {
        }

        public void ChangeLabel(ViewModel ViewModel, string newLabel)
        {
            ViewModel.label = newLabel;
        }
        //public void testLabelChange(string newLabel)
        //{
        //    label = newLabel;
        //}

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

            catch (Exception)
            {

            }

            isRunning = false;
            OnPropertyChanged(nameof(testViewModel.isRunning));

        }
        public void WriteToFileThread1(ViewModel testViewModel)
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
            catch (Exception)
            {

            }
            testViewModel.isRunning = false;
            OnPropertyChanged(nameof(testViewModel.isRunning));
        }
        async public void WritetoFileAsync(ViewModel testViewModel)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Thread2.txt";
            await Task.Run(() =>
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        testViewModel.isRunning = true;
                        testViewModel.progressbar = 0;
                        for (int i = 0; i < 40000000; i++)
                        {
                            sw.WriteLine(i.ToString());
                            if (i % 400000 == 0)
                            {
                                testViewModel.progressbar++;
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
                testViewModel.isRunning = false;
                OnPropertyChanged(nameof(testViewModel.isRunning));
            });

        }
    }
}
