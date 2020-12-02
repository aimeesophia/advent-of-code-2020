using System.Collections.Generic;
using System.Linq;
using Day2.Enums;
using Day2.Models;

namespace Day2
{
    public static class PasswordValidator
    {
        public static int Validate(ValidationType validationType, List<string> passwordDatabaseList)
        {
            var numberOfValidPasswords = 0;
            var passwordObjects = CreatePasswordObjects(passwordDatabaseList);

            switch (validationType)
            {
                case ValidationType.MinMaxAmountOfRequiredCharacter:
                    numberOfValidPasswords = GetNumberOfValidPasswordsByMinMaxAmountOfRequiredCharacter(passwordObjects);
                    break;
                case ValidationType.PositionOfRequiredCharacter:
                    numberOfValidPasswords = GetNumberOfValidPasswordsByPositionOfRequiredCharacter(passwordObjects);
                    break;
            }

            return numberOfValidPasswords;
        }

        private static List<Password> CreatePasswordObjects(List<string> passwordDatabaseList)
        {
            var passwordObjects = new List<Password>();

            foreach (var password in passwordDatabaseList)
            {
                passwordObjects.Add(new Password(password));
            }

            return passwordObjects;
        }

        private static int GetNumberOfValidPasswordsByMinMaxAmountOfRequiredCharacter(List<Password> passwordObjects)
        {
            var numberOfValidPasswords = 0;

            foreach (var passwordObject in passwordObjects)
            {
                var passwordTextCharacters = passwordObject.PasswordText.ToCharArray().ToList();
                var numberOfRequiredCharacter = passwordTextCharacters.Count(character => character.Equals(passwordObject.Character));

                if (numberOfRequiredCharacter >= passwordObject.PolicyNumbers.First() &&
                    numberOfRequiredCharacter <= passwordObject.PolicyNumbers.Last())
                {
                    numberOfValidPasswords++;
                }
            }

            return numberOfValidPasswords;
        }

        private static int GetNumberOfValidPasswordsByPositionOfRequiredCharacter(List<Password> passwordObjects)
        {
            var numberOfValidPasswords = 0;

            foreach (var passwordObject in passwordObjects)
            {
                var passwordTextCharacters = passwordObject.PasswordText.ToCharArray().ToList();

                if (passwordTextCharacters.Count >= passwordObject.PolicyNumbers.Last())
                {
                    var numberOfTimesRequiredCharacterAppearsInPolicyNumberPosition = 0;

                    foreach (var passwordObjectPolicyNumber in passwordObject.PolicyNumbers)
                    {
                        if (passwordTextCharacters[passwordObjectPolicyNumber - 1] == passwordObject.Character)
                        {
                            numberOfTimesRequiredCharacterAppearsInPolicyNumberPosition++;
                        }
                    }

                    if (numberOfTimesRequiredCharacterAppearsInPolicyNumberPosition == 1)
                    {
                        numberOfValidPasswords++;
                    }
                }
            }

            return numberOfValidPasswords;
        }
    }
}
