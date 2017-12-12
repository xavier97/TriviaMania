using System;

using UIKit;
using CoreGraphics;
using System.Timers;
//using System.Threading;
using System.Diagnostics;

namespace MobileAppClass
{
    public partial class TriviaViewController1 : UIViewController
    {
        Timer timer;
        Timer timerProgression;
        Stopwatch timePassed;
        readonly int maxQuestions = 15; // Maximum # of questions in game
        readonly int maxTime = 15000; // TODO: Change this to 15000 for 15 seconds when done testing
        readonly int progressTime = 1000;
        int questionNumber = 0;

        public TriviaViewController1() : base("TriviaViewController1", null)
        {
            
        }

        partial void AnswerButton1_TouchUpInside(UIButton sender)
        {
            if (CorrectBoxGenerator.GetInstance().AnswerBox() == 1)
            {
                Console.WriteLine("1");
                WinState();
            }
        }

        partial void AnswerButton2_TouchUpInside(UIButton sender)
        {
            if (CorrectBoxGenerator.GetInstance().AnswerBox() == 2)
            {
                Console.WriteLine("2");
                WinState();
            }
        }

        partial void AnswerButton3_TouchUpInside(UIButton sender)
        {
            if (CorrectBoxGenerator.GetInstance().AnswerBox() == 3)
            {
                Console.WriteLine("3");
                WinState();
            }
        }

        partial void AnswerButton4_TouchUpInside(UIButton sender)
        {
            if (CorrectBoxGenerator.GetInstance().AnswerBox() == 4)
            {
                Console.WriteLine("4");
                WinState();
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            // Question Label Setup
            UIEdgeInsets questionLabelMargins;
            questionLabelMargins.Bottom = 0.5f;
            questionLabelMargins.Left = 10f;
            questionLabelMargins.Right = 10f;
            questionLabelMargins.Top = 0.5f;

            QuestionLabel.Layer.BorderWidth = 3.5f;

            #region making a random box the answer
            #endregion

        }

        private float DegreesToRadians(float degree)
        {
            return ((float)((degree) * Math.PI / 180.0));
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            QuestionTimerProgressBar.SetProgress(15, true); // TODO: This is for 5 seconds. Make it for 15.
            QuestionTimerProgressBar.ProgressTintColor = UIColor.White;

            // Flip progress bar's fill direction
            QuestionTimerProgressBar.Transform = CGAffineTransform.MakeRotation(DegreesToRadians(180f));
            //QuestionTimerProgressBar.Transform = CGAffineTransform.MakeTranslation(1, -1);

        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // Countdown Details
            timer = new System.Timers.Timer();
            timer.Interval = maxTime;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;

            // Begin countdown
            timer.Start();
            timePassed = new Stopwatch();
            timePassed.Start();

            #region progress bar details

            // Progress Bar Details
            timerProgression = new Timer();
            timerProgression.Interval = progressTime;
            timerProgression.Enabled = true;
            timerProgression.Elapsed += (sender, e) => 
            {
                Console.WriteLine("hello");
                QuestionTimerProgressBar.Progress -= 1f;
            };

            #endregion

        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            InvokeOnMainThread(() => {

                // Calculate game score
                int score = GameScore(questionNumber, timePassed.ElapsedMilliseconds);

                // Popup alert that the timer is done
                UIAlertView timeAlert = new UIAlertView()
                {
                    Title = "Time's Up!",
                    Message = "Final Score: " + score
                };

                timeAlert.AddButton("OK");
                timeAlert.Show();

                timeAlert.WillDismiss += (object sender2, UIButtonEventArgs e2) =>
                {
                    this.NavigationController.PopViewController(true);
                };
            });

            timer.Stop();
            timerProgression.Stop();
            timePassed.Stop();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            // kill timers when exitted
            timer.Stop();
            timerProgression.Stop();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void WinState()
        {
            // +1 number of questions
            questionNumber++;

            // Calculate game score
            int score = GameScore(questionNumber, timePassed.ElapsedMilliseconds);

            // Popup alert that the answer was correct
            UIAlertView correctAlert = new UIAlertView()
            {
                Title = "Correct!",
                Message = "Current Score: " + score
            };
            correctAlert.AddButton("OK");
            correctAlert.Show();

            // Win game if 15+ questions beaten
            if (questionNumber > maxQuestions)
            {
                correctAlert.WillDismiss += (object sender2, UIButtonEventArgs e2) =>
                {
                    Console.WriteLine("you win");
                    // Push "WIN" VC
                    //this.NavigationController.PopViewController(true);
                };
            }
            else
            {
                correctAlert.WillDismiss += (object sender2, UIButtonEventArgs e2) =>
                {
                    // Clear fields and display next question

                };
            }


        }

        private int GameScore(int numCorrect, float secondsPassed)
        {
            // Calculate by number_correct_ans * (150s - seconds_passed)
            int totalScore = (int)(numCorrect * (maxTime - secondsPassed));
            return totalScore;
        }
    }
}

