using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyToolData_TestApp.Models
{
    public class BitValues
    {
        public int Number { get; set; }

        public bool? Bit0 { get; set; }
        public bool? Bit1 { get; set; }
        public bool? Bit2 { get; set; }
        public bool? Bit3 { get; set; }
        public bool? Bit4 { get; set; }
        public bool? Bit5 { get; set; }
        public bool? Bit6 { get; set; }
        public bool? Bit7 { get; set; }

        public BitValues(
            int number,
            bool? b0, bool? b1, bool? b2, bool? b3,
            bool? b4, bool? b5, bool? b6, bool? b7)
        {
            Number = number;
            Bit0 = b0;
            Bit1 = b1;
            Bit2 = b2;
            Bit3 = b3;
            Bit4 = b4;
            Bit5 = b5;
            Bit6 = b6;
            Bit7 = b7;
        }
    }
}
