using QuizQuest.Assets.Command;
using QuizQuest.Model;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace QuizQuest.ViewModel
{
    internal class PlayerViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;

        private DispatcherTimer timer;


        private string _currentQuestion;

        public string CurrentQuestion
        {
            get { return _currentQuestion; }
            private set { _currentQuestion = value; }
        }


        private int _questionsInPack;
        public int QuestionsInPack
        {
            get { return _questionsInPack; }
            set 
            { 
                _questionsInPack = value;
                RaisedPropertyChanged();
            }
        }


        int selectedQuestion;

        public PlayerViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;

            QuestionsInPack = mainWindowViewModel.ActivePack.Questions.Count;

            



        }

        public static void Play()
        {
            
            



        }
        private void Randomize(string a1, string a2, string a3, string a4)
        {


        }

        
        public void Timer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {

            mainWindowViewModel.ActivePack.TimeLimit -= 1;

            if (mainWindowViewModel.ActivePack.TimeLimit < 1)
            {
                
                Debug.WriteLine("Next Question or Game Over");
                timer.Stop();
            }
        }
    }
}
