using QuizQuest.ViewModel;
using System.Diagnostics;
using System.Windows;
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

        //public void ResetColors()
        //{
        //    btn1Right.Visibility = Visibility.Hidden;
        //    btn1Wrong.Visibility = Visibility.Hidden;

        //    btn2Right.Visibility = Visibility.Hidden;
        //    btn2Wrong.Visibility = Visibility.Hidden;

        //    btn3Right.Visibility = Visibility.Hidden;
        //    btn3Wrong.Visibility = Visibility.Hidden;

        //    btn4Right.Visibility = Visibility.Hidden;
        //    btn4Wrong.Visibility = Visibility.Hidden;

        //} 



        public bool AnswerCheck(bool value)
        {
            if (value)
            {
                Debug.WriteLine("Is correct, color green");
                
                return true;
            }
            else
            {
                Debug.WriteLine("Is false, color red");
                return false;
            }
        }

        //private void Button1_Click(object sender, RoutedEventArgs e)
        //{
        //    if (AnswerCheck(true))
        //    {
        //        btn1Right.Visibility = Visibility.Visible;

        //    }
        //    else if (AnswerCheck(false))
        //    {
        //        btn1Wrong.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        btn1Right.Visibility = Visibility.Hidden;
        //        btn1Wrong.Visibility = Visibility.Hidden;

        //    }
        //}

        //private void Button2_Click(object sender, RoutedEventArgs e)
        //{
        //    if (AnswerCheck(true))
        //    {
        //        btn2Right.Visibility = Visibility.Visible;
        //    }
        //    else if (AnswerCheck(false))
        //    {
        //        btn2Wrong.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        btn2Right.Visibility = Visibility.Hidden;
        //        btn2Wrong.Visibility = Visibility.Hidden;

        //    }
        //}

        //private void Button3_Click(object sender, RoutedEventArgs e)
        //{
        //    if (AnswerCheck(true))
        //    {
        //        btn3Right.Visibility = Visibility.Visible;
        //    }
        //    else if (AnswerCheck(false))
        //    {
        //        btn3Wrong.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        btn3Right.Visibility = Visibility.Hidden;
        //        btn3Wrong.Visibility = Visibility.Hidden;

        //    }
        //}

        //private void Button4_Click(object sender, RoutedEventArgs e)
        //{
        //    if (AnswerCheck(true))
        //    {
        //        btn4Right.Visibility = Visibility.Visible;
        //    }
        //    else if (AnswerCheck(false))
        //    {
        //        btn4Wrong.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        btn1Right.Visibility = Visibility.Hidden;
        //        btn1Wrong.Visibility = Visibility.Hidden;

        //    }
        //}
    }
}

