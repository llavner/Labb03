using QuizQuest.Command;
using QuizQuest.Model;
using QuizQuest.ViewModel;
using System.Windows;


namespace QuizQuest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }


    }
}


