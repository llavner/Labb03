using QuizQuest.Command;
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

        public PlayerViewModel PlayerViewModel { get; }

        public ConfigurationViewModel ConfigurationViewModel { get; }

        public MenubarViewModel MenubarViewModel { get; }

        public QuestionPackViewModel? ActivePack
        {
            get { return _activePack; }
            set 
            { 
                _activePack = value;
                RaisedPropertyChanged();
                ConfigurationViewModel.RaisedPropertyChanged(nameof(ActivePack));
            }
        }

        public MainWindowViewModel()
        {
            
            PlayerViewModel = new PlayerViewModel(this);

            ConfigurationViewModel = new ConfigurationViewModel(this);

            MenubarViewModel = new MenubarViewModel(this);

            ActivePack = new QuestionPackViewModel(new QuestionPack("My Question Pack"));

            

        }

    }
}
