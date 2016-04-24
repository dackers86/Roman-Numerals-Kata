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
        public string Generate(int number)
        {
            var result = string.Empty;

            for (var x = 0; x<number; x++)
            {
                if (number == 5)
                {
                    return "V";
                }


                if (number == 10)
                {
                    return "X";
                }

                result += "I";
            }

            return result;
        }
    }
}
