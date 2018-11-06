using System;

namespace CS_WPF.OkumaInterface
{
    public interface IOkuma:IDisposable
    {
        OperationModeEnum GetOperationMode();
        double ReadVariable(int variableNumber);
        void WriteVariable(int variableNumber, double newValue);
    }
}
