using AlgorithmsProvider.Models;
using AlgorithmsProvider.Provider.Interface;
using AlgorithmsRepository.Models;
using AlgorithmsRepository.Repository.Interface;
using AutoMapper;
using System;
using System.Linq;

namespace AlgorithmsProvider.Provider.Implementation
{
    public class PointsWithoutIntersectionsProvider : IPointsWithoutIntersectionsProvider
    {
        private const double _delta = 10.0;
        private readonly IPointsWithoutIntersectionsRepository _pointsWithoutIntersectionsRepository;

        public PointsWithoutIntersectionsProvider(IPointsWithoutIntersectionsRepository pointsWithoutIntersectionsRepository)
        {
            _pointsWithoutIntersectionsRepository = pointsWithoutIntersectionsRepository;
        }

        public Point[] GetPointsInFile(string path)
        {
            return _pointsWithoutIntersectionsRepository.GetPointsInFiles(path)
                .Select(point => Mapper.Map<Point>(point))
                .ToArray();
        }

        public Point[] GetOrderPointsWithoutIntersections(Point[] points)
        {
            if (points.Any(point => point.X < 0 || point.Y < 0))
            {
                return GetPointsWithoutNegativeValue(points)
                    .Distinct()
                    .OrderBy(point => point.Y)
                    .OrderBy(point => point.X)
                    .ToArray();
            }

            return points.Distinct()
                .OrderBy(point => point.Y)
                .OrderBy(point => point.X)
                .ToArray();
        }

        private Point[] GetPointsWithoutNegativeValue(Point[] points)
        {
            double minX = Math.Abs(points.Min(point => point.X));
            double minY = Math.Abs(points.Min(point => point.Y));

            return points
                .Select(point => new Point
                {
                    X = point.X + minX + _delta,
                    Y = point.Y + minY + _delta
                })
                .ToArray();
        }
    }
}