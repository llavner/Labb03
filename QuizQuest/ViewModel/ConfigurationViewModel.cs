using QuizQuest.Command;
using QuizQuest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuest.ViewModel
{
    internal class ConfigurationViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;

       /* public Question ActiveQuestion
        {
            get => ActiveQuestion;

            set
            {
                ActiveQuestion = value;
                RaisedPropertyChanged();
            }

        }*/

        public DelegateCommand AddQuestionCommand { get; }
        public DelegateCommand RemoveQuestionCommand { get; }
        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;
            
            AddQuestionCommand = new DelegateCommand(AddQuestion);
            RemoveQuestionCommand = new DelegateCommand(RemoveQuestion, CanRemoveQuestion);

            
        
            //ActivePack.Questions.Add(new Question("Hello", "A", "B", "C", "D"));
        }
            


        private void AddQuestion(object obj)
        {

            //ActivePack.Questions.Add(new Question();
            
        }

        private void RemoveQuestion(object obj)
        {


        }

        private bool CanRemoveQuestion(object obj)
        {
            if (ActivePack.Questions == null)
            {
                return false;
            }
            else
                return true;


        }



    }
}
