using System;

using UIKit;
using CoreGraphics;
using System.Timers;
//using System.Threading;

namespace MobileAppClass
{
    public partial class TriviaViewController1 : UIViewController
    {
        Timer timer;
        Timer timerProgression;
        readonly int timeLeft = 15000; // TODO: Change this to 15000 for 15 seconds when done testing
        readonly int progressTime = 1000;
        int score;

        public TriviaViewController1() : base("TriviaViewController1", null)
        {
            
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

            QuestionTimerProgressBar.Style = UIProgressViewStyle.Default;

            //QuestionLabel.Layer.BorderColor = 
        }

        public float DegreesToRadians(float degree)
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
            timer.Interval = timeLeft;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

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
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

