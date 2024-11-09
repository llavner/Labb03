using QuizQuest.Assets.Command;
using QuizQuest.Dialogs;
using QuizQuest.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace QuizQuest.ViewModel
{
    internal class QuestionPackViewModel : ViewModelBase
    {
        [JsonIgnore]
        private readonly QuestionPack _model;

        [JsonPropertyName("Questions")]
        public ObservableCollection<Question>? Questions { get; set; }

        [JsonPropertyName("Name")]
        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                RaisedPropertyChanged();
            }

        }
        [JsonPropertyName("Difficulty")]
        public int Difficulty 
        {
            get => _model.Difficulty;
            set
            {
                _model.Difficulty = value;
                RaisedPropertyChanged();
            }

        }
        [JsonPropertyName("TimeLimit")]
        public int TimeLimit
        {
            get => _model.TimeLimit;
            set
            {
                _model.TimeLimit = value;
                RaisedPropertyChanged();
            }
        }

       
        public QuestionPackViewModel(QuestionPack model)
        {

            this._model = model;
            this.Questions = new ObservableCollection<Question>(model.Questions);

        }

        public QuestionPackViewModel()
        {
            this._model = new QuestionPack();
            this.Questions = new ObservableCollection<Question>();
            

        }
    }

}

