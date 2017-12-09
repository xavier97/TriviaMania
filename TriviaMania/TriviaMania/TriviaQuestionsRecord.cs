using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MobileAppClass
{
    public class TriviaQuestionsRecord
    {
		public string QuestionID { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string falseQ1 { get; set; }
        public string falseQ2 { get; set; }
		public string falseQ3 { get; set; }

        public TriviaQuestionsRecord(string q, string a, string f1, string f2, string f3)
        {
			question = q;
			answer = a;
			falseQ1 = f1;
			falseQ2 = f2;
			falseQ3 = f3;

			QuestionID = question.Substring(0, 10) + answer.Substring(0,3) + GetRandomInt().ToString();
		}

		public int GetRandomInt()
		{
			Random rand = new Random();
			int num = rand.Next(1000, 9999);
    		return num;
		}
    }
}