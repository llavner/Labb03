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
        public ConfigurationViewModel? ConfigurationViewModel { get; set; }
        public PlayerViewModel PlayerViewModel { get; set; }
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

            var newCarPack = new QuestionPackViewModel(new QuestionPack("Car Pack"));
            var newMoviePack = new QuestionPackViewModel(new QuestionPack("Movie Pack"));

            //Packs.Add(newPack);
            Packs.Add(newCarPack);
            Packs.Add(newMoviePack);
            ActivePack = newCarPack;

            newCarPack.Questions.Add(new Question("What car is a German car?", "BMW", "Saab", "Dodge", "Volvo"));
            newCarPack.Questions.Add(new Question("What car is a Porsche?", "Carrera", "Viper", "Countach", "MC20"));

            
            newMoviePack.Questions.Add(new Question("Who is the main female star in The Bodyguard?", "Whitney Houston", "Reese Witherspoon", "Salma Hyak", "Goldie Hawn"));
            newMoviePack.Questions.Add(new Question("How much did Waterworld cost to make? (in millions)", "175", "75", "210", "110"));

            
            ConfigurationViewModel = new ConfigurationViewModel(this);
            ImportQuestionViewModel = new ImportQuestionViewModel(this);
            MenubarViewModel = new MenubarViewModel(this);
            PlayerViewModel = new PlayerViewModel(this);
            
            


        }

    }

}
