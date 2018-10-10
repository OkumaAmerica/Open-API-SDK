using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataApi= Okuma.CLDATAPI.DataAPI;
using DataEnums = Okuma.CLDATAPI.Enumerations;

namespace CS_WPF.OkumaInterface
{
   public class OkumaLathe : IOkuma, IDisposable
    {

        DataApi.CMachine _machine;
        DataApi.CVariables _variables;

        public OkumaLathe()
        {
            _machine = new DataApi.CMachine();
            _machine.Init();
            _variables = new DataApi.CVariables();
        }

        public OperationModeEnum GetOperationMode()
        {
            //Convert the Okuma.CMDATAPI.Enumerations.OperationMode to our local OperationModeEnum Enumeration
            return (OperationModeEnum)_machine.GetOperationMode();
        }

        public void WriteVariable(int variableNumber, double newValue)
        {
            _variables.SetCommonVariableValue(variableNumber, newValue);
        }

        public double ReadVariable(int variableNumber)
        {
            return _variables.GetCommonVariableValue(variableNumber);
        }

        public void Dispose()
        {
            if (_machine != null)
            {
                _machine.Close();
                _variables = null;
            }
        }
    }
}
