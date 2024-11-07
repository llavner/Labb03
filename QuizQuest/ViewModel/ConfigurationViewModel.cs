﻿using QuizQuest.Assets.Command;
using QuizQuest.Dialogs;
using QuizQuest.Model;
using System.Diagnostics;
using System.Windows;


namespace QuizQuest.ViewModel
{
    internal class ConfigurationViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;

        public QuestionPackViewModel? ActivePack => mainWindowViewModel?.ActivePack;

        private Question? _activeQuestion;
        public Question ActiveQuestion
        {
            get { return _activeQuestion; }
            set
            {
                _activeQuestion = value;
                RaisedPropertyChanged(nameof(ActiveQuestion));
                QuestionDeleteCommand.RaisedCanExecuteChanged();
            }
        }

        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }
        public int TimeLimit { get; set; }


        public DelegateCommand? PackDialogCommand { get; }
        public DelegateCommand? PackDialogOptionCommand { get; }
        public DelegateCommand? PackAddButtonCommand { get; }
        public DelegateCommand? PackCancelButtonCommand { get; }
        public DelegateCommand? PackSelectCommand { get; }
        public DelegateCommand? PackDeleteCommand { get; }
        public DelegateCommand QuestionAddCommand { get; }
        public DelegateCommand QuestionDeleteCommand { get; }
        public DelegateCommand UpdatePackCommand { get; }
        public DelegateCommand SelectPackCommand { get; }

        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;

            PackDialogCommand = new DelegateCommand(PackDialog);
            PackDialogOptionCommand = new DelegateCommand(PackDialogOption);
            PackAddButtonCommand = new DelegateCommand(PackAddButton);
            PackCancelButtonCommand = new DelegateCommand(PackCancelButton);
            PackDeleteCommand = new DelegateCommand(PackDelete, PackCanDelete);
            QuestionAddCommand = new DelegateCommand(QuestionAdd);
            QuestionDeleteCommand = new DelegateCommand(QuestionDelete, QuestionCanDelete);
            SelectPackCommand = new DelegateCommand(SelectPack, CanSelectPack);
            UpdatePackCommand = new DelegateCommand(UpdatePack);


        }

        private bool CanSelectPack(object obj) => mainWindowViewModel.Packs.Count != 0;
        private void SelectPack(object obj)
        {
            mainWindowViewModel.ActivePack = (QuestionPackViewModel)obj;
            SelectPackCommand.RaisedCanExecuteChanged();
            
        }

        private void UpdatePack(object obj)
        {


        }
        private void PackDialog(object obj)
        {
            CreateNewPackDialog createNewPackDialog = new();
            var result = createNewPackDialog.ShowDialog();
        }
        private void PackAddButton(object obj)
        {
            var newPack = new QuestionPackViewModel(new QuestionPack(Name, Difficulty, TimeLimit));

            mainWindowViewModel.Packs.Add(newPack);
            mainWindowViewModel.ActivePack = newPack;

            PackAddButtonCommand.RaisedCanExecuteChanged();
            PackDeleteCommand.RaisedCanExecuteChanged();

            if (obj is Window window)
                window.Close();

        }
        private void PackCancelButton(object obj)
        {
            if (obj is Window window)

                window.Close();
        }
        private void PackDialogOption(object obj)
        {
            PackOptionDialog packOptionDialog = new();

            var result = packOptionDialog.ShowDialog();
        }
        private void PackDelete(object obj)
        {
            if (mainWindowViewModel.Packs.Count < 1)
            {
                MessageBox.Show("No Pack found.", "Attention!", MessageBoxButton.OK);
                return;

            }

            var result = MessageBox.Show("Delete Pack?", "Delete", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {

                mainWindowViewModel.Packs.Remove(ActivePack);
                mainWindowViewModel.ActivePack = mainWindowViewModel.Packs.FirstOrDefault();
                PackDeleteCommand.RaisedCanExecuteChanged();
            }
            else 
            { 
                return; 
            
            }

        }
            
        private bool PackCanDelete(object obj) => mainWindowViewModel?.Packs?.Count != 0;
        private void QuestionAdd(object obj)
        {
            if (mainWindowViewModel.Packs.Count > 0)
            {

                ActivePack?.Questions.Add(new Question("New Question", "", "", "", ""));
                ActiveQuestion = ActivePack.Questions.Last();

            }
            else
            {
                var result = MessageBox.Show("Please be sure to add a Pack first.", "Attention!", MessageBoxButton.OK);
            }

        }
        private void QuestionDelete(object obj)
        {
            if (ActivePack?.Questions == null || ActiveQuestion == null)
            {

                return;
            }
            ActivePack?.Questions.Remove(ActiveQuestion);
            ActiveQuestion = ActivePack.Questions.FirstOrDefault();
            RaisedPropertyChanged(nameof(QuestionDelete));
        }
        private bool QuestionCanDelete(object obj)
        {
            if (ActivePack?.Questions != null && ActiveQuestion != null)
                return true;
            else
                return false;
        }
    }
}
