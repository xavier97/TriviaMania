using System;

using UIKit;
using CoreGraphics;
using System.Timers;
using System.Threading;

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

            QuestionTimerProgressBar.Style = UIProgressViewStyle.Default;

            //QuestionLabel.Layer.BorderColor = 
        }

        class TimerExampleState
        {
            public int counter = 0;
            public System.Threading.Timer tmr;
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
            TimerExampleState s = new TimerExampleState();

            // Progress Bar Details
            QuestionTimerProgressBar.Progress = 5; // TODO: This is for 5 seconds

            // Create the delegate that invokes methods for the timer.
            TimerCallback timerDelegate = new TimerCallback(CheckStatus);

            // Create a timer that waits one second, then invokes every second.
            System.Threading.Timer progressTimer = new System.Threading.Timer(timerDelegate, s, 1000, 1000);

            // Keep a handle to the timer, so it can be disposed.
            s.tmr = timer;

            #endregion

            //int time = 1;

        }

        private void CheckStatus(object state)
        {
            throw new NotImplementedException();
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

