using QuizQuest.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace QuizQuest.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        private Visibility _editVisibility = Visibility.Visible;
        private Visibility _playVisibility = Visibility.Collapsed;
        private QuestionPackViewModel? _activePack;

        public ObservableCollection<QuestionPackViewModel>? Packs { get; set; }
        public QuestionPackViewModel? ActivePack
        {
            get { return _activePack; }
            set
            {
                _activePack = value;
                RaisedPropertyChanged();

            }
        }
        public ConfigurationViewModel? ConfigurationViewModel { get; }
        public PlayerViewModel PlayerViewModel { get; }
        public MenubarViewModel MenubarViewModel { get; }
        public ImportQuestionViewModel ImportQuestionViewModel { get; }


        public Visibility EditVisibility
        {
            get { return _editVisibility; }
            set
            {
                _editVisibility = value;
                RaisedPropertyChanged();
            }
        }
        public Visibility PlayVisibility
        {
            get { return _playVisibility; }
            set
            {
                _playVisibility = value;
                RaisedPropertyChanged();
            }
        }



        public MainWindowViewModel()
        {
            Packs = new ObservableCollection<QuestionPackViewModel>();

            var newPack = new QuestionPackViewModel(new QuestionPack("Default Pack"));

            Packs.Add(newPack);

            this.ActivePack = newPack;

            var musicPack = new QuestionPackViewModel(new QuestionPack("Music Pack"));
            Packs.Add(musicPack);

            musicPack.Questions?.Add(new Question("Who is Iron Maidens vocalist?", "Bruce Dickinson","Blaze Baley", "Paul Di'Anno", "Ozzy Osbourne"));

            this.ActivePack = musicPack;

            ConfigurationViewModel = new ConfigurationViewModel(this);
            ImportQuestionViewModel = new ImportQuestionViewModel(this);
            MenubarViewModel = new MenubarViewModel(this);
            PlayerViewModel = new PlayerViewModel(this);



        }

    }

}
