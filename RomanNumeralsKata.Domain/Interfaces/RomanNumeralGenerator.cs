using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsKata.Domain.Interfaces
{
    public interface RomanNumeralGenerator
    {
        string Generate(int number);
    }
}
