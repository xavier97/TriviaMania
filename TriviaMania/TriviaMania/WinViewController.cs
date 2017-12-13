﻿using System;

using UIKit;

namespace MobileAppClass
{
	public partial class WinViewController : UIViewController
	{
		
		public WinViewController() : base("WinViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void ReturnHomeButton_TouchUpInside(UIButton sender)
		{
			this.DismissViewController(true, null);
			NavigationController.DismissViewController(true, null);
		}
	}
}

