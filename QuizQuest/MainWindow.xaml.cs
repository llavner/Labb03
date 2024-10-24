using QuizQuest.Model;
using QuizQuest.ViewModel;
using System.Windows;


namespace QuizQuest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();

        }
    }
}