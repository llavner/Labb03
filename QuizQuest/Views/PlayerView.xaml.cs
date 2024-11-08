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

            
            
        }

        
        public void AnswerCheck(bool value)
        {
            if(value)
            {
                Button1.Background = new SolidColorBrush(Colors.PaleVioletRed);
                
                Debug.WriteLine("Is correct, color green");
            }
            else
            {
                Debug.WriteLine("Is false, color red");
            }
        }
    }
}
