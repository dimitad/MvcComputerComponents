using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ComputerComponentsWeb.DI
{
    public class CompDIContainer : BaseDIContainer
    {   
        protected override void CustomDIRegistration(Container container)
        {
            try
            {               
                CompDIRegistration.Register(container);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void CustomVerification()
        {
            var assemblies = System.Web.Compilation.BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            IEnumerable<Type> controllers =
                from assembly in assemblies
                from type in assembly.GetExportedTypes()
                where typeof(Controller).IsAssignableFrom(type)
                where !type.IsAbstract
                select type;

            foreach (Type controller in controllers)
            {
                GetInstance(controller);
            }
        }
    }
}