using AlgorithmsProvider.Models;
using System.Collections.Generic;

namespace AlgorithmsProvider.Provider.Interface
{
    public interface IMinAreaRectangleProvider
    {
        MinAreaRectangleModel GetMinAreaRectangle(Point[] points);
    }
}
