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
		int MinimumQuestions = 15;

        public MyViewController() : base("MyViewController", null)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Add navigation bar title
			//NavigationItem.Title = "Trivia Mania";
			NavigationController.NavigationBar.BackgroundColor = UIColor.Purple;

			if (File.Exists(AppDelegate.triviaPathFile) == false)
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
				TriviaQuestionsRecord Q6 = new TriviaQuestionsRecord("Which is not a Pokemon?", "Maurosaur", "Squirtle", "Mewtwo", "Pikachu");
				TriviaQuestionsRecord Q7 = new TriviaQuestionsRecord("What is the capitol of China?", "Beijing", "Shanghai", "Tokyo", "Washington DC");
				TriviaQuestionsRecord Q8 = new TriviaQuestionsRecord("What in not a monster from Monster Hunter?", 
				                                                     "Groudon", "Rathalos", "Lagiacrus", "Gore Magala");
				TriviaQuestionsRecord Q9 = new TriviaQuestionsRecord("How many Oceans are there?", "5", "7", "10", "1");
				TriviaQuestionsRecord Q10 = new TriviaQuestionsRecord("Who's the secretary of state?", "Rex Tillerson", "Obama", "Bilitski", "Jeff Sessions");
				TriviaQuestionsRecord Q11 = new TriviaQuestionsRecord("Who was the first Nasa astronaut to visit space twice?", 
				                                                      "Gus Grissom", "Neil Armstrong", "Franz Viehbock", "Bilitski");
				TriviaQuestionsRecord Q12 = new TriviaQuestionsRecord("2 + 2 = ?", "4", "3", "5", "Math is hard");
				TriviaQuestionsRecord Q13 = new TriviaQuestionsRecord("What is the sixth planet from the sun?", "Saturn", "Jupiter", "Earth", "There are only 5 planets");
				TriviaQuestionsRecord Q14 = new TriviaQuestionsRecord("When was the movie It's a Wonderful Life released?", "1946", "1949", "1996", "1962");
				TriviaQuestionsRecord Q15 = new TriviaQuestionsRecord("What is the correct way to write to the console in C#", 
				                                                      "Console.WriteLine(\"Hello\");", "Put(\"Hello\");", "cout << \"Hello\";", "System.PrintLn(\"Hello\");");

				StarterQuestionsList.Add(Q1);
				StarterQuestionsList.Add(Q2);
				StarterQuestionsList.Add(Q3);
				StarterQuestionsList.Add(Q4);
				StarterQuestionsList.Add(Q5);
				StarterQuestionsList.Add(Q6);
				StarterQuestionsList.Add(Q7);
				StarterQuestionsList.Add(Q8);
				StarterQuestionsList.Add(Q9);
				StarterQuestionsList.Add(Q10);
				StarterQuestionsList.Add(Q11);
				StarterQuestionsList.Add(Q12);
				StarterQuestionsList.Add(Q13);
				StarterQuestionsList.Add(Q14);
				StarterQuestionsList.Add(Q15);

				//Write everything to the file
				var myJson = JsonConvert.SerializeObject(StarterQuestionsList);

				using (var streamwriter = new StreamWriter(AppDelegate.triviaPathFile, false))
				{
					streamwriter.Write(myJson);
				}
			}

			if (File.Exists(AppDelegate.highScorePathFile) == false)
			{
				//Write everything to the file
				using (var streamwriter = new StreamWriter(AppDelegate.highScorePathFile, false))
				{
					streamwriter.Write(0);
				}
			}

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			//Deserialize json file and add it to a list
			var jsonData = File.ReadAllText(AppDelegate.highScorePathFile);
			HighScoreLabel.Text = "High score: " + JsonConvert.DeserializeObject(jsonData);
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
			//If there are less than 15 questions in the list, push alert
			var jsonData = File.ReadAllText(AppDelegate.triviaPathFile);
			if (JsonConvert.DeserializeObject<List<TriviaQuestionsRecord>>(jsonData).Count < MinimumQuestions)
			{
				AlertMessage();
				return;
			}

            // Create a TriviaViewController1
            TriviaViewController1 TriviaVC = new TriviaViewController1();

            // Display TriviaVC
            //NavigationController.PushViewController(TriviaVC, true);
			this.PresentViewController(TriviaVC, true, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

		//Alert message
		public void AlertMessage()
		{
			//Create alert
			UIAlertController QuestionErrorAlert;
			QuestionErrorAlert = UIAlertController.Create("Cannot start New Game", "Must have at least 15 questions to start", UIAlertControllerStyle.Alert);

			//Create cancel button
			UIAlertAction CancelButton = UIAlertAction.Create("Okay", UIAlertActionStyle.Cancel, null);

			//Show cancel button
			QuestionErrorAlert.AddAction(CancelButton);

			//Show the alert
			this.PresentViewController(QuestionErrorAlert, false, null);
		}

    }
}

