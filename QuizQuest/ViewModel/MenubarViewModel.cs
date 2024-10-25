using QuizQuest.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using QuizQuest.Model;
using QuizQuest.Dialogs;

namespace QuizQuest.ViewModel
{
    internal class MenubarViewModel : ViewModelBase
    {


        private readonly MainWindowViewModel? mainWindowViewModel;
        public DelegateCommand ExitProgramCommand { get; } // 1

        public DelegateCommand OpenPackOptionCommand { get; }

        public DelegateCommand CreateNewPackCommand { get;  }

        public MenubarViewModel(MainWindowViewModel mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;

            CreateNewPackCommand = new DelegateCommand(NewQuestionPack);
            OpenPackOptionCommand = new DelegateCommand(OpenPackOptions);
            ExitProgramCommand = new DelegateCommand(ExitProgram);


        }



        private void ExitProgram(object obj)
        {
            var result = MessageBox.Show("Are you sure you want to Exit?", "Exit Program", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();

        }

        private void OpenPackOptions(object obj)
        {
            PackOptionDialog packOptionDialog = new();

            var result = packOptionDialog.ShowDialog();
        }

        private void NewQuestionPack(object obj)
        {
            CreateNewPackDialog createNewPackDialog = new();

            var result = createNewPackDialog.ShowDialog();
        }

    }



}
