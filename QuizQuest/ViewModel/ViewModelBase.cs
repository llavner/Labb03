using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuizQuest.ViewModel
{
    internal class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisedPropertyChanged([CallerMemberName] string? propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}
