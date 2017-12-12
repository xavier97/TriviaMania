using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UIKit;

namespace MobileAppClass
{
	public partial class EnterDataViewController : UIViewController
	{
		private List<TriviaQuestionsRecord> TriviaQuestonsList = new List<TriviaQuestionsRecord>();
		private TriviaQuestionsRecord DataToLoad;

		//Constructors
//------------------------------------------------------------------------------------------------------------
		public EnterDataViewController(List<TriviaQuestionsRecord> templist) : base("EnterDataViewController", null)
		{
			TriviaQuestonsList = templist;
		}

		public EnterDataViewController(TriviaQuestionsRecord QuestionObj, List<TriviaQuestionsRecord> templist) : base("EnterDataViewController", null)
		{
			TriviaQuestonsList = templist;
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
			if (DataToLoad != null)
			{
				DataToLoad.question = QuestionField.Text;
				DataToLoad.answer = CorrectAnswer.Text;
				DataToLoad.falseQ1 = false1.Text;
				DataToLoad.falseQ2 = false2.Text;
				DataToLoad.falseQ3 = false3.Text;
				DataToLoad.DateCreated = DateTime.Now;

				//Remove old question
				var itemToRemove = TriviaQuestonsList.Single(r => r.QuestionID == DataToLoad.QuestionID);
				TriviaQuestonsList.Remove(itemToRemove);

				//Add edited question
				TriviaQuestonsList.Add(DataToLoad);

				//Save to json file
				var myJson = JsonConvert.SerializeObject(TriviaQuestonsList);

				using (var streamwriter = new StreamWriter(AppDelegate.pathFile, false))
				{
					streamwriter.Write(myJson);
				}

			}
			else
			{
				//Create new question
				TriviaQuestionsRecord NewQuestion = new TriviaQuestionsRecord(QuestionField.Text, CorrectAnswer.Text,
				                                                              false1.Text, false2.Text, false3.Text);
				//Add to list
				TriviaQuestonsList.Add(NewQuestion);

				//Save to json file
				var myJson = JsonConvert.SerializeObject(TriviaQuestonsList);

				using (var streamwriter = new StreamWriter(AppDelegate.pathFile, false))
				{
					streamwriter.Write(myJson);
				}

			}

			NavigationController.PopViewController(true);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

