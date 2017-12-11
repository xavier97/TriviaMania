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
        UIKit.UIProgressView GameStatusProgressBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel QuestionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIProgressView QuestionTimerProgressBar { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (GameStatusProgressBar != null) {
                GameStatusProgressBar.Dispose ();
                GameStatusProgressBar = null;
            }

            if (QuestionLabel != null) {
                QuestionLabel.Dispose ();
                QuestionLabel = null;
            }

            if (QuestionTimerProgressBar != null) {
                QuestionTimerProgressBar.Dispose ();
                QuestionTimerProgressBar = null;
            }
        }
    }
}