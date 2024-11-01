using QuizQuest.Command;
using QuizQuest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QuizQuest.ViewModel
{
    internal class ConfigurationViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;
        public DelegateCommand AddQuestionCommand { get; }
        public DelegateCommand RemoveQuestionCommand { get; }
        public QuestionPackViewModel? ActivePack => mainWindowViewModel?.ActivePack;

        private Question? _activeQuestion;
        public Question ActiveQuestion
        {
            get { return _activeQuestion; }
            set
            {
                _activeQuestion = value;
                RaisedPropertyChanged();
                RemoveQuestionCommand.RaisedCanExecuteChanged();
            }
        }

        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;

            AddQuestionCommand = new DelegateCommand(AddQuestion);

            RemoveQuestionCommand = new DelegateCommand(RemoveQuestion, CanRemoveQuestion);
            
        }
        private void AddQuestion(object obj)
        {

            ActivePack?.Questions.Add(new Question("New Question", "", "", "", ""));

            ActiveQuestion = ActivePack.Questions.Last();
        }
        private void RemoveQuestion(object obj)
        {
            if (ActivePack?.Questions == null || ActiveQuestion == null)
            {

                return;
            }
            ActivePack?.Questions.Remove(ActiveQuestion);
            ActiveQuestion = ActivePack.Questions.FirstOrDefault();
        }
        private bool CanRemoveQuestion(object obj)
        {
            if (ActivePack?.Questions != null && ActiveQuestion != null)
                return true;
            else
                return false;
        }
    }
}
