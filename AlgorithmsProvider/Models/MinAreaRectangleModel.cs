using System.Collections.Generic;

namespace AlgorithmsProvider.Models
{
    public class MinAreaRectangleModel
    {
        public Point[] AllSortedPoints { get; set; }
        public Dictionary<int, Point[]> WrongPoints { get; set; }
        public Dictionary<int, Point[]> AllExtraPoints { get; set; }
        public Dictionary<int, Angle> AllAngles { get; set; }
        public Dictionary<int, double> AllArea { get; set; }
        public double MinAreaRectangle { get; set; }
        public int NumberMinAreaRectangle { get; set; }
        public bool IsSmallPoints { get; set; }
    }
}
