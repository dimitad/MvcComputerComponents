
namespace ComputerComponentsWeb.DI
{
    public static class IocConfig
    {
        public static void RegisterDI(CompDIContainer container)
        {
            container.BootstrapDI();             
        }
    }
}