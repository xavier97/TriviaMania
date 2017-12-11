using System;
using System.Collections.Generic;
using UIKit;

namespace MobileAppClass
{
	public partial class EnterDataViewController : UIViewController
	{
		private TriviaQuestionsRecord DataToLoad;

		//Constructors
//------------------------------------------------------------------------------------------------------------
		public EnterDataViewController() : base("EnterDataViewController", null)
		{
		}

		public EnterDataViewController(TriviaQuestionsRecord QuestionObj) : base("EnterDataViewController", null)
		{
			DataToLoad = QuestionObj;
		}
//------------------------------------------------------------------------------------------------------------
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			//Create Save Button
			UIBarButtonItem SaveButton = new UIBarButtonItem("Save", UIBarButtonItemStyle.Plain, SaveTap);
			NavigationItem.RightBarButtonItem = SaveButton;

			//If the user tapped a cell to open this vc load the data!
			if (DataToLoad != null)
			{
				QuestionField.Text = DataToLoad.question;
				CorrectAnswer.Text = DataToLoad.answer;
				false1.Text = DataToLoad.falseQ1;
				false2.Text = DataToLoad.falseQ2;
				false3.Text = DataToLoad.falseQ3;
			}

		}

		void SaveTap(object sender, EventArgs e)
		{
			//TODO write save logic

			NavigationController.PopViewController(true);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

