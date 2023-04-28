using Module3LabC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Module3LabC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            questionText.IsVisible = true;
            instructionsText.IsVisible = true;
            questionText.Text = "text";
            instructionsText.Text = "Swipe right for true or left for false.";
            ShowNextQuetion();
        }

        int quizPoints = 0;
        bool? quizAnswer = null;
        int i = 0;

        List<Question> QuizQuestions = new List<Question>()
        {
            new Question { QuizQuestion="The sky is blue.", CorrectAnswer=true, ImgSrc="img1.jpg" },
            new Question { QuizQuestion="Grass is green.", CorrectAnswer=true, ImgSrc="img2.jpg" },
            new Question { QuizQuestion="2 + 2 = 5.", CorrectAnswer=false, ImgSrc="img3.jpg" },
            new Question { QuizQuestion="Smoking is good for you.", CorrectAnswer=false, ImgSrc="img4.jpg"},
            new Question { QuizQuestion="A bear sh*ts in the woods.", CorrectAnswer=true, ImgSrc="img5.jpg"}
        };

        public void ShowNextQuetion()
        {
            if (i < QuizQuestions.Count())
            {
                questionText.Text = QuizQuestions[i].QuizQuestion;
                theImage.Source = QuizQuestions[i].ImgSrc;
            }
            else if (i >= QuizQuestions.Count())
            {
                theImage.IsVisible = false;
                instructionsText.IsVisible = false;
                questionText.Text = $"You scored {quizPoints}/5!";
            }
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            if (e.Direction == SwipeDirection.Right)
            {
                quizAnswer = true;
                if (i < QuizQuestions.Count() && QuizQuestions[i].CorrectAnswer == true)
                {
                    i += 1;
                    quizPoints += 1;
                }
                else
                {
                    i += 1;
                }
                ShowNextQuetion();
            }
            else if (e.Direction == SwipeDirection.Left)
            {
                quizAnswer = false;
                if (i < QuizQuestions.Count() && QuizQuestions[i].CorrectAnswer == false)
                {
                    quizPoints += 1;
                    i += 1;
                }
                else
                {
                    i += 1;
                }
                ShowNextQuetion();
            }
        }

    }
}