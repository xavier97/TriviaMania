using System;
using System.Collections.Generic;
namespace MobileAppClass
{
    public class RandomSelectGenerator
    {
        List<int> pickedQuestions = new List<int>(); // Questions already asked
        int answerButtonNumber; // The button number we'll hide the correct answer at
        private static RandomSelectGenerator instance; // Singleton instance

        private RandomSelectGenerator()
        {
            // TODO: This gotta go somewhere else -- constructor only called once in a singleton
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
            int questionNumber = rnd.Next(0, numOfListQuestions);

            while (pickedQuestions.Contains(questionNumber))
            {
                questionNumber = rnd.Next(0, numOfListQuestions);
            }
            pickedQuestions.Add(questionNumber); // Add to list of picked questions

            return questionNumber;
        }
    }

    public class RandNumGen2
    {
        public RandNumGen2()
        {
        }

        // Returns the correct answer box
        public int AnswerBox()
        {
            Random rnd = new Random();
            int answerButtonNumber = rnd.Next(1, 5);

            return 1;
        }

        // Returns number of a random question to select from the list
        public int RandomQuestion(int numOfListQuestions)
        {
            // Generate a random number 1 - Number of Questions
            // Don't repeat a question already asked; store those in a pickedQuestion list
            Random rnd = new Random();
            int questionNumber = rnd.Next(0, numOfListQuestions);

            List<int> pickedQuestions = new List<int>(); // Questions already asked

            while (pickedQuestions.Contains(questionNumber))
            {
                questionNumber = rnd.Next(0, numOfListQuestions);
            }
            pickedQuestions.Add(questionNumber); // Add to list of picked questions

            return questionNumber;
        }

    }
}
