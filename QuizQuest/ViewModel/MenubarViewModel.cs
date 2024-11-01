using QuizQuest.Command;
using System.Windows;


namespace QuizQuest.ViewModel
{
    internal class MenubarViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;
        public DelegateCommand ExitProgramCommand { get; }
        public DelegateCommand GoFullScreenCommand { get; }
        public DelegateCommand? DeletePackCommand { get; }
        public MenubarViewModel(MainWindowViewModel mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;

            DeletePackCommand = new DelegateCommand(DeletePack);
            ExitProgramCommand = new DelegateCommand(ExitProgram);
            GoFullScreenCommand = new DelegateCommand(GoFullScreen);
        }
        private void DeletePack(object obj)
        {

        }
        private void ExitProgram(object obj)
        {
            var result = MessageBox.Show("Are you sure you want to Exit?", "Exit Program", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();

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
