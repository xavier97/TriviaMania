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

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			//Create Tableview
			QuestionsTableView.Source = new QuestionsViewController.QuestionsTableSource(this);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		#region QuestionsTableView source code

		public class QuestionsTableSource : UITableViewSource  //Inherit UITableViewSource library
		{
			QuestionsViewController vc; //An instance of QuestionsViewController
			private List<TriviaQuestionsRecord> ListofTriviaQuestions = new List<TriviaQuestionsRecord>(); //A list of TriviaQuestionsRecords

			//constructor
			//ListofTriviaQuestions and the vc are passed into tableview
			public QuestionsTableSource(QuestionsViewController vc_in)
			{
				vc = vc_in;
			}

			//Only one section in the tableview
			public override nint NumberOfSections(UITableView tableView)
			{
				return 1;
			}

			//Assign each cell in the tableview to be one spikeballGame object from the SortedList
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{

				UITableViewCell cell;
				// try to get a reusable cell
				cell = tableView.DequeueReusableCell("TriviaQuestion");
				if (cell == null)
				{
					cell = new UITableViewCell(UITableViewCellStyle.Subtitle, "TriviaQuestion");
				}

				//What text is shown in the cells
				if (indexPath.Section == 0)
				{
					cell.TextLabel.Text = ListofTriviaQuestions[indexPath.Row].question;
					cell.DetailTextLabel.Text = ListofTriviaQuestions[indexPath.Row].answer;
					cell.DetailTextLabel.TextColor = UIColor.Purple;
					cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				}

				return cell;
			}

			//Number of rows in the section is equal to number of objects in ListofSpikeballGames
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return ListofTriviaQuestions.Count;
			}

			//When the user taps a cell display EnterDataViewController and pass the content of the cell into it
			//public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			//{
			//create a EnterDataViewController
			//	EnterDataViewController EnterDataVC = new EnterDataViewController(SortedList[indexPath.Row]);

			//display EnterDataVC
			//	vc.NavigationController.PushViewController(EnterDataVC, true            }

		}

		#endregion
	}
}

