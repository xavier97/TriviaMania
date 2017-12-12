using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Foundation;
using Newtonsoft.Json;
using UIKit;

namespace MobileAppClass
{
	public partial class QuestionsViewController : UIViewController
	{
		public List<TriviaQuestionsRecord> ListofQuestions = new List<TriviaQuestionsRecord>();

		public QuestionsViewController() : base("QuestionsViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			//Create Add question Button
			UIBarButtonItem AddButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddTap);
			NavigationItem.RightBarButtonItem = AddButton;

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			//Deserialize json file and add it to a list
			var jsonData = File.ReadAllText(AppDelegate.pathFile);
			ListofQuestions = JsonConvert.DeserializeObject<List<TriviaQuestionsRecord>>(jsonData);

			//Create Tableview
			QuestionsTableView.Source = new QuestionsViewController.QuestionsTableSource(this);
		}

		//When the add button gets tapped
		void AddTap(object sender, EventArgs e)
		{
			//create a EnterDataViewController
			EnterDataViewController EnterDataVC = new EnterDataViewController(ListofQuestions);

			//display EnterDataVC
			this.NavigationController.PushViewController(EnterDataVC, true);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		#region QuestionsTableView source code
//---------------------------------------------------------------------------------------------------------------------
		public class QuestionsTableSource : UITableViewSource  //Inherit UITableViewSource library
		{
			private List<TriviaQuestionsRecord> ListofTriviaQuestions = new List<TriviaQuestionsRecord>(); //A list of TriviaQuestionsRecords
			QuestionsViewController vc; //An instance of QuestionsViewController

			//constructor
			//QuestionsViewController is passed into tableview
			public QuestionsTableSource(QuestionsViewController vc_in)
			{
				//Json file is deserialized and added it to a list
				var jsonData = File.ReadAllText(AppDelegate.pathFile);
				ListofTriviaQuestions = JsonConvert.DeserializeObject<List<TriviaQuestionsRecord>>(jsonData);

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
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				//create a EnterDataViewController
				EnterDataViewController EnterDataVC = new EnterDataViewController(ListofTriviaQuestions[indexPath.Row],
																				  ListofTriviaQuestions);
				                                                                
				//display EnterDataVC
				vc.NavigationController.PushViewController(EnterDataVC, true);
			}

			//Delete a question
			public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
			{
				switch (editingStyle)
				{
					case UITableViewCellEditingStyle.Delete:

						//Find question in the list using it's questionID
						var itemToRemove = ListofTriviaQuestions.Single(r => r.QuestionID == ListofTriviaQuestions[indexPath.Row].QuestionID);

						//Remove question from the list
						ListofTriviaQuestions.Remove(itemToRemove);

						//Save changes to json file
						var myJson = JsonConvert.SerializeObject(ListofTriviaQuestions);

						using (var streamwriter = new StreamWriter(AppDelegate.pathFile, false))
						{
							streamwriter.Write(myJson);
						}

						// delete the row from the table
						tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
						break;
					case UITableViewCellEditingStyle.None:
						Console.WriteLine("CommitEditingStyle:None called");
						break;
				}
			}

		}
//---------------------------------------------------------------------------------------------------------------------
		#endregion
	}
}

