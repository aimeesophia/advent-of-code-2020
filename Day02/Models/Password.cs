using System;
using System.Collections.Generic;
using System.Linq;

namespace Day02.Models
{
    public class Password
    {
        public Password(string passwordString)
        {
            var splitPasswordString = passwordString.Split(" ");
            var splitPasswordPolicy = splitPasswordString[0].Split("-");

            PolicyNumbers = splitPasswordPolicy.Select(int.Parse).ToList();
            Character = char.Parse(splitPasswordString[1].Trim(':'));
            PasswordText = splitPasswordString[2];
        }

        public List<int> PolicyNumbers { get; set; }

        public char Character { get; set; }

        public string PasswordText { get; set; }
    }
}
