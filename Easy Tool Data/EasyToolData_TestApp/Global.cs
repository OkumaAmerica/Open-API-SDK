using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyToolData_TestApp
{
    public static class Global
    {
        public static string MainGuiThreadName = "TestAppMainThread";


        public static string NumberFormat
        {
            get
            {
                // This is to avoid displaying Scientific Notation when converting small metric values to inches
                if (Okuma.EasyToolData.Global.UnitsInInch) { return "0.0#######"; }
                else
                {
                    if (PointOneMicron()) { return "0.0000"; }
                    else { return "0.000"; }
                }
            }
        }

        private static bool CheckedPointOneMicron = false;
        private static bool PointOneMicronValue;
        private static bool PointOneMicron()
        {
            if (!CheckedPointOneMicron)
            {
                Okuma.EasyToolData.THINC.Spec s = new Okuma.EasyToolData.THINC.Spec();

                if (Okuma.EasyToolData.Global.MachineType == Okuma.EasyToolData.Enums.BasicMachineType.L)
                {
                    if (s.Get(s.L.PointOneMicronControl) == Okuma.EasyToolData.Enums.ValidatedResponse.TRUE) { PointOneMicronValue = true; }
                }
                else if (Okuma.EasyToolData.Global.MachineType == Okuma.EasyToolData.Enums.BasicMachineType.M)
                {
                    if (s.Get(s.M.PointOneMicronControl) == Okuma.EasyToolData.Enums.ValidatedResponse.TRUE) { PointOneMicronValue = true; }
                }
                CheckedPointOneMicron = true;
            }
            return PointOneMicronValue;

        }
    }
}
