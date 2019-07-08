using Ninject.Web.Common;
using Ninject.Modules;
using AlgorithmsProvider.Provider.Implementation;
using AlgorithmsProvider.Provider.Interface;
using AlgorithmsRepository.Repository.Interface;
using AlgorithmsRepository.Repository.Implementation;

namespace Presentation
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHorspoolProvider>().To<HorspoolProvider>().InRequestScope();
            Bind<IMinAreaRectangleProvider>().To<MinAreaRectangleProvider>().InRequestScope();
            Bind<IPointsWithoutIntersectionsRepository>().To<PointsWithoutIntersectionsRepository>().InRequestScope();
            Bind<IPointsWithoutIntersectionsProvider>().To<PointsWithoutIntersectionsProvider>().InRequestScope();
        }
    }
}