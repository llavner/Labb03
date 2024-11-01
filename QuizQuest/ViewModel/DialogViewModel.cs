using QuizQuest.Command;
using System.Windows;
using QuizQuest.Dialogs;

namespace QuizQuest.ViewModel
{
    class DialogViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;
        public DelegateCommand? NewPackDialogCommand { get; }
        public DelegateCommand? ImportDialogCommand { get; }
        public DelegateCommand? AddDialogCommand { get; }
        public DelegateCommand? CancelDialogCommand { get; }
        public DelegateCommand? OptionDialogCommand { get; }

        public DialogViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;

            NewPackDialogCommand = new DelegateCommand(NewPackDialog);
            ImportDialogCommand = new DelegateCommand(ImportDialog);
            OptionDialogCommand = new DelegateCommand(OptionDialog);
            CancelDialogCommand = new DelegateCommand(CancelDialog);
            AddDialogCommand = new DelegateCommand(AddDialog);
        }

        private void NewPackDialog(object obj)
        {
            CreateNewPackDialog createNewPackDialog = new();

            var result = createNewPackDialog.ShowDialog();
        }
        private void OptionDialog(object obj)
        {
            PackOptionDialog packOptionDialog = new();

            var result = packOptionDialog.ShowDialog();
        }
        private void ImportDialog(object obj)
        {
            ImportPackDialog importPackDialog = new();

            var result = importPackDialog.ShowDialog();

        }
        private void AddDialog(object obj)
        {

            //var newPack = mainWindowViewModel.ActivePack;

            var newPack = new QuestionPackViewModel(new Model.QuestionPack(name:"New Pack", difficulty:Model.Difficulty.Medium, timeLimit: 30));
            
            
            if (obj is Window window)

                window.Close();
        }
        private void CancelDialog(object obj)
        {
            if (obj is Window window)

                window.Close();
        }



    }
}
