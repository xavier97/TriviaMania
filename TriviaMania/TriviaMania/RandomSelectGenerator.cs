using System;
using System.Collections.Generic;
namespace MobileAppClass
{
    public class RandomSelectGenerator
    {
        List<int> pickedQuestions = new List<int>(); // Questions already asked

        int answerButtonNumber;
        int questionNumber;
        private static RandomSelectGenerator instance;

        private RandomSelectGenerator()
        {
            // Generate a random number 1-4 [for AnswerBox()]
            Random rnd = new Random();
            answerButtonNumber = rnd.Next(1, 5);
        }

        public static RandomSelectGenerator GetInstance()
        {
            if (instance == null)
            {
                instance = new RandomSelectGenerator();
            }

            return instance;
        }

        // Return the correct answer box
        public int AnswerBox()
        {
            return answerButtonNumber;
        }

        // Returns number of a random question to select from the list
        public int RandomQuestion(int numOfListQuestions)
        {
            // Generate a random number 1 - Number of Questions
            // Don't repeat a question already asked; store those in a pickedQuestion list
            Random rnd = new Random();
            questionNumber = rnd.Next(0, numOfListQuestions);

            while (pickedQuestions.Contains(questionNumber))
            {
                questionNumber = rnd.Next(0, numOfListQuestions);
            }
            pickedQuestions.Add(questionNumber); // Add to list of picked questions

            return questionNumber;
        }
    }
}
