using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuest.ViewModel
{
    internal class PlayerViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel? mainWindowViewModel;

        public PlayerViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }


    }
}
