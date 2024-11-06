using QuizQuest.Assets.Command;
using QuizQuest.Views;
using System.Windows;


namespace QuizQuest.ViewModel
{
    internal class MenubarViewModel : ViewModelBase
    {
        public MainWindowViewModel mainWindowViewModel { get; set; }
        public DelegateCommand ExitProgramCommand { get; }
        public DelegateCommand GoFullScreenCommand { get; }
        public DelegateCommand DeletePackCommand { get; }
        public DelegateCommand ShowEditCommand { get; }
        public DelegateCommand ShowPlayCommand { get; }
        public MenubarViewModel(MainWindowViewModel mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;

            var mainWindow = Application.Current.MainWindow;

            ExitProgramCommand = new DelegateCommand(ExitProgram);
            GoFullScreenCommand = new DelegateCommand(GoFullScreen);

            ShowEditCommand = new DelegateCommand(Edit, CanEdit);
            ShowPlayCommand = new DelegateCommand(Play, CanPlay);

        }

        private bool CanEdit(object obj) => mainWindowViewModel?.EditVisibility != Visibility.Visible;
        private bool CanPlay(object obj) => mainWindowViewModel?.PlayVisibility != Visibility.Visible;
        private void Edit(object obj)
        {
            
            mainWindowViewModel.EditVisibility = Visibility.Visible;
            mainWindowViewModel.PlayVisibility = Visibility.Collapsed;
            ShowEditCommand.RaisedCanExecuteChanged();

        }

        private void Play(object obj)
        {
            mainWindowViewModel.PlayerViewModel.Timer();
            mainWindowViewModel.PlayVisibility = Visibility.Visible;
            mainWindowViewModel.EditVisibility = Visibility.Collapsed;
            ShowPlayCommand.RaisedCanExecuteChanged();

            //PlayerViewModel.Play();
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

        //private bool CanGoFullScreen(object obj)
        //{
        //     var mainWindow = Application.Current.MainWindow;

        //    if (mainWindow.WindowState == WindowState.Maximized)
        //        return false;
        //    else
        //        return true;
        //}
    }
}
