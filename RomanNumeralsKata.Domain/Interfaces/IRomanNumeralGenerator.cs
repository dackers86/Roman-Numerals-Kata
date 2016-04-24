﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsKata.Domain.Interfaces
{
    public interface IRomanNumeralGenerator
    {
        string Generate(int number);
    }
}
