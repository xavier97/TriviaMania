using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using Newtonsoft.Json;
using UIKit;

namespace MobileAppClass
{
	public partial class QuestionsViewController : UIViewController
	{
		private List<TriviaQuestionsRecord> StarterQuestionsList = new List<TriviaQuestionsRecord>();

		public QuestionsViewController() : base("QuestionsViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			TriviaQuestionsRecord Q1 = new TriviaQuestionsRecord("Which body of land is not a contient?",
																 "Middle East", "Asia", "Antartica", "Europe");
			TriviaQuestionsRecord Q2 = new TriviaQuestionsRecord("What day of the year is Christmas?",
																 "December 25th", "December 8th", "July 4th", "I'm running out of ideas");

			StarterQuestionsList.Add(Q1);
			StarterQuestionsList.Add(Q2);

			//Write everything to the file
			var myJson = JsonConvert.SerializeObject(StarterQuestionsList);

			using (var streamwriter = new StreamWriter(AppDelegate.pathFile, false))
			{
				streamwriter.Write(myJson); 
			}

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			//Create Tableview
			QuestionsTableView.Source = new QuestionsViewController.QuestionsTableSource(this, StarterQuestionsList);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		#region QuestionsTableView source code

		public class QuestionsTableSource : UITableViewSource  //Inherit UITableViewSource library
		{
			private List<TriviaQuestionsRecord> ListofTriviaQuestions = new List<TriviaQuestionsRecord>(); //A list of TriviaQuestionsRecords
			QuestionsViewController vc; //An instance of QuestionsViewController

			//constructor
			//ListofTriviaQuestions and the vc are passed into tableview
			public QuestionsTableSource(QuestionsViewController vc_in, List<TriviaQuestionsRecord> templist)
			{
				var jsonData = File.ReadAllText(AppDelegate.pathFile);
				Console.WriteLine(jsonData);
				ListofTriviaQuestions = templist;
				//JsonConvert.DeserializeObject<List<TriviaQuestionsRecord>>(jsonData);

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
					cell.DetailTextLabel.Text = ListofTriviaQuestions[indexPath.Row].DateCreated.ToString("g");
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

