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
    [Register ("EnterDataViewController")]
    partial class EnterDataViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CorrectAnswer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField false1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField false2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField false3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView QuestionField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CorrectAnswer != null) {
                CorrectAnswer.Dispose ();
                CorrectAnswer = null;
            }

            if (false1 != null) {
                false1.Dispose ();
                false1 = null;
            }

            if (false2 != null) {
                false2.Dispose ();
                false2 = null;
            }

            if (false3 != null) {
                false3.Dispose ();
                false3 = null;
            }

            if (QuestionField != null) {
                QuestionField.Dispose ();
                QuestionField = null;
            }
        }
    }
}