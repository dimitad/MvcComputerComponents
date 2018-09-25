using SimpleInjector.Advanced;
using System;
using System.Linq;
using System.Reflection;

namespace ComputerComponentsWeb.DI
{
    public class GreediestConstructorBehavior : IConstructorResolutionBehavior
    {
        public ConstructorInfo GetConstructor(Type implementationType)
        {
            ConstructorInfo[] ConstructorInfos = implementationType.GetConstructors();

            if (ConstructorInfos == null || ConstructorInfos.Length == 0)
            {
                throw new Exception(string.Format("Implementation of {0} does not have constructor or not register with DI.", implementationType.Name));
            }
            //Select the constructor with the most parameters
            return (
                    from ctor in ConstructorInfos
                    orderby ctor.GetParameters().Length descending
                    select ctor).First();
        }
    }
}