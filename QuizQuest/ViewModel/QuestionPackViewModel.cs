using QuizQuest.Command;
using QuizQuest.Dialogs;
using QuizQuest.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace QuizQuest.ViewModel
{
    internal class QuestionPackViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;

        private readonly QuestionPack _model;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public QuestionPack? Pack { get; }
        public ObservableCollection<Question>? Questions { get; }

        //DelegateCommands

        public DelegateCommand? NewPackCommand { get; }
        public DelegateCommand? OptionCommand { get; }
        public DelegateCommand? AddPackCommand { get; }
        public DelegateCommand? CancelPackCommand { get; }


        // Properties
        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                RaisedPropertyChanged();
            }

        }
        public Difficulty Difficulty
        {
            get => _model.Difficulty;
            set
            {
                _model.Difficulty = value;
                RaisedPropertyChanged();
            }

        }
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

       /* public QuestionPackViewModel(MainWindowViewModel mainWindowViewModel) //ta bort?
        {

            this.mainWindowViewModel = mainWindowViewModel;
            

            NewPackCommand = new DelegateCommand(NewPackDialog);
            OptionCommand = new DelegateCommand(OptionDialog);
            AddPackCommand = new DelegateCommand(AddButton);
            CancelPackCommand = new DelegateCommand(CancelButton);

            //Add buttons for PackOptionDialog
        }*/




        private void NewPackDialog(object obj)
        {
            CreateNewPackDialog createNewPackDialog = new();

            var result = createNewPackDialog.ShowDialog();
        }

        private void OptionDialog(object obj)
        {
            PackOptionDialog packOptionDialog = new();

            var result = packOptionDialog.ShowDialog();
        }

        private void AddButton(object obj)
        {
             
            if (obj is Window window)

                window.Close();
        }

        private void CancelButton(object obj)
        {
            if (obj is Window window)

                window.Close();
        }

    }

}

