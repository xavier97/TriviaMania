using System;

using UIKit;
using CoreGraphics;
using System.Timers;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MobileAppClass
{
    /// <summary>
    /// The Trivia Game screen that manages the questions
    /// and answers interface for challenging the user.
    /// </summary>
    public partial class TriviaViewController1 : UIViewController
    {
        Timer timer;
        Timer timerProgression;
        Stopwatch timePassed;
        List<TriviaQuestionsRecord> ListofTriviaQuestions;
        readonly int maxQuestions = 15; // Maximum # of questions in game
        readonly int maxTime = 15000; // 15 seconds counted by timer
        readonly int progressInterval = 1000; // The time bar's timer interval
        int questionNumber = 1; // Initialized to 1 once the game starts

        public TriviaViewController1() : base("TriviaViewController1", null)
        {
            // Initialize the list and convert Json from local storage to list
            ListofTriviaQuestions = new List<TriviaQuestionsRecord>();
            var jsonData = File.ReadAllText(AppDelegate.pathFile);
            ListofTriviaQuestions = JsonConvert.DeserializeObject<List<TriviaQuestionsRecord>>(jsonData);
        }

        #region Answer Buttons

        partial void AnswerButton1_TouchUpInside(UIButton sender)
        {
            if (RandomSelectGenerator.GetInstance().AnswerBox() == 1)
            {
                Console.WriteLine("1");
                WinState();
            }
        }

        partial void AnswerButton2_TouchUpInside(UIButton sender)
        {
            if (RandomSelectGenerator.GetInstance().AnswerBox() == 2)
            {
                Console.WriteLine("2");
                WinState();
            }
        }

        partial void AnswerButton3_TouchUpInside(UIButton sender)
        {
            if (RandomSelectGenerator.GetInstance().AnswerBox() == 3)
            {
                Console.WriteLine("3");
                WinState();
            }
        }

        partial void AnswerButton4_TouchUpInside(UIButton sender)
        {
            if (RandomSelectGenerator.GetInstance().AnswerBox() == 4)
            {
                Console.WriteLine("4");
                WinState();
            }
        }

        #endregion

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

            InitTimerBar(); // Reveal timer bar
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            GameSetup(); // Get first question to display to user
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // todo: this takes forver to display. why??
            BeginTimeFill(); // Begins the timer bar's load

            // Countdown Details
            timer = new System.Timers.Timer();
            timer.Interval = maxTime;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;

            // Begin countdown
            timer.Start();
            timePassed = new Stopwatch();
            timePassed.Start();

        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            // Kill timers when exited
            timer.Stop();
            timerProgression.Stop();
            timePassed.Stop();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        /// <summary>
        /// Randomly choosing a question to show and setup UI accordingly
        /// </summary>
        private void GameSetup()
        {
            // Get a random question from the list and display it
            int rndQuestion = RandomSelectGenerator.GetInstance().RandomQuestion(ListofTriviaQuestions.Count);

            QuestionLabel.Text = ListofTriviaQuestions[rndQuestion].question;
            QuestionLabel.TextAlignment = UITextAlignment.Natural;

            // Finds the correct answer box to "hide" the correct ansswer in
            if (RandomSelectGenerator.GetInstance().AnswerBox() == 1)
            {
                // Correct Answer
                AnswerButton1.SetTitle(ListofTriviaQuestions[rndQuestion].answer, UIControlState.Normal);

                // False Answers
                AnswerButton2.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ2, UIControlState.Normal);
                AnswerButton3.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ3, UIControlState.Normal);
                AnswerButton4.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ1, UIControlState.Normal);
            }
            else if (RandomSelectGenerator.GetInstance().AnswerBox() == 2)
            {
                // Correct Answer
                AnswerButton2.SetTitle(ListofTriviaQuestions[rndQuestion].answer, UIControlState.Normal);

                // False Answers
                AnswerButton1.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ1, UIControlState.Normal);
                AnswerButton3.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ3, UIControlState.Normal);
                AnswerButton4.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ2, UIControlState.Normal);
            }
            else if (RandomSelectGenerator.GetInstance().AnswerBox() == 3)
            {
                // Correct Answer
                AnswerButton3.SetTitle(ListofTriviaQuestions[rndQuestion].answer, UIControlState.Normal);

                // False Answers
                AnswerButton1.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ1, UIControlState.Normal);
                AnswerButton4.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ2, UIControlState.Normal);
                AnswerButton2.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ3, UIControlState.Normal);
            }
            else if (RandomSelectGenerator.GetInstance().AnswerBox() == 4)
            {
                // Correct Answer
                AnswerButton4.SetTitle(ListofTriviaQuestions[rndQuestion].answer, UIControlState.Normal);

                // False Answers
                AnswerButton1.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ3, UIControlState.Normal);
                AnswerButton2.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ2, UIControlState.Normal);
                AnswerButton3.SetTitle(ListofTriviaQuestions[rndQuestion].falseQ1, UIControlState.Normal);
            }
        }

        #region Timer Progress Bar
        // Handles QuestionTimerProgressBar's set up and functionality
        private void BeginTimeFill()
        {
            // Progress Bar Details
            timerProgression = new Timer();
            timerProgression.Interval = progressInterval;
            timerProgression.Elapsed += (sender, e) =>
            {
                Console.WriteLine("hello");
                QuestionTimerProgressBar.Progress -= 1;
            };
            timerProgression.Enabled = true;
        }

        // Kills timer bar and progression
        private void EndTimeFill()
        {
            timerProgression.Dispose();
        }

        // Handles QuestionTimerProgressBar's aesthetic
        private void InitTimerBar()
        {
            QuestionTimerProgressBar.SetProgress(15, true); // 15 sec interval
            QuestionTimerProgressBar.ProgressTintColor = UIColor.White; // color
            //QuestionTimerProgressBar.Transform = CGAffineTransform.MakeTranslation(-1.0f, 1.0f); // flip fill
        }
        #endregion

        /// <summary>
        /// When the user selects the correct answer.
        /// </summary>
        private void WinState()
        {
            // Stop the progress timer
            EndTimeFill();

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
                    GameSetup();

                    // Allow progress bar to progress
                };
            }

        }

        /// <summary>
        /// Calculates the user's current or final game score
        /// </summary>
        /// <returns>The score.</returns>
        /// <param name="numCorrect">Number correct.</param>
        /// <param name="secondsPassed">Seconds passed.</param>
        private int GameScore(int numCorrect, float secondsPassed)
        {
            // Calculate by number_correct_ans * (150s - seconds_passed)
            int totalScore = (int)(numCorrect * (maxTime - secondsPassed));
            return totalScore;
        }

        /// <summary>
        /// Events that happen if the user 
        /// runs out of time on a question
        /// </summary>
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

                // Pop when user acknowledges they lost
                timeAlert.WillDismiss += (object sender2, UIButtonEventArgs e2) =>
                {
                    this.NavigationController.PopViewController(true);
                };
            });

            // Stop all timers when countdown ends
            timer.Stop();
            timerProgression.Stop();
            timePassed.Stop();
        }

    }
}

