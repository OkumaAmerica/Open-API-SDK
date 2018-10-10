using System;
using System.Linq;

namespace CS_WPF.OkumaInterface
{
    public interface IOkuma
    {
        OperationModeEnum GetOperationMode();
        double ReadVariable(int variableNumber);
        void WriteVariable(int variableNumber, double newValue);
    }
}
