using EF.ComponentData.Services;
using SimpleInjector;

namespace ComputerComponentsWeb.DI
{
    public static class CompDIRegistration
    {
        public static void Register(Container container)
        {                     
            container.Register<IComponentCategoryService, ComponentCategoryService>();
            container.Register<IComponentItemService, ComponentItemService>();
        }
    }
}