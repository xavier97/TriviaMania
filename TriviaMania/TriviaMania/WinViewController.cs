using System;
using System.IO;
using Newtonsoft.Json;
using UIKit;

namespace MobileAppClass
{
	public partial class WinViewController : UIViewController
	{
		int score;
		int highScore;

		public WinViewController(int _score) : base("WinViewController", null)
		{
			score = _score;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			//Deserialize json file and add it to a list
			var jsonData = File.ReadAllText(AppDelegate.highScorePathFile);
			highScore = (int)JsonConvert.DeserializeObject(jsonData);
			highScoreLabel.Text = highScore.ToString();

			scoreLabel.Text = score.ToString();
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);

			if (score > highScore)
			{
				//save new highscore
				var myJson = JsonConvert.SerializeObject(highScore);

				using (var streamwriter = new StreamWriter(AppDelegate.highScorePathFile, false))
				{
					streamwriter.Write(myJson);
				}
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void ReturnHomeButton_TouchUpInside(UIButton sender)
		{
			this.DismissViewController(true, null);
			//NavigationController.DismissViewController(true, null);
		}
	}
}

