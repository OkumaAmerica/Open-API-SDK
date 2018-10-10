namespace CS_WPF.OkumaInterface
{
    public static class API_Factory
    {
        public static IOkuma GetOkumaAPI()
        {
            if(Okuma.Scout.Platform.BaseMachineType == Okuma.Scout.Enums.MachineType.L)
            {
                //If Lathe return new lathe wrapper
                return new OkumaLathe();
            }
            else if(Okuma.Scout.Platform.BaseMachineType == Okuma.Scout.Enums.MachineType.M)
            {
                //If machine is a mill return mill wrapper
                return new OkumaMill();
            }
            else
            {
                //If it is anything else return the simulator wrapper
                return new OkumaSim();
            }
        }
    }
}
