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
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuizQuest.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        private Visibility _editVisibility = Visibility.Visible;
        private Visibility _playVisibility = Visibility.Collapsed;
        public ObservableCollection<QuestionPackViewModel>? Packs { get; set; }
        private QuestionPackViewModel? _activePack;
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

            //Listan skapas
            Packs = new ObservableCollection<QuestionPackViewModel>();
            
            var newPack = new QuestionPackViewModel(new QuestionPack("Default Pack"));
            Packs.Add(newPack);
            this.ActivePack = newPack;


            //Default Pack Objekt

            /*var Pack1 = new QuestionPackViewModel(new QuestionPack("History"));
            var Pack2 = new QuestionPackViewModel(new QuestionPack("Movies"));
            var Pack3 = new QuestionPackViewModel(new QuestionPack("Heavy Metal"));
            var Pack4 = new QuestionPackViewModel(new QuestionPack("Computer Science"));

            Packs.Add(Pack1);
            Packs.Add(Pack2);
            Packs.Add(Pack3);
            Packs.Add(Pack4);*/
            
            //Frågor på Objektet
            //ActivePack.Questions.Add(new Question("Vad står D.R.Y. för?", "Don't repeat yourself", "Do react yourself", "Dark realm yeti", "Dry red yonder"));
            
            /*Pack1.Questions.Add(new Question("When did Napoleon die?", "1", "2", "3", "4"));

            Pack2.Questions.Add(new Question("Who has the mainrole in Donnie Darko?", "1", "2", "3", "4"));

            Pack2.Questions.Add(new Question("How long is the Dark Knight?", "1", "2", "3", "4"));
            Pack2.Questions.Add(new Question("What genre is Longlegs?", "1", "2", "3", "4"));
            Pack2.Questions.Add(new Question("Who made the Shining?", "1", "2", "3", "4"));
*/

            /*if (Packs == null)
                Packs.Add(ActivePack);*/

            
            ConfigurationViewModel = new ConfigurationViewModel(this);

            ImportQuestionViewModel = new ImportQuestionViewModel(this);

            MenubarViewModel = new MenubarViewModel(this);

            

            PlayerViewModel = new PlayerViewModel(this);

            
            
         }
            
    }

}
