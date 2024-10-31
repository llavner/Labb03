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
        public ConfigurationViewModel? ConfigurationViewModel { get; }
        public QuestionPackViewModel? ActivePack
        {
            get { return _activePack; }
            set 
            { 
                _activePack = value;
                RaisedPropertyChanged();
                //ConfigurationViewModel.RaisedPropertyChanged(nameof(ActivePack));
            }
        }
        public PlayerViewModel PlayerViewModel { get; }
        public MenubarViewModel MenubarViewModel { get; }


        public MainWindowViewModel()
        {
            ActivePack = new QuestionPackViewModel(new QuestionPack("My Question Pack"));

            ConfigurationViewModel = new ConfigurationViewModel(this);


            MenubarViewModel = new MenubarViewModel(this);

            PlayerViewModel = new PlayerViewModel(this);
            
        }

    }
}
