// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MobileAppClass
{
    [Register ("QuestionsViewController")]
    partial class QuestionsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView QuestionsTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (QuestionsTableView != null) {
                QuestionsTableView.Dispose ();
                QuestionsTableView = null;
            }
        }
    }
}