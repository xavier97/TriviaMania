using System;

using UIKit;

namespace MobileAppClass
{
	public partial class EnterDataViewController : UIViewController
	{
		public EnterDataViewController() : base("EnterDataViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			//Create Save Button
			UIBarButtonItem SaveButton = new UIBarButtonItem("Save", UIBarButtonItemStyle.Plain, SaveTap);
			NavigationItem.RightBarButtonItem = SaveButton;
		}

		void SaveTap(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

