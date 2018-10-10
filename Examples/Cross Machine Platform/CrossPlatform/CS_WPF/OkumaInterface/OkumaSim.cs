using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_WPF.OkumaInterface
{
    public class OkumaSim : IOkuma
    {
        Dictionary<int, double> _variables;

        public OkumaSim()
        {
            _variables = new Dictionary<int, double>();

            for (int i = 1; i < 199; i++)
            {
                _variables.Add(i, 0D);
            }
        }

        public OperationModeEnum GetOperationMode()
        {
            return OperationModeEnum.Auto;
        }

        public double ReadVariable(int variableNumber)
        {
            return _variables[variableNumber];
        }

        public void WriteVariable(int variableNumber, double newValue)
        {
            _variables[variableNumber] = newValue;
        }
    }
}
