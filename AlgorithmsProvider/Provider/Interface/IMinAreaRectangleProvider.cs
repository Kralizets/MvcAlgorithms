using AlgorithmsProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsProvider.Provider.Interface
{
    interface IMinAreaRectangleProvider
    {
        double GetMinAreaRectangle(List<Point> points);
    }
}
