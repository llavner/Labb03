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
        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }

        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;
            
            //AddQuestionCommand = new DelegateCommand(AddQuestion, CanAddQuestion); Exempel
        

        }


    }
}
