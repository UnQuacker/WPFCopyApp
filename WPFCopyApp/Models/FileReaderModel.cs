using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCopyApp.ViewModels;

namespace WPFCopyApp.Models
{
    public class FileReaderModel
    {
        public string _content;

        public FileReaderModel()
        {
        }

        public void ReadText(FileReaderViewModel fileReaderViewModel)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() != true) { return; }

            fileReaderViewModel.content = File.ReadAllText(openFileDialog.FileName);

        }
    }
}
