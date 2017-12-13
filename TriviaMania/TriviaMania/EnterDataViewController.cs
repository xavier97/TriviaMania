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

			//If the user tapped a cell to open this vc load the question data
			if (DataToLoad != null)
			{
				QuestionField.Text = DataToLoad.question;
				CorrectAnswer.Text = DataToLoad.answer;
				false1.Text = DataToLoad.falseQ1;
				false2.Text = DataToLoad.falseQ2;
				false3.Text = DataToLoad.falseQ3;
			}

		}

		#region save button code
//---------------------------------------------------------------------------------------------------------------------
		void SaveTap(object sender, EventArgs e)
		{
			int MaxQuestionLength = 150;
			int MaxAnswerLength = 45;
			string errorToShow;
			string errorDetails;

			//If any text fields are left blank raise an error
			if (QuestionField.Text.Trim() == @"" || CorrectAnswer.Text.Trim() == @"" || false1.Text.Trim() == @"" ||
			    false2.Text.Trim() == @"" || false3.Text.Trim() == @"")
			{
				errorToShow = "Cannot save question";
				errorDetails = "Text fields left blank";

				ErrorMessage(errorToShow, errorDetails);

				return;
			}

			//If any of the text fields are over the charcater limit, raise error
			if (QuestionField.Text.Length > MaxQuestionLength)
			{
				errorToShow = "Question too long";
				errorDetails = "Question exceeds 150 character limit";

				ErrorMessage(errorToShow, errorDetails);

				return;
			}
			else if (CorrectAnswer.Text.Length > MaxAnswerLength || false1.Text.Length > MaxAnswerLength ||
					false2.Text.Length > MaxAnswerLength || false3.Text.Length > MaxAnswerLength)
			{
				errorToShow = "Answer too long";
				errorDetails = "Answers must be less than 45 charcaters";

				ErrorMessage(errorToShow, errorDetails);

				return;
			}
				

			//If the user is editing an already existing question, save the edits
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

				using (var streamwriter = new StreamWriter(AppDelegate.triviaPathFile, false))
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

				using (var streamwriter = new StreamWriter(AppDelegate.triviaPathFile, false))
				{
					streamwriter.Write(myJson);
				}

			}

			NavigationController.PopViewController(true);
		}
//---------------------------------------------------------------------------------------------------------------------
  		#endregion

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		//Error message
		public void ErrorMessage(string error, string details)
		{
			//Create alert
			UIAlertController QuestionErrorAlert;
			QuestionErrorAlert = UIAlertController.Create(error, details, UIAlertControllerStyle.Alert);

			//Create cancel button
			UIAlertAction CancelButton = UIAlertAction.Create("Okay", UIAlertActionStyle.Cancel, null);

			//Show cancel button
			QuestionErrorAlert.AddAction(CancelButton);

			//Show the alert
			this.PresentViewController(QuestionErrorAlert, false, null);
		}
	}
}

