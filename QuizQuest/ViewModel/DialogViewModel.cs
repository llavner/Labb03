using QuizQuest.Command;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizQuest.Dialogs;

namespace QuizQuest.ViewModel
{
    class DialogViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;

        public DelegateCommand? AddPackDialogCommand { get; }
        public DelegateCommand? RemovePackDialogCommand { get; }
        public DelegateCommand? CancelDialogCommand { get; }

        public DelegateCommand OptionDialogCommand { get; }

        public DialogViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;

            AddPackDialogCommand = new DelegateCommand(AddPackDialog);
            RemovePackDialogCommand = new DelegateCommand(RemovePackDialog);
            OptionDialogCommand = new DelegateCommand(OptionDialog);
            CancelDialogCommand = new DelegateCommand(CancelDialog);
        }

        private void AddPackDialog(object obj)
        {

        }

        private void RemovePackDialog(object obj)
        {

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

        private void CancelDialog(object obj)
        {
            if (obj is Window window)

                window.Close();
        }
            


    }
}
