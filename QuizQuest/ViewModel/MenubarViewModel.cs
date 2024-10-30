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
        public DelegateCommand ExitProgramCommand { get; }

        public DelegateCommand OpenPackOptionCommand { get; }

        public DelegateCommand CreateNewPackCommand { get;  }

        public DelegateCommand GoFullScreenCommand { get; }

        public DelegateCommand ImportCommand { get; }

        public MenubarViewModel(MainWindowViewModel mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;

            CreateNewPackCommand = new DelegateCommand(CreateQuestionPack);
            OpenPackOptionCommand = new DelegateCommand(OpenPackOptions);
            ExitProgramCommand = new DelegateCommand(ExitProgram);
            GoFullScreenCommand = new DelegateCommand(GoFullScreen);
            ImportCommand = new DelegateCommand(ImportQuestions);

            
        }

        private void ImportQuestions(object obj)
        {
            ImportPackDialog importPackDialog = new();

            var result = importPackDialog.ShowDialog();

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

        private void CreateQuestionPack(object obj)
        {
            CreateNewPackDialog createNewPackDialog = new();

            var result = createNewPackDialog.ShowDialog();
        }

        public void GoFullScreen(object obj)
        {
            var mainWindow = Application.Current.MainWindow;

            if (mainWindow != null)
            {
                if (mainWindow.WindowState == WindowState.Maximized && mainWindow.WindowStyle == WindowStyle.None)
                {
                    mainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                    mainWindow.WindowState = WindowState.Normal;
                    
                }
                else
                {
                    mainWindow.WindowStyle = WindowStyle.ThreeDBorderWindow;
                    mainWindow.WindowState = WindowState.Maximized;
                }
            }
        }
    }



}
