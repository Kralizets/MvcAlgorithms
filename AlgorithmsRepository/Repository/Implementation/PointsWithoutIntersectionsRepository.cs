using AlgorithmsRepository.Models;
using AlgorithmsRepository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlgorithmsRepository.Repository.Implementation
{
    public class PointsWithoutIntersectionsRepository : IPointsWithoutIntersectionsRepository
    {
        public List<PointDb> GetPointsInFiles(string path)
        {
            string currentPointFromFileOnFromatString;
            List<PointDb> currentListPoints = new List<PointDb>();

            try
            {
                Encoding enc = Encoding.GetEncoding(1251);
                using (StreamReader sr = new StreamReader(path, enc))
                {
                    while ((currentPointFromFileOnFromatString = sr.ReadLine()) != null)
                    {
                        currentListPoints.Add(
                            new PointDb
                            {
                                X = double.Parse(currentPointFromFileOnFromatString.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)[0]),
                                Y = double.Parse(currentPointFromFileOnFromatString.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)[1])
                            });
                    }

                    return currentListPoints;
                }
            }
            catch (Exception ex)
            {
                //need log's. May be nlog.
                return new List<PointDb>();
            }            
        }
    }
}