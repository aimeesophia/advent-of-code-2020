using System;
using System.Collections.Generic;
using System.Linq;
using Day07.Enums;

namespace Day07
{
    public static class LuggageProcessor
    {
        private static Dictionary<string, List<KeyValuePair<int, string>>> _luggageRules;
        private static Dictionary<string, List<KeyValuePair<int, string>>> _acceptableBags = new Dictionary<string, List<KeyValuePair<int, string>>>();
        private static int _totalNumberOfBagsInside;

        public static int ProcessRules(string[] luggageRules, string bagColour, LuggageProcessorType luggageProcessorType)
        {
            _luggageRules = NormaliseLuggageRules(luggageRules);

            switch (luggageProcessorType)
            {
                case LuggageProcessorType.TotalNumberOfBagsThatCanEventuallyContainSpecificBagColour:
                    FindBagColourInLuggageRules(bagColour);
                    return _acceptableBags.Count;
                case LuggageProcessorType.TotalNumberOfBagsContainedWithinSpecificBagColour:
                    FindNumberOfBagsInside(bagColour);
                    return _totalNumberOfBagsInside;
                default:
                    return 0;
            }
        }

        private static void FindBagColourInLuggageRules(string bagColour)
        {
            var foundLuggageRules = _luggageRules
                .Where(x => x.Value.Any(y => y.Value.Equals(bagColour)))
                .ToDictionary(x => x.Key, x => x.Value);

            if (foundLuggageRules.Count == 0)
            {
                return;
            }

            foreach (var foundLuggageRule in foundLuggageRules)
            {
                if (!_acceptableBags.ContainsKey(foundLuggageRule.Key))
                {
                    _acceptableBags.Add(foundLuggageRule.Key, foundLuggageRule.Value);
                }

                FindBagColourInLuggageRules(foundLuggageRule.Key);
            }
        }

        private static void FindNumberOfBagsInside(string bagColour)
        {
            var foundBag = _luggageRules.FirstOrDefault(x => x.Key.Equals(bagColour));

            if (foundBag.Key == null)
            {
                return;
            }

            if (foundBag.Value.Count == 0)
            {
                return;
            }

            foreach (var innerBag in foundBag.Value)
            {
                for (int i = 0; i < innerBag.Key; i++)
                {
                    _totalNumberOfBagsInside++;

                    FindNumberOfBagsInside(innerBag.Value);
                }
            }
        }

        private static Dictionary<string, List<KeyValuePair<int, string>>> NormaliseLuggageRules(string[] luggageRules)
        {
            var normalisedLuggageRules = new Dictionary<string, List<KeyValuePair<int, string>>>();

            foreach (var luggageRule in luggageRules)
            {
                var luggageRuleRemovedBagStrings = luggageRule.Replace(" bags", "").Replace(" bag", "").Replace(".", "");
                var splitLuggageRule = luggageRuleRemovedBagStrings.Split(" contain ");

                if (splitLuggageRule[1] != "no other")
                {
                    var valueArray = splitLuggageRule[1].Split(", ");
                    var valueDictionary = new List<KeyValuePair<int, string>>();

                    foreach (var stringValue in valueArray)
                    {
                        var index = stringValue.IndexOf(' ');
                        var amount = stringValue.Substring(0, index);
                        var bagColour = stringValue.Substring(index, stringValue.Length - index).Trim();
                        
                        valueDictionary.Add(new KeyValuePair<int, string>(int.Parse(amount), bagColour));
                    }

                    normalisedLuggageRules.Add(splitLuggageRule[0], valueDictionary);
                }
                else
                {
                    normalisedLuggageRules.Add(splitLuggageRule[0], new List<KeyValuePair<int, string>>());
                }
            }

            return normalisedLuggageRules;
        }
    }
}
