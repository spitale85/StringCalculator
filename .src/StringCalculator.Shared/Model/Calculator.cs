using System.Globalization;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringCalculator.Shared.Model
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var delimiters = new List<string>();
            // Adding default delimiters
            delimiters.AddRange(new string[] { ",", "\n" });
            
            var negativeNumbers = new List<string>();

            var hasCustomDelimiters = numbers.StartsWith("//");
            if (hasCustomDelimiters)
            {
                var delimiterStartIndex = numbers.IndexOf("//") + 1;
                var delimiterEndIndex = numbers.IndexOfAny(new char[] {',','\n'}) ;
              
                var customDelimiters = numbers.Substring(delimiterStartIndex + 1 , delimiterEndIndex - delimiterStartIndex - 1);
                customDelimiters = customDelimiters.Replace("[", "");

                //var customDelimeters = customDelimiter.Split(']', StringSplitOptions.RemoveEmptyEntries);
                delimiters.AddRange(customDelimiters.Split(']', StringSplitOptions.RemoveEmptyEntries));
                numbers = numbers.Substring(delimiterEndIndex+1);
            }
            
            //var numbersArray = numbers.Split( ',', '\n', customDelimiter);
            var numbersArray = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
            int result = 0;

            foreach (var number in numbersArray)
            {
                if (string.IsNullOrEmpty(number)) result += 0;
                else switch (int.Parse(number))
                {
                    case > 1000:
                        result += 0;
                        break;
                    case < 0:
                        negativeNumbers.Add((number));
                        break;
                    default:
                        result += int.Parse(number);
                        break;
                }
            }

            if (negativeNumbers.Count > 0)
            {
                throw new Exception($"Negatives not allowed: {string.Join(",",negativeNumbers)}");
            }

            return result;

            //if (string.IsNullOrEmpty(numbers)) return 0;
            //return int.Parse(numbers);
        }
    }
}
