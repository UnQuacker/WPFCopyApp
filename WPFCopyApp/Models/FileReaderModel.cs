using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCopyApp.ViewModels;
using System.Runtime.InteropServices;

namespace WPFCopyApp.Models
{
    public class FileReaderModel
    {
        public string _content;
        public StringBuilder temp;

        [DllImport("RawDataDLL.dll")]
        public static extern IntPtr Create();

        [DllImport("RawDataDLL.dll")]
        public static extern void RunTest(IntPtr dll, StringBuilder stringBuilder, int sector);

        public FileReaderModel()
        {
        }

        public void ReadText(FileReaderViewModel fileReaderViewModel)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "txt files (*.txt)|*.txt";
            //if (openFileDialog.ShowDialog() != true) { return; }
            //fileReaderViewModel.test = openFileDialog.FileName;
            //fileReaderViewModel.content = File.ReadAllText(openFileDialog.FileName);

            temp = new StringBuilder();

            fileReaderViewModel.test = "Opened with dll";
            IntPtr dll = Create();
            RunTest(dll, temp, 118);
            fileReaderViewModel.content = temp.ToString();
        }

    }
}
