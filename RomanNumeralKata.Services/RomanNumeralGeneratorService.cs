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
            if(string.IsNullOrEmpty(currentSymbol))
            {
                return _symbols.OrderBy(x => x.Key)
                               .Skip(1)
                               .Select(x => x.Key)
                               .FirstOrDefault();
            }

            return _symbols.OrderBy(x => x.Key)
                    .SkipWhile(x => x.Key != currentSymbol)
                    .Skip(1)
                    .Select(x => x.Key)
                    .FirstOrDefault();
        }

        private string FormatNumerals(string numeral)
        {
            var repeatedKey = numeral.ToCharArray()
                                      .GroupBy(x => x)
                                      .Where(y => y.Count() > 3)
                                      .Select(z => new string(z.Key, 4))
                                      .ToList();

            var result = string.Empty;
            var currentSymbol = numeral[0].ToString() != "I" ? numeral[0].ToString() : string.Empty;
            var nextSymbol = GetNextKey(currentSymbol);

            foreach (var key in repeatedKey)
            {
                numeral = numeral.Replace(string.Format("{0}{1}", currentSymbol , key), string.Format("I{0}", nextSymbol));
            }

            return numeral;
        }
    }
}
