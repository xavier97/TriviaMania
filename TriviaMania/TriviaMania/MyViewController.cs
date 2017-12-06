using System;

using UIKit;

namespace MobileAppClass
{
    public partial class MyViewController : UIViewController
    {
        public MyViewController() : base("MyViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
			//Add navigation bar title
			NavigationItem.Title = "Trivia Mania";
			NavigationController.NavigationBar.BackgroundColor = UIColor.Purple;

        }

		partial void ViewQuestionsButton_TouchUpInside(UIButton sender)
		{
			//create a QuestionsViewController
			QuestionsViewController QuestionsVC = new QuestionsViewController();

			//display QuestionsVC
			NavigationController.PushViewController(QuestionsVC, true);
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void NewGameButton_TouchUpInside(UIButton sender)
        {
            
        }
    }
}

