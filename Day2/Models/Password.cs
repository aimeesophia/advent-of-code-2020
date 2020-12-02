namespace Day2.Models
{
    public class Password
    {
        public Password(string passwordString)
        {
            var splitPasswordString = passwordString.Split(" ");
            var splitPasswordPolicy = splitPasswordString[0].Split("-");

            PasswordPolicy = new PasswordPolicy
            {
                MinAmount = int.Parse(splitPasswordPolicy[0]),
                MaxAmount = int.Parse(splitPasswordPolicy[1])
            };
            Character = char.Parse(splitPasswordString[1].Trim(':'));
            PasswordText = splitPasswordString[2];
        }

        public PasswordPolicy PasswordPolicy { get; set; }

        public char Character { get; set; }

        public string PasswordText { get; set; }
    }
}
