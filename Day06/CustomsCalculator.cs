using System.Collections.Generic;
using System.Linq;
using Day06.Enums;

namespace Day06
{
    public static class CustomsCalculator
    {
        public static int Calculate(CalculationType calculationType, string[] customsAnswersInput)
        {
            var result = 0;

            switch (calculationType)
            {
                case CalculationType.QuestionsAnyoneAnswered:
                    result = CalculateNumberOfQuestionsAnyoneAnswered(customsAnswersInput);
                    break;
                case CalculationType.QuestionsEveryoneAnswered:
                    result = CalculateNumberOfQuestionsEveryoneAnswered(customsAnswersInput);
                    break;
            }

            return result;
        }

        public static int CalculateNumberOfQuestionsAnyoneAnswered(string[] customsAnswersInput)
        {
            var normalisedCustomsAnswers = NormaliseCustomsAnswers(customsAnswersInput);

            var totalNumberOfAnsweredQuestions = 0;

            foreach (var normalisedCustomsAnswer in normalisedCustomsAnswers)
            {
                var customsAnswerCharArray = normalisedCustomsAnswer.ToCharArray();
                var numberOfDistinctQuestionsAnswered = customsAnswerCharArray.Distinct().Count();

                totalNumberOfAnsweredQuestions += numberOfDistinctQuestionsAnswered;
            }

            return totalNumberOfAnsweredQuestions;
        }

        public static int CalculateNumberOfQuestionsEveryoneAnswered(string[] customsAnswersInput)
        {
            var normalisedCustomsAnswers = NormaliseCustomsAnswersPerGroup(customsAnswersInput);

            var totalNumberOfAnsweredQuestions = 0;

            char[] alphabet = "abcdefghijklmnopqrstuwvxyz".ToCharArray();
            foreach (var normalisedCustomsAnswer in normalisedCustomsAnswers)
            {
                foreach (var letter in alphabet)
                {
                    if (normalisedCustomsAnswer.All(x => x.Contains(letter)))
                    {
                        totalNumberOfAnsweredQuestions++;
                    }
                }
            }

            return totalNumberOfAnsweredQuestions;
        }

        private static List<string> NormaliseCustomsAnswers(string[] customsAnswersInput)
        {
            var customsAnswers = new List<string>();
            var lastEntry = string.Empty;

            foreach (var customsAnswer in customsAnswersInput)
            {
                if (string.IsNullOrWhiteSpace(customsAnswer))
                {
                    customsAnswers.Add(lastEntry);
                    lastEntry = string.Empty;
                }

                if (string.IsNullOrWhiteSpace(lastEntry))
                {
                    lastEntry = customsAnswer;
                }
                else
                {
                    lastEntry += customsAnswer;
                }
            }

            customsAnswers.Add(lastEntry);

            return customsAnswers;
        }

        private static List<List<string>> NormaliseCustomsAnswersPerGroup(string[] customsAnswersInput)
        {
            var customsAnswers = new List<List<string>>();
            var lastEntry = new List<string>();

            foreach (var customsAnswer in customsAnswersInput)
            {
                if (string.IsNullOrWhiteSpace(customsAnswer))
                {
                    customsAnswers.Add(lastEntry);
                    lastEntry = new List<string>();
                }
                else
                {
                    lastEntry.Add(customsAnswer);
                }
            }

            customsAnswers.Add(lastEntry);

            return customsAnswers;
        }
    }
}
