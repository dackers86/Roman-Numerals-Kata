using RomanNumeralsKata.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralKata.Services
{
    public class RomanNumeralGeneratorService : IRomanNumeralGenerator
    {
        private Dictionary<string, int> _symbols = new Dictionary<string, int>()
        {
             { "I", 1 }, { "II", 2 }, { "III", 3 }, { "IV", 4 }, { "V", 5 }, { "VI", 6 }, { "VII", 7 } , { "VIII", 8 }, { "IX", 9 },
             { "X", 10 }, { "XX", 20 }, { "XXX", 30 }, { "XL", 40 }, { "L", 50 }, { "LX", 60 }, { "LXX", 70 } , { "LXXX", 80 }, { "XC", 90 },
             { "C", 100 }, { "CC", 200 }, { "CCC", 300 }, { "CD", 400 }, { "D", 500 }, { "DC", 600 }, { "DCC", 700 } , { "DCCC", 800 }, { "CM", 900 },
             { "M", 1000 }
        };


        public string Generate(int number)
        {
            if(number > 3999)
            {
                return "Please enter a number less than 3999";
            }

            return CalculateNumerals(number);
        }

        private string CalculateNumerals(int number)
        {
            var result = string.Empty;

            var numberArray = ExtractIntoTenThousends(number);

            foreach (var num in numberArray)
            {
                var current_value = int.Parse(num);

                if (current_value >= 1000)
                {
                    CalculateThousends(current_value, result);
                }
                else
                {
                    CalulateNumeral(current_value, result);
                }
            }

            return result;
        }

        private List<string> ExtractIntoTenThousends(int number)
        {
            return number.ToString()
                        .Select((item, index) => item.ToString()
                        .PadRight(number.ToString().Length - index, '0'))
                        .ToList();
        }

        private void CalculateThousends(int number, string result)
        {
            for (var i = 1; i <= number / 1000; i++)
            {
                result += _symbols.Where(x => x.Value == 1000)
                                    .Select(x => x.Key)
                                    .FirstOrDefault();
            }
        }

        private void CalulateNumeral(int number, string result)
        {
            for (var i = 1; i <= number / 1000; i++)
            {
                result += _symbols.Where(x => x.Value == 1000)
                                    .Select(x => x.Key)
                                    .FirstOrDefault();
            }
        }

    }
}
