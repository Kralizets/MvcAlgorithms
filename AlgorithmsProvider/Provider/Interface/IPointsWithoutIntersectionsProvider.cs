using AlgorithmsProvider.Models;

namespace AlgorithmsProvider.Provider.Interface
{
    public interface IPointsWithoutIntersectionsProvider
    {
        Point[] GetPointsInFile(string path);
        Point[] GetOrderPointsWithoutIntersections(Point[] points);
    }
}