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

			//read file 
			var jsonData = File.ReadAllText(AppDelegate.highScorePathFile);
			using (StreamReader streamreader = new StreamReader(AppDelegate.highScorePathFile))
			{
				highScore  = streamreader.Read();	
			}
			highScoreLabel.Text = highScore.ToString();

			scoreLabel.Text = score.ToString();
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);

			if (score > highScore)
			{
				//save new highscore
				using (var streamwriter = new StreamWriter(AppDelegate.highScorePathFile, false))
				{
					streamwriter.Write(score);
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
		}
	}
}

