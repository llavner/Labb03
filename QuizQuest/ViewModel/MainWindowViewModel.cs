using QuizQuest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuest.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        
        public ObservableCollection<QuestionPackViewModel>? Packs { get; set; }

        private QuestionPackViewModel? _activePack;

        public PlayerViewModel PlayerViewModel { get; }

        public ConfigurationViewModel ConfigurationViewModel { get; }

        public QuestionPackViewModel? ActivePack
        {
            get { return _activePack; }
            set 
            { 
                _activePack = value;
                RaisedPropertyChanged();
                ConfigurationViewModel.RaisedPropertyChanged("Active Pack");
            }
        }

        public MainWindowViewModel()
        {
            PlayerViewModel = new PlayerViewModel(this);

            ConfigurationViewModel = new ConfigurationViewModel(this);

            ActivePack =new QuestionPackViewModel(new QuestionPack("My Question Pack"));

        }



    }
}
