
//  Copyright (c) Okuma America Corporation.  All Rights Reserved.

using System;
using System.Configuration;
using System.ServiceModel;
using System.Reflection;


namespace Okuma.THINC_WCF_ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace= "http://Okuma.THINC_WCF_ServiceModel.Samples")]
    public interface ICommonVariables
    {
        [OperationContract]
        bool AddCommonVariable(int Index, double Value);
        [OperationContract]
        int GetCommonVariableCount();
        [OperationContract]
        double GetCommonVariable(int Index);
        [OperationContract]
        double[] GetCommonVariables(int FromIndex, int ToIndex);
        [OperationContract]
        bool SetCommonVariable(int Index, double Value);
    }


    // Service class which implements the service contract.
    public class CommonVariablesService : ICommonVariables
    {
        // THINC-API For Lathes
        private Lathe _latheObject;
        public Lathe LatheObject
        {
            get
            {
                if (_latheObject == null) { _latheObject = new Lathe(); }
                return _latheObject;
            }
        }

        // THINC-API For Mills
        private Mill _millObject;
        public Mill MillObject
        {
            get
            {
                if (_millObject == null) { _millObject = new Mill(); }
                return _millObject;
            }
        }


        public bool AddCommonVariable(int Index, double Value)
        {
            if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.L)
            {
                return LatheObject.AddCommonVariable(Index, Value);
            }
            else if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.M)
            {
                return MillObject.AddCommonVariable(Index, Value);
            }
            return false; 
        }

        public int GetCommonVariableCount()
        {
            if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.L)
            {
                return LatheObject.GetCommonVariableCount();
            }
            else if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.M)
            {
                return MillObject.GetCommonVariableCount();
            }
            return -1;
        }

        public double GetCommonVariable(int Index)
        {
            if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.L)
            {
                return LatheObject.GetCommonVariable(Index);
            }
            else if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.M)
            {
                return MillObject.GetCommonVariable(Index);
            }
            return -99999999.999;
        }

        public double[] GetCommonVariables(int FromIndex, int ToIndex)
        {
            if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.L)
            {
                return LatheObject.GetCommonVariables(FromIndex, ToIndex);
            }
            else if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.M)
            {
                return MillObject.GetCommonVariables(FromIndex, ToIndex);
            }
            double[] fail = { -99999999.999 };
            return fail;
        }

        public bool SetCommonVariable(int Index, double Value)
        {
            if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.L)
            {
                return LatheObject.SetCommonVariable(Index, Value);
            }
            else if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.M)
            {
                return MillObject.SetCommonVariable(Index, Value);
            }
            return false;
        }



        // Host the service within this EXE console application.
        public static void Main()
        {
            bool CanRunService = false;

            // Initialize THINC API
            // ** MUST ** Initialize on Main Thread / (Main GUI Thread for WinForms or WPF application)
            if (Okuma.Scout.ThincApi.Installed &&
               (Okuma.Scout.ThincApi.ApiAvailable == Okuma.Scout.Enums.ApiStatus.Ready ||
                Okuma.Scout.ThincApi.ApiAvailable == Okuma.Scout.Enums.ApiStatus.Initialized))
            {
                if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.L)
                {
                    try
                    {
                        Okuma.CLDATAPI.DataAPI.CMachine cMachine = new CLDATAPI.DataAPI.CMachine();
                        cMachine.Init();
                        System.Threading.Thread.Sleep(200);
                        Console.WriteLine("Lathe THINC API Init() Success.");
                        CanRunService = true;
                    }
                    catch (Exception ex)
                    {
                        HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    }
                }
                else if (Okuma.Scout.Platform.BaseMachineType == Scout.Enums.MachineType.M)
                {
                    try
                    {
                        Okuma.CMDATAPI.DataAPI.CMachine cMachine = new CMDATAPI.DataAPI.CMachine();
                        cMachine.Init();
                        System.Threading.Thread.Sleep(200);
                        Console.WriteLine("Mill THINC API Init() Success.");
                        CanRunService = true;
                    }
                    catch (Exception ex)
                    {
                        HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    }
                }
            }
            else
            {
                string NotReadyExplination =
                    "Not Ready for API Init()" + Environment.NewLine +
                    "          TAPI Installed: " + Okuma.Scout.ThincApi.Installed + Environment.NewLine +
                    "              TAPI Ready: " + Okuma.Scout.ThincApi.ApiAvailable.ToString();

                // The service can not be accessed.
                Console.WriteLine(NotReadyExplination);
                Console.WriteLine();
                Console.WriteLine("Okuma THINC API WCF service Not Started.");
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate application.");
                Console.WriteLine();
                Console.ReadLine();
            }

            if (CanRunService)
            {
                // Create a ServiceHost for the CommonVariableService type.
                using (ServiceHost serviceHost = new ServiceHost(typeof(CommonVariablesService)))
                {
                    // Open the ServiceHost to create listeners and start listening for messages.
                    serviceHost.Open();

                    // The service can now be accessed.
                    Console.WriteLine("Okuma THINC API WCF service is running.");
                    Console.WriteLine("Press <ENTER> to terminate service.");
                    Console.WriteLine();
                    Console.ReadLine();
                }
            }
        }
        

        // Nested Class - Lathe API

        public class Lathe
        {
            readonly Okuma.CLDATAPI.DataAPI.CVariables THINC_VariablesLathe;

            public Lathe()
            {
                THINC_VariablesLathe = new CLDATAPI.DataAPI.CVariables();
            }

            public bool AddCommonVariable(int Index, double Value)
            {
                try
                {
                    Console.WriteLine("Received AddCommonVariable(Index:{0}, Value:{1})", Index, Value);
                    THINC_VariablesLathe.AddCommonVariableValue(Index, Value); 
                    return true;
                }
                catch (Exception ex)
                {
                    HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    return false;
                }
            }

            public int GetCommonVariableCount()
            {
                try
                {
                    Console.WriteLine("Received GetCommonVariableCount()");
                    return THINC_VariablesLathe.GetCommonVariableCount();
                }
                catch (Exception ex)
                {
                    HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    return -1;
                }
            }

            public double GetCommonVariable(int Index)
            {
                try
                {
                    Console.WriteLine("Received GetCommonVariable(Index:{0})", Index);
                    return THINC_VariablesLathe.GetCommonVariableValue(Index);
                }
                catch (Exception ex)
                {
                    HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    return -99999999.999;
                }
            }

            public double[] GetCommonVariables(int FromIndex, int ToIndex)
            {
                try
                {
                    Console.WriteLine("Received GetCommonVariables(FromIndex:{0}, ToIndex:{1})", FromIndex, ToIndex);
                    return THINC_VariablesLathe.GetCommonVariableValues(FromIndex, ToIndex);
                }
                catch (Exception ex)
                {
                    HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    double[] fail = { -99999999.999 };
                    return fail;
                }
            }

            public bool SetCommonVariable(int Index, double Value)
            {
                try
                {
                    Console.WriteLine("Received SetCommonVariable(Index:{0}, Value:{1})", Index, Value);
                    THINC_VariablesLathe.SetCommonVariableValue(Index, Value);
                    return true;
                }
                catch (Exception ex)
                {
                    HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    return false;
                }
            }

        }


        // Nested Class - Mill API

        public class Mill
        {
            readonly Okuma.CMDATAPI.DataAPI.CVariables THINC_VariablesMill;

            public Mill()
            {
                THINC_VariablesMill = new CMDATAPI.DataAPI.CVariables();
            }

            public bool AddCommonVariable(int Index, double Value)
            {
                try
                {
                    Console.WriteLine("Received AddCommonVariable(Index:{0}, Value:{1})", Index, Value);
                    THINC_VariablesMill.AddCommonVariableValue(Index, Value);
                    return true;
                }
                catch (Exception ex)
                {
                    HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    return false;
                }
            }

            public int GetCommonVariableCount()
            {
                try
                {
                    Console.WriteLine("Received GetCommonVariableCount()");
                    return THINC_VariablesMill.GetCommonVariableCount();
                }
                catch (Exception ex)
                {
                    HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    return -1;
                }
            }

            public double GetCommonVariable(int Index)
            {
                try
                {
                    Console.WriteLine("Received GetCommonVariable(Index:{0})", Index);
                    return THINC_VariablesMill.GetCommonVariableValue(Index);
                }
                catch (Exception ex)
                {
                    HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    return -99999999.999;
                }
            }

            public double[] GetCommonVariables(int FromIndex, int ToIndex)
            {
                try
                {
                    Console.WriteLine("Received GetCommonVariables(FromIndex:{0}, ToIndex:{1})", FromIndex, ToIndex);
                    return THINC_VariablesMill.GetCommonVariableValues(FromIndex, ToIndex);
                }
                catch (Exception ex)
                {
                    HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    double[] fail = { -99999999.999 };
                    return fail;
                }
            }

            public bool SetCommonVariable(int Index, double Value)
            {
                try
                {
                    Console.WriteLine("Received SetCommonVariable(Index:{0}, Value:{1})", Index, Value);
                    THINC_VariablesMill.SetCommonVariableValue(Index, Value);
                    return true;
                }
                catch (Exception ex)
                {
                    HandleEx(MethodBase.GetCurrentMethod().Name, ex);
                    return false;
                }
            }

        }


        /// <summary> Exception Handler </summary>
        public static void HandleEx(string method, Exception ex)
        {
            string ExceptionDetail = "";
            if (ex.Message != string.Empty) { ExceptionDetail += ex.Message + Environment.NewLine; }
            if (ex.InnerException != null) { ExceptionDetail += ex.InnerException + Environment.NewLine; }
            if (ex.StackTrace != null) { ExceptionDetail += ex.StackTrace; }
            Console.WriteLine("Method: {0}, Exception: {1}, Detail: {2}", method, ex, ExceptionDetail);
        }

    }

}