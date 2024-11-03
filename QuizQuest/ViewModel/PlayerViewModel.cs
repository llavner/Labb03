using QuizQuest.Command;
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

        public DelegateCommand UpdateButtonCommand { get; }

        public PlayerViewModel(MainWindowViewModel mainWindowViewModel) 
        {
            this.mainWindowViewModel = mainWindowViewModel;

            TestData = "start value";
            timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateButtonCommand = new DelegateCommand(UpdateButton);
            

        }

        private void UpdateButton(object obj)
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
