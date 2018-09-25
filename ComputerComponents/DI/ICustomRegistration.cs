using SimpleInjector;

namespace ComputerComponentsWeb.DI
{
    public interface ICustomRegistration
    {
        /// <summary>
        ///  Custom registrations
        /// </summary>
        /// <param name="container">Container</param>
        void CustomDIRegistration(Container container);

        /// <summary>
        ///  Custom verification step
        /// </summary>
        /// <param name="container"></param>
        void CustomVerification(Container container);
    }
}
