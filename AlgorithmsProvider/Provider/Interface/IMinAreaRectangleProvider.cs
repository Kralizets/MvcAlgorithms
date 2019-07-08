using AlgorithmsProvider.Models;

namespace AlgorithmsProvider.Provider.Interface
{
    public interface IMinAreaRectangleProvider
    {
        MinAreaRectangleModel GetMinAreaRectangle(Point[] points);
    }
}