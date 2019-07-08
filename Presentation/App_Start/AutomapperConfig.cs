using AlgorithmsProvider.Models;
using AlgorithmsRepository.Models;
using AutoMapper;

namespace Presentation.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PointDb, Point>());
        }
    }
}