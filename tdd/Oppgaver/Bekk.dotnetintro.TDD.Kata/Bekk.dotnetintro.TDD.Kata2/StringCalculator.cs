using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Bekk.dotnetintro.TDD.Kata2.View;

namespace Bekk.dotnetintro.TDD.Kata2
{
    public class StringCalculator
    {
        public ICalculatorView View { get; private set; }

        public StringCalculator(ICalculatorView view)
        {
            View = view;
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            
            var allNumbers = new Parser().Parse(numbers);

            var numberValidator = new NumberValidator();
            
            numberValidator.HasNoNegativeNumbers(allNumbers);
            numberValidator.RemoveNumbersOver1000(allNumbers);

            var sum = allNumbers.Sum();
            View.Display(sum);
            
            return sum;
        }
    }

    public class Parser
    {
        public List<int> Parse(string numbers)
        {
            var delimiter = ",";
            var matches = Regex.Match(numbers, @"^\/\/(.+)");

            if (matches.Groups.Count > 1)
            {
                delimiter = matches.Groups[1].Value;
                delimiter = delimiter.Replace("*", @"\*");
                delimiter = delimiter.Replace("+", @"\+");
                numbers = numbers.Substring(matches.Length + 1);
            }
            
            var pattern = new StringBuilder();

            pattern.Append(delimiter);
            pattern.Append("|");
            pattern.Append("\n");

            var splittedNumbers = Regex.Split(numbers, pattern.ToString());

            var allNumbers = splittedNumbers.Select(int.Parse).ToList();
            return allNumbers;
        }
    }

    public class NumberValidator
    {
        public void HasNoNegativeNumbers(List<int> numbers)
        {
            var negativeNumbers = (from number in numbers where number < 0 select number).ToList();

            if (negativeNumbers.Count > 0)
            {
                var notValidNumbers = negativeNumbers.Aggregate(string.Empty, (current, number) => current + " " + number);
                throw new ArgumentException(string.Format("Negative numbers are not allowed. The following where found in the argument: {0}", notValidNumbers));
            }
        }

        public void RemoveNumbersOver1000(List<int> allNumbers)
        {
            allNumbers.RemoveAll(number => number > 1000);
        }
    }
}
