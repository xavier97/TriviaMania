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
    [Register ("MyViewController")]
    partial class MyViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HighScoreLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LogoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NewGameButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ViewQuestionsButton { get; set; }

        [Action ("NewGameButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NewGameButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (HighScoreLabel != null) {
                HighScoreLabel.Dispose ();
                HighScoreLabel = null;
            }

            if (LogoLabel != null) {
                LogoLabel.Dispose ();
                LogoLabel = null;
            }

            if (NewGameButton != null) {
                NewGameButton.Dispose ();
                NewGameButton = null;
            }

            if (ViewQuestionsButton != null) {
                ViewQuestionsButton.Dispose ();
                ViewQuestionsButton = null;
            }
        }
    }
}