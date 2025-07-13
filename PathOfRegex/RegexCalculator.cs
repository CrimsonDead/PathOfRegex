using System.Runtime.InteropServices;

namespace PathOfRegex
{
    public class RegexCalculator
    {
        private readonly List<string> _list;

        public RegexCalculator(List<string> list)
        {
            _list = list;
        }

        public string FewFrom(List<string> subList)
        {
            if (!ValidateSubList(subList))
                throw new ArgumentException("Sub list must be a part of full list");

            List<string> uniqeSubStrings = new List<string>();

            foreach (var item in subList)
            {
                uniqeSubStrings.Add(GetUniqeSubstring(item));
            }

            return CreateNewRegex(uniqeSubStrings);
        }

        private string CreateNewRegex(List<string> uniqeSubStrings)
        {
            string regex = string.Empty;

            foreach (var item in uniqeSubStrings)
            {
                regex += item + "|";
            }
            
            return regex;
        }

        private string GetUniqeSubstring(string item)
        {
            HashSet<string> substrings = GetAllSubStrings(item);
            List<string> otherStrings = _list.Where(s => s != item).ToList();

            foreach (var substring in substrings)
            {
                var q = otherStrings.Where(s => s.Contains(substring)).ToList();
                if (!q.Any()) 
                    return substring;
            }

            return item;
        }

        private HashSet<string> GetAllSubStrings(string item)
        {
            HashSet<string> substrings = new HashSet<string>();

            for (int len = 3; len <= item.Length; len++)
            {
                for (int start = 0; start <= item.Length - len; start++)
                {
                    substrings.Add(item.Substring(start, len));
                }
            }

            return substrings;
        }

        private bool ValidateSubList(List<string> subList)
        {
            return !subList.Except(_list).Any();
        }
    }
}
