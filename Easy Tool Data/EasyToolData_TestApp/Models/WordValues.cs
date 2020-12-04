using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyToolData_TestApp.Models
{
    public class WordValues
    {
        public int Number { get; set; }
        public int Value { get; set; }

        public WordValues(int number, int value)
        {
            Number = number;
            Value = value;
        }
    }
}
