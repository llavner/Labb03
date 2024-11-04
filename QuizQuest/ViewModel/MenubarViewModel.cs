using QuizQuest.Command;
using QuizQuest.Views;
using System.Windows;


namespace QuizQuest.ViewModel
{
    internal class MenubarViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;
        public DelegateCommand ExitProgramCommand { get; }
        public DelegateCommand GoFullScreenCommand { get; }
        public DelegateCommand DeletePackCommand { get; }
        public DelegateCommand ShowEditCommand { get; }
        public DelegateCommand ShowPlayCommand { get; }
        public MenubarViewModel(MainWindowViewModel mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;


            ExitProgramCommand = new DelegateCommand(ExitProgram);
            GoFullScreenCommand = new DelegateCommand(GoFullScreen);

            ShowEditCommand = new DelegateCommand(Edit, CanEdit);
            ShowPlayCommand = new DelegateCommand(Play, CanPlay);

        }

        private bool CanEdit(object obj)
        {
            if (mainWindowViewModel?.EditVisibility == Visibility.Visible && mainWindowViewModel?.PlayVisibility == Visibility.Collapsed)
            {
                return false;

            }
            else return true;

        }

        private bool CanPlay(object obj)
        {
            if (mainWindowViewModel?.PlayVisibility == Visibility.Visible && mainWindowViewModel?.EditVisibility == Visibility.Collapsed)
            {
                return false;
            }
            else return true;

        }
        private void Edit(object obj)
        {
            mainWindowViewModel.EditVisibility = Visibility.Visible;
            mainWindowViewModel.PlayVisibility = Visibility.Collapsed;
        }

        private void Play(object obj)
        {

            mainWindowViewModel.PlayVisibility = Visibility.Visible;
            mainWindowViewModel.EditVisibility = Visibility.Collapsed;

        }

        private void ExitProgram(object obj) //Lägg till Save to file?
        {
            var result = MessageBox.Show("Are you sure you want to Exit?", "Exit Program", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();

        }
        private void GoFullScreen(object obj)
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
