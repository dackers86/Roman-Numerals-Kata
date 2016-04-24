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
            { "X", 10 }, { "V", 5 }, { "I", 1 }
        };


        public string Generate(int number)
        {
            var numeral =  GetSymbol(number);

            return FormatNumerals(numeral);
        }

        private string GetSymbol(int number)
        {
            var _runningTotal = number;
            var _result = string.Empty;

            do
            {
                var entry = GetNextSymbol(_runningTotal);
                _runningTotal -= entry.Value;
                _result += entry.Key;
            }
            while (_runningTotal > 0);

            return _result;
        }

        private KeyValuePair<string, int> GetNextSymbol(int runningTotal)
        {
            return _symbols.OrderByDescending(x => x.Key)
                           .Where(x => x.Value <= runningTotal)
                           .FirstOrDefault();
        }

        private string GetNextKey(string currentSymbol)
        {
            return _symbols.OrderBy(x => x.Key)
                    .SkipWhile(x => x.Key != currentSymbol)
                    .Skip(1)
                    .Select(x => x.Key)
                    .FirstOrDefault();
        }

        private string FormatNumerals(string numeral)
        {
            //var result = string.Empty;

            //if (numeral == "IIII")
            //{
            //    result = numeral.Replace("IIII", "IV");
            //}
            //else if(numeral == "VIIII")
            //{
            //    result = numeral.Replace("VIIII", "IX");
            //}
            //else
            //{
            //    result = numeral;
            //}

            //return result;

            var result = string.Empty;
            var currentSymbol = numeral[0].ToString();
            var nextSymbol = GetNextKey(currentSymbol);

            if (numeral.Contains("IIII"))
            {
                result = numeral.Replace(string.Format("{0}IIII", currentSymbol != "I" ? numeral[0].ToString() : string.Empty), string.Format("I{0}", nextSymbol));
            }
            else
            {
                return numeral;
            }
            return result;
        }
    }
}
