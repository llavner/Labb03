using QuizQuest.Command;
using QuizQuest.Converters;
using QuizQuest.Model;
using QuizQuest.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizQuest.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        
        public ObservableCollection<QuestionPackViewModel>? Packs { get; set; }

        private QuestionPackViewModel? _activePack;
        public ConfigurationViewModel? ConfigurationViewModel { get; }
        public QuestionPackViewModel? ActivePack
        {
            get { return _activePack; }
            set 
            { 
                _activePack = value;
                RaisedPropertyChanged();
                //RaisedPropertyChanged(nameof(ActivePack));
            }
        }
        public PlayerViewModel PlayerViewModel { get; }
        public MenubarViewModel MenubarViewModel { get; }
        public DialogViewModel DialogViewModel { get; }
        public ImportQuestionViewModel ImportQuestionViewModel { get; }
        

        public MainWindowViewModel()
        {
            ActivePack = new QuestionPackViewModel(new QuestionPack("My Question Pack")); //TestPack tills jag har en riktig lista att jobba med.

            Packs = new ObservableCollection<QuestionPackViewModel>();

            Packs.Add(new QuestionPackViewModel(new QuestionPack("My Question Pack"))); //test

            ConfigurationViewModel = new ConfigurationViewModel(this);

            ImportQuestionViewModel = new ImportQuestionViewModel(this);

            MenubarViewModel = new MenubarViewModel(this);

            DialogViewModel = new DialogViewModel(this);

            PlayerViewModel = new PlayerViewModel(this);

        }
            
    }

}
