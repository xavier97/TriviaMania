using System;

using UIKit;
using CoreGraphics;
using System.Timers;

namespace MobileAppClass
{
    public partial class TriviaViewController1 : UIViewController
    {
        Timer timer;
        readonly int timeLeft = 5000; // TODO: Change this to 15000 for 15 seconds when done testing
        int score;

        public TriviaViewController1() : base("TriviaViewController1", null)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            UIEdgeInsets questionLabelMargins;
            questionLabelMargins.Bottom = 0.5f;
            questionLabelMargins.Left = 10f;
            questionLabelMargins.Right = 10f;
            questionLabelMargins.Top = 0.5f;

            QuestionLabel.Layer.BorderWidth = 3.5f;


            //QuestionLabel.Layer.BorderColor = 
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // Countdown Details
            timer = new Timer();
            timer.Interval = timeLeft;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            // Progress Bar Details
            QuestionTimerProgressBar.Progress = 5; // TODO: This is for 5 seconds

            //int time = 1;

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

