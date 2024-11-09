using QuizQuest.Assets.Command;
using QuizQuest.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuest.ViewModel
{
    //Not Implemented yet.
    //ToDo Import questions from API trevia.
    class ImportQuestionViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;
        public DelegateCommand? ImportDialogCommand { get; }


        public ImportQuestionViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;


            ImportDialogCommand = new DelegateCommand(ImportDialog);

        }
            
        private void ImportDialog(object obj)
        {
            ImportPackDialog importPackDialog = new();

            var result = importPackDialog.ShowDialog();

        }
    }
}
