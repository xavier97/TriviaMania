// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MobileAppClass
{
    [Register ("TriviaViewController1")]
    partial class TriviaViewController1
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AnswerButton1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AnswerButton2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AnswerButton3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AnswerButton4 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel QuestionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel questionNumberLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIProgressView QuestionTimerProgressBar { get; set; }

        [Action ("AnswerButton1_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AnswerButton1_TouchUpInside (UIKit.UIButton sender);

        [Action ("AnswerButton2_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AnswerButton2_TouchUpInside (UIKit.UIButton sender);

        [Action ("AnswerButton3_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AnswerButton3_TouchUpInside (UIKit.UIButton sender);

        [Action ("AnswerButton4_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AnswerButton4_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AnswerButton1 != null) {
                AnswerButton1.Dispose ();
                AnswerButton1 = null;
            }

            if (AnswerButton2 != null) {
                AnswerButton2.Dispose ();
                AnswerButton2 = null;
            }

            if (AnswerButton3 != null) {
                AnswerButton3.Dispose ();
                AnswerButton3 = null;
            }

            if (AnswerButton4 != null) {
                AnswerButton4.Dispose ();
                AnswerButton4 = null;
            }

            if (QuestionLabel != null) {
                QuestionLabel.Dispose ();
                QuestionLabel = null;
            }

            if (questionNumberLabel != null) {
                questionNumberLabel.Dispose ();
                questionNumberLabel = null;
            }

            if (QuestionTimerProgressBar != null) {
                QuestionTimerProgressBar.Dispose ();
                QuestionTimerProgressBar = null;
            }
        }
    }
}