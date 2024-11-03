using QuizQuest.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace QuizQuest.ViewModel
{
    internal class PlayerViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;

        private DispatcherTimer timer;

        private string _testData = "<";

        public string TestData
        {
            get => _testData;
            private set
            {
                _testData = value;
                RaisedPropertyChanged();
            }
        }

        public DelegateCommand UpdateButtonCommand { get; } // 1

        public PlayerViewModel(MainWindowViewModel mainWindowViewModel) 
        {
            this.mainWindowViewModel = mainWindowViewModel;

            TestData = "start value";
            timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateButtonCommand = new DelegateCommand(UpdateButton); // 3
            

        }

        private void UpdateButton(object obj) //2
        {
            TestData += "<";
            Application.Current.Shutdown();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            TestData += "<";
        }
    }
}
