using QuizQuest.Command;
using QuizQuest.Dialogs;
using QuizQuest.Model;
using System.Diagnostics;
using System.Windows;


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
                QuestionDeleteCommand.RaisedCanExecuteChanged();
            }
        }

        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }
        public int TimeLimit { get; set; }

        
        public DelegateCommand? PackDialogCommand { get; }
        public DelegateCommand? PackDialogOptionCommand { get; }
        public DelegateCommand? PackAddButtonCommand { get; }
        public DelegateCommand? PackCancelButtonCommand { get; }
        public DelegateCommand? PackSelectCommand { get; }
        public DelegateCommand? PackDeleteCommand { get; }
        public DelegateCommand QuestionAddCommand { get; }
        public DelegateCommand QuestionDeleteCommand { get; }
        public DelegateCommand UpdatePackCommand { get; }
        public DelegateCommand SelectPackCommand { get; }

        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;

            PackDialogCommand = new DelegateCommand(PackDialog);
            PackDialogOptionCommand = new DelegateCommand(PackDialogOption);
            PackAddButtonCommand = new DelegateCommand(PackAddButton);
            PackCancelButtonCommand = new DelegateCommand(PackCancelButton);
            PackDeleteCommand = new DelegateCommand(PackDelete, PackCanDelete);
            QuestionAddCommand = new DelegateCommand(QuestionAdd);
            QuestionDeleteCommand = new DelegateCommand(QuestionDelete, QuestionCanDelete);
            SelectPackCommand = new DelegateCommand(SelectPack);
            UpdatePackCommand = new DelegateCommand(UpdatePack);
        }

        private void SelectPack(object obj)
        {
            Debug.WriteLine("sdsdsadasdasdsad");
            mainWindowViewModel.ActivePack = (QuestionPackViewModel)obj;
            RaisedPropertyChanged();
            
            
        }

        private void UpdatePack(object obj)
        {
            

        }
        private void PackDialog(object obj)
        {
            CreateNewPackDialog createNewPackDialog = new();
            var result = createNewPackDialog.ShowDialog();
        }
        private void PackAddButton(object obj)
        {
            var newPack = new QuestionPackViewModel(new QuestionPack(Name, Difficulty, TimeLimit));

            mainWindowViewModel.Packs.Add(newPack);
            mainWindowViewModel.ActivePack = newPack;
            
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
        private void PackDelete(object obj)
        {

            Debug.WriteLine(mainWindowViewModel.Packs.Count.ToString());
            if (mainWindowViewModel.Packs.Count == 1)
            {
                return;

            }
            mainWindowViewModel.Packs.Remove(ActivePack);
            mainWindowViewModel.ActivePack = mainWindowViewModel.Packs.FirstOrDefault();

            

        }
        private bool PackCanDelete(object obj)
        {
            Debug.WriteLine("gfgfgfg");
            if (mainWindowViewModel.Packs.Count != 0)
            {
                return true;
            }
            else
                return false;

        }
        private void QuestionAdd(object obj)
        {

            ActivePack?.Questions.Add(new Question("New Question", "", "", "", ""));

            ActiveQuestion = ActivePack.Questions.Last();
        }
        private void QuestionDelete(object obj)
        {
            if (ActivePack?.Questions == null || ActiveQuestion == null)
            {

                return;
            }
            ActivePack?.Questions.Remove(ActiveQuestion);
            ActiveQuestion = ActivePack.Questions.FirstOrDefault();
        }
        private bool QuestionCanDelete(object obj)
        {
            if (ActivePack?.Questions != null && ActiveQuestion != null)
                return true;
            else
                return false;
        }
    }
}
