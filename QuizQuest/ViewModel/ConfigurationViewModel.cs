using QuizQuest.Command;
using QuizQuest.Dialogs;
using QuizQuest.Model;
using System.Windows;
using System.Xml.Linq;


namespace QuizQuest.ViewModel
{
    internal class ConfigurationViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;

        public QuestionPackViewModel? ActivePack => mainWindowViewModel?.ActivePack;

        private Question? _activeQuestion;
        public Question ActiveQuestion
        {
            get { return _activeQuestion; }
            set
            {
                _activeQuestion = value;
                RaisedPropertyChanged();
                QuestionRemoveCommand.RaisedCanExecuteChanged();
            }
        }

        // Delegate Commands:
        public DelegateCommand? PackDialogCommand { get; }
        public DelegateCommand? PackDialogOptionCommand { get; }
        public DelegateCommand? PackAddButtonCommand { get; }
        public DelegateCommand? PackCancelButtonCommand { get; }
        public DelegateCommand QuestionAddCommand { get; }
        public DelegateCommand QuestionRemoveCommand { get; }

        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;

            PackDialogCommand = new DelegateCommand(PackDialog);
            PackDialogOptionCommand = new DelegateCommand(PackDialogOption);
            PackAddButtonCommand = new DelegateCommand(PackAddButton);
            PackCancelButtonCommand = new DelegateCommand(PackCancelButton);

            QuestionAddCommand = new DelegateCommand(QuestionAdd);
            QuestionRemoveCommand = new DelegateCommand(QuestionRemove, QuestionCanRemove);

            

        }
        private void PackDialog(object obj)
        {
            CreateNewPackDialog createNewPackDialog = new();

            var result = createNewPackDialog.ShowDialog();
        }
        private void PackAddButton(object obj)
        {
             new QuestionPackViewModel(new QuestionPack(QuestionPackViewModel.Name ));
            //new QuestionPackViewModel(new QuestionPack(Name, Difficulty, TimeLimit));

            if (obj is Window window)

                window.Close();
        }
        private void PackCancelButton(object obj)
        {
            if (obj is Window window)

                window.Close();
        }
        private void PackDialogOption(object obj)
        {
            PackOptionDialog packOptionDialog = new();

            var result = packOptionDialog.ShowDialog();
        }

        private void QuestionAdd(object obj)
        {

            ActivePack?.Questions.Add(new Question("New Question", "", "", "", ""));

            ActiveQuestion = ActivePack.Questions.Last();
        }
        private void QuestionRemove(object obj)
        {
            if (ActivePack?.Questions == null || ActiveQuestion == null)
            {

                return;
            }
            ActivePack?.Questions.Remove(ActiveQuestion);
            ActiveQuestion = ActivePack.Questions.FirstOrDefault();
        }
        private bool QuestionCanRemove(object obj)
        {
            if (ActivePack?.Questions != null && ActiveQuestion != null)
                return true;
            else
                return false;
        }
    }
}
