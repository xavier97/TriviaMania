﻿using System;
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

		public DateTime DateCreated;

		public TriviaQuestionsRecord(string q, string a, string f1, string f2, string f3)
		{
			question = q;
			answer = a;
			falseQ1 = f1;
			falseQ2 = f2;
			falseQ3 = f3;

			//Create unique question ID
			QuestionID = question[0].ToString() + answer[0].ToString()
			                        + falseQ1[0].ToString() + falseQ2[0].ToString() 
			                        + falseQ3[0].ToString() + GetRandomInt().ToString();

			DateCreated = DateTime.Now;
		}

		//Would not deserialize unless there was an empty constructor??
		public TriviaQuestionsRecord()
		{
			
		}

		public int GetRandomInt()
		{
			Random rand = new Random();
			int num = rand.Next(1000, 9999);
    		return num;
		}
    }
}