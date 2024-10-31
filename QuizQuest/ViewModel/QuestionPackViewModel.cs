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

        public DelegateCommand? AddQuestionPackCommand { get; } //Move to DialogViewModel?*
        public DelegateCommand? RemoveQuestionPackCommand { get; } //Move to DialogViewModel?*
        public DelegateCommand? CancelCommand { get; } //Move to DialogViewModel?*
        public QuestionPack? pack { get; }


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

        public QuestionPackViewModel(QuestionPack model)
        {
            this._model = model;
            this.Questions = new ObservableCollection<Question>(model.Questions);

            AddQuestionPackCommand = new DelegateCommand(AddQuestionPack);

            //RemoveQuestionPackCommand = new DelegateCommand(RemoveQuestionPack);

            CancelCommand = new DelegateCommand(Cancel);

            var packTest = new QuestionPack(Name, Difficulty, TimeLimit);
        }

        private void AddQuestionPack(object obj)
        {
            
            var pack = new QuestionPack(Name, Difficulty, TimeLimit);

            

            if (obj is Window window)
            {

                window.Close();

            }
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
