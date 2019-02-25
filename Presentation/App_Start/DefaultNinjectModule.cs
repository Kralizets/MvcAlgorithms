using Ninject.Web.Common;
using Ninject.Modules;
using AlgorithmsProvider.Provider.Implementation;
using AlgorithmsProvider.Provider.Interface;

namespace Presentation
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHorspoolProvider>().To<HorspoolProvider>().InRequestScope();
        }
    }
}
