using QuizQuest.Command;
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

        private string _packName;
        private Difficulty _difficulty;
        private int _timeLimit;
        private int _questionsInPack;

        private string _question;
        private string _answer1;
        private string _answer2;
        private string _answer3;
        private string _answer4;
        
        //private QuestionPackViewModel _activePack;
        /*public QuestionPackViewModel ActivePack
        {
            get => mainWindowViewModel.ActivePack;

            set
            {
                _activePack = value;
                RaisedPropertyChanged();

            }
        }*/

        public string PackName
        {
            get { return _packName; }
            set { _packName = value; }
        }

        public string Question
        {
            get { return _question; }
            set
            {
                _question = value;
                RaisedPropertyChanged();
            }
        }

        public string Answer1
        {
            get { return _answer1; }
            set { _answer1 = value; }
        }

        public string Answer2
        {
            get { return _answer2; }
            set { _answer2 = value; }
        }

        public string Answer3
        {
            get { return _answer3; }
            set { _answer3 = value; }
        }

        public string Answer4
        {
            get { return _answer4; }
            set { _answer4 = value; }
        }


        public int TimeLimit
        {
            get { return _timeLimit; }
            set 
            { 
                _timeLimit = value;
                RaisedPropertyChanged();
            }
        }


        public Difficulty Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }

        //private string _currentQuestion;

        //public string CurrentQuestion
        //{
        //    get { return _currentQuestion; }
        //    set { _currentQuestion = value; }
        //}


        public int QuestionsInPack
        {
            get { return _questionsInPack; }
            set 
            { 
                _questionsInPack = value;
                RaisedPropertyChanged();
            }
        }

        int selectedQuestion = 0;
        public PlayerViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;

            
            TestMetod();
            

            // Question-Strings
            Question = mainWindowViewModel.ActivePack.Questions[selectedQuestion].Query;
            Answer1 = mainWindowViewModel.ActivePack.Questions[selectedQuestion].CorrectAnswer;
            Answer2 = mainWindowViewModel.ActivePack.Questions[selectedQuestion].IncorrectAnswers[0];
            Answer3 = mainWindowViewModel.ActivePack.Questions[selectedQuestion].IncorrectAnswers[1];
            Answer4 = mainWindowViewModel.ActivePack.Questions[selectedQuestion].IncorrectAnswers[2];


        }

        public void TestMetod()
        {


            //Packname
            PackName = mainWindowViewModel.ActivePack.Name;

            //Question-amount
            QuestionsInPack = mainWindowViewModel.ActivePack.Questions.Count;

            
            //Difficulty
            Difficulty = mainWindowViewModel.ActivePack.Difficulty;
            
            //TimeLimit = ActivePack.TimeLimit;
            TimeLimit = 5;
        }

        private void Next()
        {
            // Test för att se om den byter
            mainWindowViewModel.ActivePack = mainWindowViewModel.Packs[0];

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
            
            TimeLimit -= 1;

            if (TimeLimit < 1)
            {
                
                Debug.WriteLine("Next Question or Game Over");
                timer.Stop();

                Next();
            
            }
        }
    }
}
