using QuizQuest.Assets.Command;
using QuizQuest.Views;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace QuizQuest.ViewModel
{
    internal class PlayerViewModel : ViewModelBase
    {

        private readonly MainWindowViewModel? mainWindowViewModel;
        private readonly PlayerView? playerView;
        private DispatcherTimer timer;
        private string _activeQuestion;
        private string _answer1;
        private string _answer2;
        private string _answer3;
        private string _answer4;
        private int _currentIndex;
        private int _questionsInPack;
        private int _timeLimit;
        private int counterStartIndex;
        private int _playerScore = 0;
        private bool _isCorrect;
        private Brush button1BackgroundColor = Brushes.Transparent;
        private Brush button2BackgroundColor = Brushes.Transparent;
        private Brush button3BackgroundColor = Brushes.Transparent;
        private Brush button4BackgroundColor = Brushes.Transparent;

        private List<string> Answers = new List<string>();

        public int CurrentIndex
        {
            get { return _currentIndex; }
            private set
            {
                _currentIndex = value;
                RaisedPropertyChanged();
            }
        }
        public int QuestionsInPack

        {
            get { return _questionsInPack; }
            set
            {
                _questionsInPack = value;
                RaisedPropertyChanged();
            }
        }
        public string ActiveQuestion
        {
            get { return _activeQuestion; }
            set
            {
                _activeQuestion = value;
                RaisedPropertyChanged();
            }
        }
        public string Answer1
        {
            get { return _answer1; }
            set
            {
                _answer1 = value;
                RaisedPropertyChanged();
            }
        }
        public string Answer2
        {
            get { return _answer2; }
            set
            {
                _answer2 = value;
                RaisedPropertyChanged();
            }
        }
        public string Answer3
        {
            get { return _answer3; }
            set
            {
                _answer3 = value;
                RaisedPropertyChanged();
            }
        }
        public string Answer4
        {
            get { return _answer4; }
            set
            {
                _answer4 = value;
                RaisedPropertyChanged();
            }
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
        public int CounterStartIndex
        {
            get => counterStartIndex;
            set
            {
                counterStartIndex = value;
                RaisedPropertyChanged();
            }
        }
        public int PlayerScore
        {
            get { return _playerScore; }
            set
            {
                _playerScore = value;
                RaisedPropertyChanged();
            }
        }

        public DelegateCommand ClickCommand { get; }
        public DelegateCommand RetryQuizCommand { get; }
        public PlayerViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;

            QuestionsInPack = mainWindowViewModel.ActivePack.Questions.Count;

            ClickCommand = new DelegateCommand(Click);
            RetryQuizCommand = new DelegateCommand(RetryQuiz);

            playerView = new PlayerView();

        }

        public Brush Button1BackgroundColor
        {
            get => button1BackgroundColor;
            set
            {
                button1BackgroundColor = value;
                RaisedPropertyChanged();
            }
        }
        public Brush Button2BackgroundColor { get => button2BackgroundColor; set => button2BackgroundColor = value; }
        public Brush Button3BackgroundColor { get => button3BackgroundColor; set => button3BackgroundColor = value; }
        public Brush Button4BackgroundColor { get => button4BackgroundColor; set => button4BackgroundColor = value; }

        public void ResetButtonColors()
        {

            Button1BackgroundColor = Brushes.Transparent;
            Button2BackgroundColor = Brushes.Transparent;
            Button3BackgroundColor = Brushes.Transparent;
            Button4BackgroundColor = Brushes.Transparent;

            RaisedPropertyChanged(nameof(Button1BackgroundColor));
            RaisedPropertyChanged(nameof(Button2BackgroundColor));
            RaisedPropertyChanged(nameof(Button3BackgroundColor));
            RaisedPropertyChanged(nameof(Button4BackgroundColor));

        }
        public void ButtonPropertyChanged()
        {
            RaisedPropertyChanged(nameof(Button1BackgroundColor));
            RaisedPropertyChanged(nameof(Button2BackgroundColor));
            RaisedPropertyChanged(nameof(Button3BackgroundColor));
            RaisedPropertyChanged(nameof(Button4BackgroundColor));

        }
        public void SetButtonColor(string answer, Brush color)
        {
            if (answer == Answer1)
            {
                Button1BackgroundColor = color;
            }
            else if (answer == Answer2)
            {
                Button2BackgroundColor = color;
            }
            else if (answer == Answer3)
            {
                Button3BackgroundColor = color;
            }
            else if (answer == Answer4)
            {
                Button4BackgroundColor = color;
            }


        }

        private async Task ShowAnswer(string selected, string correct)
        {
            await Task.Run(()=> CheckAnswer(selected, correct));

        }

        private void CheckAnswer(string selected, string correct)
        {

            if (selected == correct)
            {
                PlayerScore++;
                SetButtonColor(selected, Brushes.LightGreen);
                ButtonPropertyChanged();
                

            }
            else
            {
                SetButtonColor(selected, Brushes.Red);
                SetButtonColor(correct, Brushes.Goldenrod);
                ButtonPropertyChanged();
                

            }
        }
        private async void Click(object obj)
        {

            string? correctAnswer = mainWindowViewModel.ActivePack.Questions[CurrentIndex].CorrectAnswer;
            string? selectedAnswer = obj.ToString();

            await ShowAnswer(selectedAnswer, correctAnswer);

            await Task.Delay(1000);


            if (CurrentIndex == QuestionsInPack - 1)
            {
                GameOver();
            }
            else
            {
                ResetTimer();
                CurrentIndex++;
                CounterStartIndex++;
                NextQuestion();
            }

            ResetButtonColors();


        }

        public void RetryQuiz(object obj)
        {
            RaisedPropertyChanged();
            StartQuiz();

        }
        public void StartQuiz()
        {
            TimeLimit = mainWindowViewModel.ActivePack.TimeLimit;
            Answers.Clear();
            ResetTimer();
            PlayerScore = 0;
            CurrentIndex = 0;

            mainWindowViewModel.PlayVisibility = Visibility.Visible;
            mainWindowViewModel.EditVisibility = Visibility.Collapsed;
            mainWindowViewModel.GameOverVisibility = Visibility.Collapsed;

            mainWindowViewModel.MenubarViewModel.ShowPlayCommand.RaisedCanExecuteChanged();
            mainWindowViewModel.MenubarViewModel.ShowEditCommand.RaisedCanExecuteChanged();

            CounterStartIndex = CurrentIndex + 1;
            QuestionsInPack = mainWindowViewModel.ActivePack.Questions.Count;

            Answers.Add(mainWindowViewModel.ActivePack.Questions[CurrentIndex].CorrectAnswer);
            Answers.Add(mainWindowViewModel.ActivePack.Questions[CurrentIndex].IncorrectAnswers[0]);
            Answers.Add(mainWindowViewModel.ActivePack.Questions[CurrentIndex].IncorrectAnswers[1]);
            Answers.Add(mainWindowViewModel.ActivePack.Questions[CurrentIndex].IncorrectAnswers[2]);

            NextQuestion();
        }


        private void NextQuestion()
        {
            Answers.Clear();
            TimeLimit = mainWindowViewModel.ActivePack.TimeLimit;

            ActiveQuestion = mainWindowViewModel.ActivePack.Questions[CurrentIndex].Query;

            Answers.Add(mainWindowViewModel.ActivePack.Questions[CurrentIndex].CorrectAnswer);
            Answers.Add(mainWindowViewModel.ActivePack.Questions[CurrentIndex].IncorrectAnswers[0]);
            Answers.Add(mainWindowViewModel.ActivePack.Questions[CurrentIndex].IncorrectAnswers[1]);
            Answers.Add(mainWindowViewModel.ActivePack.Questions[CurrentIndex].IncorrectAnswers[2]);



            Random random = new Random();

            var randomizedAnswers = Answers
                .AsParallel()
                .OrderBy(x => random.Next())
                .ToList();

            if (CurrentIndex <= QuestionsInPack - 1)
            {
                Answer1 = randomizedAnswers[0];
                Answer2 = randomizedAnswers[1];
                Answer3 = randomizedAnswers[2];
                Answer4 = randomizedAnswers[3];
                Timer();
            }
            else
            {
                ResetTimer();
                GameOver();
            }


        }

        private void GameOver()
        {
            
            mainWindowViewModel.PlayVisibility = Visibility.Collapsed;
            mainWindowViewModel.EditVisibility = Visibility.Collapsed;
            mainWindowViewModel.GameOverVisibility = Visibility.Visible;

            ResetTimer();
            
        }

        private void Timer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        public void ResetTimer()
        {
            if (timer != null)
            {
                timer.Stop();
                timer = null;

            }

        }


        private void Timer_Tick(object? sender, EventArgs e)
        {

            TimeLimit -= 1;

            if (TimeLimit < 0)
            {

                timer.Stop();
                ResetTimer();
                if (CurrentIndex >= QuestionsInPack - 1) // Gör en metod av
                {
                    GameOver();

                }
                else
                {
                    CurrentIndex++;
                    CounterStartIndex++;
                    Thread.Sleep(1000);
                    NextQuestion();
                }


            }


        }


    }
}
