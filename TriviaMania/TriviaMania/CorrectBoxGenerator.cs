using System;
namespace MobileAppClass
{
    public class CorrectBoxGenerator
    {

        int answerButtonNumber;
        private static CorrectBoxGenerator instance;

        private CorrectBoxGenerator()
        {
            // Generate a random number 1-4
            Random rnd = new Random();
            answerButtonNumber = rnd.Next(1, 4);
        }

        public static CorrectBoxGenerator GetInstance()
        {
            if (instance == null)
            {
                instance = new CorrectBoxGenerator();
            }

            return instance;
        }

        // Return the correct answer box
        public int AnswerBox()
        {
            return answerButtonNumber;
        }
    }
}
