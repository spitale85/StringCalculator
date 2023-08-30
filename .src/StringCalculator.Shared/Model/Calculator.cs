using System.Globalization;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringCalculator.Shared.Model
{
    public class Calculator
    {
        public int Add(string[] numbers)
        {
            int result = 0;
            
            foreach (var number in numbers)
            {
                if (string.IsNullOrEmpty(number)) return 0;
                result += int.Parse(number);
            }

            return result;
        }
    }
}
