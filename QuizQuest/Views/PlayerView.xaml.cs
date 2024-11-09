using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;
namespace QuizQuest.Views
{
    /// <summary>
    /// Interaction logic for PlayerView.xaml
    /// </summary>
    public partial class PlayerView : UserControl
    {
        public PlayerView()
        {
            InitializeComponent();

            Button1.Background = new SolidColorBrush(Colors.PaleVioletRed);
            Button2.Background = new SolidColorBrush(Colors.LightGreen);

        }


        public void AnswerCheck(bool value)
        {

            if (value)
            {
                Button1.Background = new SolidColorBrush(Colors.LightSlateGray);

                Debug.WriteLine("Is correct, color green");
            }
            else
            {
                Button1.Background = new SolidColorBrush(Colors.PaleVioletRed);
                Debug.WriteLine("Is false, color red");
            }
        }
    }
}

