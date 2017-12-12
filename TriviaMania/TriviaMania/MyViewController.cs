using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UIKit;

namespace MobileAppClass
{
    public partial class MyViewController : UIViewController
    {
		private List<TriviaQuestionsRecord> StarterQuestionsList = new List<TriviaQuestionsRecord>();

        public MyViewController() : base("MyViewController", null)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Add navigation bar title
			NavigationItem.Title = "Trivia Mania";
			NavigationController.NavigationBar.BackgroundColor = UIColor.Purple;

			if (File.Exists(AppDelegate.pathFile) == false)
			{
				//Starter Questions
				TriviaQuestionsRecord Q1 = new TriviaQuestionsRecord("Which body of land is not a contient?",
																	 "Middle East", "Asia", "Antartica", "Europe");
				TriviaQuestionsRecord Q2 = new TriviaQuestionsRecord("What day of the year is Christmas?",
																	 "December 25th", "December 8th", "July 4th", "I'm running out of ideas");
				TriviaQuestionsRecord Q3 = new TriviaQuestionsRecord("What does the fox say?",
																	 "Ring-ding-ding-dingeringeding!", "Woof", "Meow", "Toot Toot");
				TriviaQuestionsRecord Q4 = new TriviaQuestionsRecord("How many days are in a year?", "365", "300", "465", "52");
				TriviaQuestionsRecord Q5 = new TriviaQuestionsRecord("What is Overwatch?", "A video game", "A movie",
																	 "A TV show", "A book");

				StarterQuestionsList.Add(Q1);
				StarterQuestionsList.Add(Q2);
				StarterQuestionsList.Add(Q3);
				StarterQuestionsList.Add(Q4);
				StarterQuestionsList.Add(Q5);

				//Write everything to the file
				var myJson = JsonConvert.SerializeObject(StarterQuestionsList);

				using (var streamwriter = new StreamWriter(AppDelegate.pathFile, false))
				{
					streamwriter.Write(myJson);
				}
			}

		}

        partial void ViewQuestionsButton_TouchUpInside(UIButton sender)
        {
			//create a QuestionsViewController
            QuestionsViewController QuestionsVC = new QuestionsViewController();

			//display QuestionsVC
			NavigationController.PushViewController(QuestionsVC, true);
		}

        partial void NewGameButton_TouchUpInside(UIButton sender)
        {
            // Create a TriviaViewController1
            TriviaViewController1 TriviaVC = new TriviaViewController1();

            // Display TriviaVC
            NavigationController.PushViewController(TriviaVC, true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

    }
}

