using QuizQuest.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace QuizQuest.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        private Visibility _editVisibility = Visibility.Visible;
        private Visibility _playVisibility = Visibility.Collapsed;
        private Visibility _gameOverVisibility = Visibility.Collapsed;
        private Visibility _menuVisibility = Visibility.Visible;


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

        public Visibility GameOverVisibility
        {
            get { return _gameOverVisibility; }
            set 
            {
                _gameOverVisibility = value;
                RaisedPropertyChanged();
            }
        }

        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            set { _menuVisibility = value; }
        }

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

            Load("assets/json/data.json");


            var defaultPack = new QuestionPackViewModel(new QuestionPack("Default Pack"));
            
            Packs.Add(defaultPack);
            
            ActivePack = defaultPack;




            

            defaultPack.Questions.Add(new Question("What car is a German car?", "BMW", "Saab", "Dodge", "Volvo"));
            defaultPack.Questions.Add(new Question("How much did Waterworld cost to make? (in millions)", "175", "75", "210", "110"));
            defaultPack.Questions.Add(new Question("What car is a Porsche?", "Carrera", "Viper", "Countach", "MC20"));
            defaultPack.Questions.Add(new Question("Who is the main female star in The Bodyguard?", "Whitney Houston", "Reese Witherspoon", "Salma Hayak", "Goldie Hawn"));



            if (Packs.Count == 0)
            {
                var newPack = new QuestionPackViewModel(new QuestionPack("Default Pack"));
                Packs.Add(defaultPack);
                ActivePack = defaultPack;
                
            }
            else
            {
                ActivePack = Packs.FirstOrDefault();
            }

            ConfigurationViewModel = new ConfigurationViewModel(this);
            ImportQuestionViewModel = new ImportQuestionViewModel(this);
            MenubarViewModel = new MenubarViewModel(this);
            PlayerViewModel = new PlayerViewModel(this);
            


        }

        public async Task Load(string filePath)
        {

            if (File.Exists(filePath))
            {
                var options = new JsonSerializerOptions() { IgnoreReadOnlyFields = true, IgnoreReadOnlyProperties = true, WriteIndented = true};

                string jsonString = File.ReadAllText(filePath);
                var loadPacks = JsonSerializer.Deserialize<ObservableCollection<QuestionPackViewModel>>(jsonString);
                Packs = loadPacks;
            }

        }

        public async Task Save(string filePath)
        {

            if (Packs != null)
            {
                var options = new JsonSerializerOptions() { WriteIndented = true };

                string jsonString = JsonSerializer.Serialize(Packs, options);
                File.WriteAllText("data.json", jsonString);

            }

        }

    }

}
