using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using Day4.Models;

namespace Day4
{
    public static class PassportValidator
    {
        public static int Validate(List<string> passportData)
        {
            var normalisedPassportData = NormalisePassportData(passportData);
            var serialisedPassportData = CreateSerialisedPassportData(normalisedPassportData);

            var passportObjects = serialisedPassportData.Select(x => JsonSerializer.Deserialize<Passport>(x));

            var numberOfValidPassports = 0;
            foreach (var passportObject in passportObjects)
            {
                var validationContext = new ValidationContext(passportObject);
                var isValid = Validator.TryValidateObject(passportObject, validationContext,
                    new List<ValidationResult>(), true);

                if (isValid)
                {
                    numberOfValidPassports++;
                }
            }

            return numberOfValidPassports;
        }

        private static List<string> NormalisePassportData(List<string> passportData)
        {
            var normalisedPassportData = new List<string>();
            var lastEntry = string.Empty;

            foreach (var entry in passportData)
            {
                if (string.IsNullOrWhiteSpace(entry))
                {
                    normalisedPassportData.Add(lastEntry);
                    lastEntry = string.Empty;
                }

                if (string.IsNullOrWhiteSpace(lastEntry))
                {
                    lastEntry = entry;
                }
                else
                {
                    lastEntry += $" {entry}";
                }
            }

            normalisedPassportData.Add(lastEntry);

            return normalisedPassportData;
        }

        private static List<string> CreateSerialisedPassportData(List<string> passportData)
        {
            var serialisedPassportData = new List<string>();

            foreach (var entry in passportData)
            {
                var entryWithQuotesAroundColonChars = string.Join("\":\"", entry.Split(':'));
                var entryWithQuotesAtBeginningAndEndOfProperties = string.Join("\", \"", entryWithQuotesAroundColonChars.Split(" "));
                serialisedPassportData.Add($"{{ \"{entryWithQuotesAtBeginningAndEndOfProperties}\" }}");
            }

            return serialisedPassportData;
        }
    }
}
