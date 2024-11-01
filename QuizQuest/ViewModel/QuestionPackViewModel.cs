﻿using QuizQuest.Command;
using QuizQuest.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace QuizQuest.ViewModel
{
    internal class QuestionPackViewModel : ViewModelBase
    {

        private readonly QuestionPack _model;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public QuestionPack? Pack { get; }
        public ObservableCollection<Question> Questions { get; }
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

            // Gör nya delegatecommands till createnewpackDialog. Create+
        }

    }

}

