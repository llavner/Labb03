using QuizQuest.Command;
using QuizQuest.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace QuizQuest.ViewModel
{
    internal class QuestionPackViewModel : ViewModelBase
    {

        private readonly QuestionPack _model;
        

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public ObservableCollection<Question> Questions { get; }

        public DelegateCommand AddQuestionPackCommand { get; }
        public DelegateCommand RemoveQuestionPackCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                RaisedPropertyChanged();
            }

        }
        public Difficulty Difficulty
        {
            get => _model.Difficulty;
            set
            {
                _model.Difficulty = value;
                RaisedPropertyChanged();
            }

        }
        public int TimeLimit
        {
            get => _model.TimeLimit;
            set
            {
                _model.TimeLimit = value;
                RaisedPropertyChanged();
            }
        }

        public QuestionPackViewModel(QuestionPack _model)
        {
            this._model = _model;
            this.Questions = new ObservableCollection<Question>(_model.Questions);

            
            
            AddQuestionPackCommand = new DelegateCommand(AddQuestionPack);

            RemoveQuestionPackCommand = new DelegateCommand(RemoveQuestionPack);

            CancelCommand = new DelegateCommand(Cancel);

            
        }

        private void AddQuestionPack(object obj) 
        {
            if (obj is Window window)
            {

                var newQuestionPack = new QuestionPackViewModel(new QuestionPack(Name, Difficulty, TimeLimit));
                
                window.Close();

            }

        }




        private void RemoveQuestionPack(object obj)
        {



        }

        private void Cancel(object obj)
        {

            if (obj is Window window)
            {

                window.Close();
            }


        }

    }
}
