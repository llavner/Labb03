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

        //public QuestionPackViewModel? ActivePack => mainWindowViewModel?.ActivePack; //Exists in Configurationview Model

        private DispatcherTimer timer;

        private QuestionPackViewModel _activePack;

        /*public QuestionPackViewModel ActivePack
        {
            get => mainWindowViewModel.ActivePack;

            set
            {
                _activePack = value;
                RaisedPropertyChanged();

            }
        }*/

        private string _packName;
        public string PackName
        {
            get { return _packName; }
            set { _packName = value; }
        }

        private string _question;
        public string Question
        {
            get { return _question; }
            set
            {
                _question = value;
                RaisedPropertyChanged();
            }
        }

        private string _answer1;
        public string Answer1
        {
            get { return _answer1; }
            set { _answer1 = value; }
        }

        private string _answer2;
        public string Answer2
        {
            get { return _answer2; }
            set { _answer2 = value; }
        }

        private string _answer3;
        public string Answer3
        {
            get { return _answer3; }
            set { _answer3 = value; }
        }

        private string _answer4;
        public string Answer4
        {
            get { return _answer4; }
            set { _answer4 = value; }
        }

        private int _timeLimit;

        public int TimeLimit
        {
            get { return _timeLimit; }
            set 
            { 
                _timeLimit = value;
                RaisedPropertyChanged();
            }
        }

        private Difficulty _difficulty;

        public Difficulty Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }

        private string _currentQuestion;

        public string CurrentQuestion
        {
            get { return _currentQuestion; }
            set { _currentQuestion = value; }
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

        int selectedQuestion = 0;
        public PlayerViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;

            
            newmetod();
            ////Packname
            PackName = mainWindowViewModel.ActivePack.Name;  // denna 

            ////Question-amount
            //QuestionsInPack = ActivePack.Questions.Count;

            ////Difficulty
            //Difficulty = ActivePack.Difficulty;

            //// Timer - Startar när appen startar!
            //TimeLimit = ActivePack.TimeLimit;

            // Question-Strings
            Question = mainWindowViewModel.ActivePack.Questions[selectedQuestion].Query;
            //Answer1 = ActivePack.Questions[selectedQuestion].CorrectAnswer;
            //Answer2 = ActivePack.Questions[selectedQuestion].IncorrectAnswers[0];
            //Answer3 = ActivePack.Questions[selectedQuestion].IncorrectAnswers[1];
            //Answer4 = ActivePack.Questions[selectedQuestion].IncorrectAnswers[2];


        }

        public void newmetod()
        {


            //Packname
            PackName = mainWindowViewModel.ActivePack.Name;  // denna 

            //Question-amount
            QuestionsInPack = mainWindowViewModel.ActivePack.Questions.Count;

            //Difficulty
            Difficulty = mainWindowViewModel.ActivePack.Difficulty;
            // Timer - Startar när appen startar!
            //TimeLimit = ActivePack.TimeLimit;
            TimeLimit = 5;
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
                mainWindowViewModel.ActivePack = mainWindowViewModel.Packs[0];

                Debug.WriteLine("Next Question or Game Over");
                timer.Stop();
            
            }
        }
    }
}
