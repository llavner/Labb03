﻿using QuizQuest.Command;
using System.Windows;
using QuizQuest.Dialogs;

namespace QuizQuest.ViewModel
{
    class DialogViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;
        
        public DelegateCommand? ImportDialogCommand { get; }
        
        public DialogViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;

            
            ImportDialogCommand = new DelegateCommand(ImportDialog);

            //Delete whole class and make a new class: ImportQuestion
            
        }

        private void ImportDialog(object obj)
        {
            ImportPackDialog importPackDialog = new();

            var result = importPackDialog.ShowDialog();

        }


    }
}