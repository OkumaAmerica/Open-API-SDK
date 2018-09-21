/*
!!! WARNING !!!
YOU SHOULD NEVER USE THIS EXAMPLE CODE IN A PRODUCTION ENVIRONMENT!

Modifying variables on a machine which is in production HAS RESULTED IN MACHINE
CRASHES AND PROPERTY DAMAGE, AND COULD RESULT IN PERSONAL INJURY OR EVEN DEATH!

This example does not include any transport security, message security, authentication, 
or authorization of clients.It is configured to operate only on the local machine. 

IF you decide to MODIFY this example to operate over a network connection, compile and
deploy any part of this code in a production environment, YOU ACCEPT ALL RESPONSIBILTY 
for the outcome, however detrimental, and AGREE that OKUMA CANNOT BE HELD LIABLE 
for your poor judgment and failure to heed this warning.
*/

namespace WpfClient
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(
        Namespace="http://Okuma.THINC_WCF_ServiceModel.Samples",
        ConfigurationName= "Okuma.THINC_WCF_ServiceModel.Samples.ICommonVariables")]
    public interface ICommonVariables
    {
        [System.ServiceModel.OperationContractAttribute(
            Action = "http://Okuma.THINC_WCF_ServiceModel.Samples/ICommonVariables/AddCommonVariable", 
            ReplyAction = "http://Okuma.THINC_WCF_ServiceModel.Samples/ICommonVariables/AddCommonVariableResponse")]
        bool AddCommonVariable(int Index, double Value);
        
        [System.ServiceModel.OperationContractAttribute(
            Action = "http://Okuma.THINC_WCF_ServiceModel.Samples/ICommonVariables/GetCommonVariableCount", 
            ReplyAction = "http://Okuma.THINC_WCF_ServiceModel.Samples/ICommonVariables/GetCommonVariableCountResponse")]
        int GetCommonVariableCount();

        [System.ServiceModel.OperationContractAttribute(
            Action = "http://Okuma.THINC_WCF_ServiceModel.Samples/ICommonVariables/GetCommonVariable", 
            ReplyAction = "http://Okuma.THINC_WCF_ServiceModel.Samples/ICommonVariables/GetCommonVariableResponse")]
        double GetCommonVariable(int Index);

        [System.ServiceModel.OperationContractAttribute(
            Action = "http://Okuma.THINC_WCF_ServiceModel.Samples/ICommonVariables/GetCommonVariables", 
            ReplyAction = "http://Okuma.THINC_WCF_ServiceModel.Samples/ICommonVariables/GetCommonVariablesResponse")]
        double[] GetCommonVariables(int FromIndex, int ToIndex);

        [System.ServiceModel.OperationContractAttribute(
            Action = "http://Okuma.THINC_WCF_ServiceModel.Samples/ICommonVariables/SetCommonVariable", 
            ReplyAction = "http://Okuma.THINC_WCF_ServiceModel.Samples/ICommonVariables/SetCommonVariableResponse")]
        bool SetCommonVariable(int Index, double Value);
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICommonVariablesChannel : ICommonVariables, System.ServiceModel.IClientChannel
    {
    }


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommonVariablesClient : System.ServiceModel.ClientBase<ICommonVariables>, ICommonVariables
    {

        public CommonVariablesClient()
        {
        }

        public CommonVariablesClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public CommonVariablesClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CommonVariablesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CommonVariablesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public bool AddCommonVariable(int Index, double Value)
        {
            return base.Channel.AddCommonVariable(Index, Value);
        }

        public int GetCommonVariableCount()
        {
            return base.Channel.GetCommonVariableCount();
        }

        public double GetCommonVariable(int Index)
        {
            return base.Channel.GetCommonVariable(Index);
        }

        public double[] GetCommonVariables(int FromIndex, int ToIndex)
        {
            return base.Channel.GetCommonVariables(FromIndex, ToIndex);
        }

        public bool SetCommonVariable(int Index, double Value)
        {
            return base.Channel.SetCommonVariable(Index, Value);
        }

    }

}