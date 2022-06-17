using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCopyApp.Commands;
using WPFCopyApp.Models;
using WPFCopyApp.Stores;

namespace WPFCopyApp.ViewModels
{
    public class FileReaderViewModel:ViewModelBase
    {
        private NavigationStore _navigationStore;
        private string _test = "Quack-quack";
        private FileReaderModel fileReaderModel;
        public string test
        {
            get { return _test; }
            set
            {
                _test = value;
                OnPropertyChanged(nameof(test));
            }
        }
        public string content
        {
            get { return fileReaderModel._content; }
            set
            {
                fileReaderModel._content = value;
                OnPropertyChanged(nameof(content));
            }
        }
        public ICommand NavigateCommand { get; }
        public ICommand ReadFileCommand { get; }
        public FileReaderViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            fileReaderModel = new FileReaderModel();

            NavigateCommand = new RelayCommand(obj =>
            {
                Navigate();
            }
            );
            ReadFileCommand = new RelayCommand(obj =>
            {
                ReadFile();
            }
            );
        }

        private void Navigate()
        {
            _navigationStore.CurrentViewModel = new ViewModel(_navigationStore);
        }
        private void ReadFile()
        {
            fileReaderModel.ReadText(this);
        }
    }
    
}
