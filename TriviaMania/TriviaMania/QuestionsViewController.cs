using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace MobileAppClass
{
	public partial class QuestionsViewController : UIViewController
	{
		public QuestionsViewController() : base("QuestionsViewController", null)
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
	}

	#region QuestionsTableView source code
	/* public class QuestionsTableSource : UITableViewSource  //Inherit UITableViewSource library
	{
		QuestionsViewController vc; //An instance of QuestionsViewController
		private List<TriviaQuestionsRecord> ListofTriviaQuestions = new List<TriviaQuestionsRecord>(); //A list of TriviaQuestionsRecords

		//constructor
		//ListofTriviaQuestions and the vc are passed into tableview
		public QuestionsTableSource(QuestionsViewController vc_in)
		{
			ListofTriviaQuestions
			vc = vc_in;
		}

	} */

	#endregion
}

