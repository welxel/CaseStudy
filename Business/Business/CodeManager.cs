using System;
using Business.Interfaces;

namespace Business.Business
{
    public class CodeManager : ICodeManager
    {
        private const string characters="ACDEFGHKLMNPRTXYZ234579";

        public string CodeGenerater()
        {
            int charSum = 0;
            int count = 11;
            Random rnd = new Random();
            string code = new string(Enumerable.Repeat(characters, 7)
                   .Select(s => s[rnd.Next(s.Length)]).ToArray());

            var characterArray = code.ToList();
            int intCharSum = characterArray.Where(c => Char.IsDigit(c))
               .Sum(c => Int32.Parse(c.ToString()));

            Dictionary<char, int> words= new Dictionary<char, int>();
            foreach (char c in characters)
            {
                if (!Char.IsDigit(c))
                {
                    words.Add(c, count);
                    count++;
                }
            }

            foreach (char c in characterArray)
            {
                {
                    int value;
                    if (words.TryGetValue(c, out value))
                    {
                        charSum = charSum + value;
                    }
                }
            }

            if ((charSum - intCharSum) % 7 == 1 || (charSum - intCharSum) % 7 == 6 || (charSum - intCharSum) % 7 == 0)
            {
                characterArray.Add('2');
            }
            else
            {
                string remainOfMode = Convert.ToString((charSum - intCharSum) % 7);
                characterArray.Add(Convert.ToChar(remainOfMode));
            }

            string text = "";
            foreach (var item in characterArray)
            {
                text = text + item;
            }
            return text;
        }

        public bool InValidCode(string code)
        {
            int charSum = 0;
            int count = 11;
            if (code.Length != 8)
            {
                return false;
            }

            foreach (char c in code)
            {
                if (characters.IndexOf(c) == -1)
                {
                    return false;
                }
            }
            var characterArray = code.ToList();
            var lastChar = characterArray.Last();
            characterArray.Remove(characterArray.Last());
            int intCharSum = characterArray.Where(c => Char.IsDigit(c))
              .Sum(c => Int32.Parse(c.ToString()));
            Dictionary<char, int> words = new Dictionary<char, int>();
            foreach (char c in characters)
            {
                if (!Char.IsDigit(c))
                {
                    words.Add(c, count);
                    count++;
                }
            }

            foreach (char c in characterArray)
            {
                {
                    int value;
                    if (words.TryGetValue(c, out value))
                    {
                        charSum = charSum + value;
                    }
                }
            }
            if ((charSum - intCharSum) % 7 == 1 || (charSum - intCharSum) % 7 == 6 || (charSum - intCharSum) % 7 == 0)
            {
                return lastChar == '2' ? true : false;
            }
            else
            {
                string remainOfMode = Convert.ToString((charSum - intCharSum) % 7);
                return lastChar == Convert.ToChar(remainOfMode) ? true : false;
            }
        }
    }
}

