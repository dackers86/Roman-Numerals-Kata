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
            var result =  GetSymbol(number);

            var substiuted = result.Replace("IIII", "IV");

            return substiuted;

        }

        private string GetSymbol(int number)
        {
            var _runningTotal = number;
            var _result = string.Empty;

            do
            {
                var entry = _symbols.Where(x => x.Value <= number).FirstOrDefault();
                _runningTotal -= entry.Value;
                _result += entry.Key;
            }
            while (_runningTotal > 0);

            return _result;

        }
    }
}
