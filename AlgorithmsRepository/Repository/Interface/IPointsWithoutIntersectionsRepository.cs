using AlgorithmsRepository.Models;
using System.Collections.Generic;

namespace AlgorithmsRepository.Repository.Interface
{
    public interface IPointsWithoutIntersectionsRepository
    {
        List<PointDb> GetPointsInFiles(string path);
    }
}