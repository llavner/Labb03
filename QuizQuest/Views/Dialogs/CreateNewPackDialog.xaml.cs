using QuizQuest.ViewModel;
using System.Windows;



namespace QuizQuest.Dialogs
{
    
    public partial class CreateNewPackDialog : Window
    {
        public CreateNewPackDialog()
        {
            InitializeComponent();

            DataContext = (App.Current.MainWindow as MainWindow).DataContext;
        }
    }
}
