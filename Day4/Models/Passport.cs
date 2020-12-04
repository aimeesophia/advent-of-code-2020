using System.ComponentModel.DataAnnotations;

namespace Day4.Models
{
    public class Passport
    {
        [Required]
        [RegularExpression(@"(19[2-9]\d|200[0-2])")]
        public string byr { get; set; }

        [Required]
        [RegularExpression(@"(201\d|2020)")]
        public string iyr { get; set; }

        [Required]
        [RegularExpression(@"(202\d|2030)")]
        public string eyr { get; set; }

        [Required]
        [RegularExpression(@"((19[0-3]|1([5-8][0-9]))cm)|((59|6\d|7[0-6])in)")]
        public string hgt { get; set; }

        [Required]
        [RegularExpression(@"#([a-z0-9]{6})")]
        public string hcl { get; set; }

        [Required]
        [RegularExpression(@"((amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth)){1}")]
        public string ecl { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{9}")]
        public string pid { get; set; }

        public string cid { get; set; }
    }
}
