using AlgorithmsProvider.Models;
using AlgorithmsProvider.Provider.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsProvider.Provider.Implementation
{
    class MinAreaRectangleProvider : IMinAreaRectangleProvider
    {
        public double GetMinAreaRectangle(List<Point> points)
        {
            Point[] sortedPoints = GetSortedPoints(points);

            if (points.Count < 3)
            {
                return GetAreaLessThreePoints(sortedPoints);
            }

            double currentArea = 0.0;
            double minArea = 0.0;

            Dictionary<int, Point[]> wrongPoints = new Dictionary<int, Point[]>();
            Dictionary<int, Angle> allAngles = new Dictionary<int, Angle>();
            Dictionary<int, double> allArea = new Dictionary<int, double>();

            for (int firstPoint = 0; firstPoint < sortedPoints.Length - 1; firstPoint++)
            {
                for (int secondPoint = firstPoint + 1; secondPoint < sortedPoints.Length; secondPoint++)
                {
                    int currentNumber = secondPoint + firstPoint * (sortedPoints.Length - 1);
                    Point[] twoPoints = new Point[]
                    {
                        new Point
                        {
                            X = sortedPoints[firstPoint].X,
                            Y = sortedPoints[firstPoint].Y
                        },
                        new Point
                        {
                            X = sortedPoints[secondPoint].X,
                            Y = sortedPoints[secondPoint].Y
                        }
                    };

                    Angle angleBetweenTwoStraightLine = GetAngleBetweenTwoStraightLine(twoPoints);
                    Point[] newSortedPoints = GetAllNewCoordinatesPointsAfterTurningAxes(sortedPoints, angleBetweenTwoStraightLine);
                    allAngles.Add(currentNumber, angleBetweenTwoStraightLine);

                    Point[] newTwoPoints = new Point[]
                    {
                        new Point
                        {
                            X = newSortedPoints[firstPoint].X,
                            Y = newSortedPoints[firstPoint].Y
                        },
                        new Point
                        {
                            X = newSortedPoints[secondPoint].X,
                            Y = newSortedPoints[secondPoint].Y
                        }
                    };

                    if (GetSideOfRectangel(newTwoPoints) == 0)
                    {
                        wrongPoints.Add(currentNumber, newTwoPoints);
                    }

                    Point[] extraPoints = GetExtraPoints(newSortedPoints);

                    if (currentNumber == 1)
                    {
                        minArea = GetAreaRectangle(extraPoints);
                    }

                    currentArea = GetAreaRectangle(extraPoints);
                    allArea.Add(currentNumber, currentArea);

                    if (currentArea < minArea)
                    {
                        minArea = currentArea;
                    }
                }
            }

            return minArea;
        }

        private Point[] GetSortedPoints(List<Point> points)
        {
            return points.OrderByDescending(point => point.Y).ToArray();
        }

        private double GetAreaLessThreePoints(Point[] points)
        {
            return points.Length == 1 ? 0 : GetLengthBetweenTwoPoints(points);
        }

        //Angles are used to get new coordinates after turning axes.
        //cosA = (A1 * A2 + B1 * B2) / (sqrt(A1^2 + B1^2) * sqrt(A2^2 + B2^2))
        //More information: http://portal.tpu.ru:7777/SHARED/k/KONVAL/Sites/English_sites/G/l_Angle_f.htm
        private Angle GetAngleBetweenTwoStraightLine(Point[] twoPoints)
        {
            Point[] anglePoints = GetAnglePoints(twoPoints);

            GeneralEquationForStraightLine generalEquationForStraightLineTwoPoints = GetGeneralEquationForStraightLine(twoPoints);
            GeneralEquationForStraightLine generalEquationForStraightLineAnglesPoints = GetGeneralEquationForStraightLine(anglePoints);

            double cosA = (generalEquationForStraightLineTwoPoints.A * generalEquationForStraightLineAnglesPoints.A +
                           generalEquationForStraightLineTwoPoints.B * generalEquationForStraightLineAnglesPoints.B) /
                          (Math.Pow(
                               Math.Pow(generalEquationForStraightLineTwoPoints.A, 2.0) +
                               Math.Pow(generalEquationForStraightLineTwoPoints.B, 2.0),
                          (1.0 / 2.0)) *
                           Math.Pow(
                               Math.Pow(generalEquationForStraightLineAnglesPoints.A, 2.0) +
                               Math.Pow(generalEquationForStraightLineAnglesPoints.B, 2.0),
                          (1.0 / 2.0)));
            double sinA = Math.Sin(Math.Acos(cosA));

            return new Angle
            {
                CosA = cosA,
                SinA = sinA
            };
        }

        //Get min points along the axis Y or max points along the axis X for bilding straight line for turning axes
        private Point[] GetAnglePoints(Point[] twoPoints)
        {
            double delta = 1.0;

            if (twoPoints[0].Y == twoPoints[1].Y)
            {
                return new Point[]
                {
                    new Point
                    {
                        X = twoPoints[0].X >= twoPoints[1].X ? twoPoints[0].X : twoPoints[1].X,
                        Y = twoPoints[0].X >= twoPoints[1].X ? twoPoints[0].Y : twoPoints[1].Y
                    },
                    new Point
                    {
                        X = (twoPoints[0].X >= twoPoints[1].X ? twoPoints[0].X : twoPoints[1].X) + delta,
                        Y = twoPoints[0].X >= twoPoints[1].X ? twoPoints[0].Y : twoPoints[1].Y
                    }
                };
            }

            return new Point[]
            {
                new Point
                {
                    X = twoPoints[0].Y < twoPoints[1].Y ? twoPoints[0].X : twoPoints[1].X,
                    Y = twoPoints[0].Y < twoPoints[1].Y ? twoPoints[0].Y : twoPoints[1].Y
                },
                new Point
                {
                    X = (twoPoints[0].Y < twoPoints[1].Y ? twoPoints[0].X : twoPoints[1].X) + delta,
                    Y = twoPoints[0].Y < twoPoints[1].Y ? twoPoints[0].Y : twoPoints[1].Y
                }
            };
        }

        //Get the coefficients for the general equation of a line
        //General form: A1 * x + B1 * y + C1 = 0
        //More information: https://en.wikipedia.org/wiki/Linear_equation
        private GeneralEquationForStraightLine GetGeneralEquationForStraightLine(Point[] points)
        {
            return new GeneralEquationForStraightLine
            {
                A = points[1].Y - points[0].Y,
                B = (-1) * (points[1].X - points[0].X),
                C = (-1) * points[0].X * (points[1].Y - points[0].Y) - (-1) * points[0].Y * (points[1].X - points[0].X)
            };
        }

        private Point[] GetAllNewCoordinatesPointsAfterTurningAxes(Point[] points, Angle angleBetweenTwoStraightLine)
        {
            List<Point> newPoints = new List<Point>();

            foreach (var point in points)
            {
                newPoints.Add(GetNewCoordinatesPointAfterTurningAxes(point, angleBetweenTwoStraightLine));
            }

            return newPoints.ToArray();
        }

        //x' = x * cosA - y * sinA
        //y' = x * sinA + y * cosA
        //More information: https://en.wikipedia.org/wiki/Rotation_of_axes
        private Point GetNewCoordinatesPointAfterTurningAxes(Point point, Angle angle)
        {
            return new Point
            {
                X = point.X * angle.CosA - point.Y * angle.SinA,
                Y = point.X * angle.SinA + point.Y * angle.CosA
            };
        }

        // Returns 1 if the side lies on the Y axis, 2 if the side lies on the X axis.
        // Delta is user selectable.
        // This method is numerical, and does not give a 100% result (like many transformations presented here).
        // Returns 0 if this value is not present, which automatically means an error.
        private int GetSideOfRectangel(Point[] twoPoints)
        {
            double delta = 0.000002;

            return Math.Abs(twoPoints[0].X - twoPoints[1].X) < delta ? 1
                : (Math.Abs(twoPoints[0].Y - twoPoints[1].Y) < delta ? 2
                : 0);
        }

        //Get 4 extreme points for finding the area of a rectangle.
        //Pairs of points [[Xmin, Ymin]; [Xmin, Ymax]] and [[Xmin, Ymax], [Xmax, Ymax]].
        //Delta - a variant of the approximation of the area. Allows you to accurately hit all points in the polygon.
        private Point[] GetExtraPoints(Point[] newPoints)
        {
            List<Point> extraPoints = new List<Point>();
            double delta = 0.00002;

            extraPoints.Add(newPoints.OrderBy(point => point.X).ToArray().FirstOrDefault());          
            extraPoints.Add(newPoints.OrderBy(point => point.Y).ToArray().FirstOrDefault());          
            extraPoints.Add(newPoints.OrderByDescending(point => point.X).ToArray().FirstOrDefault());
            extraPoints.Add(newPoints.OrderByDescending(point => point.Y).ToArray().FirstOrDefault());

            return new Point[]
            {
                new Point
                {
                    X = extraPoints[0].X - delta,
                    Y = extraPoints[1].Y - delta
                },
                new Point
                {
                    X = extraPoints[0].X - delta,
                    Y = extraPoints[3].Y + delta
                },
                new Point
                {
                    X = extraPoints[0].X - delta,
                    Y = extraPoints[3].Y + delta
                },
                new Point
                {
                    X = extraPoints[2].X + delta,
                    Y = extraPoints[3].Y + delta
                },
            };
        }

        //The method for obtaining the area of a rectangle by 4 points.
        //S = LineByTwoPoints(A[[x1, y1]; [x2, y2]]) * LineByTwoPoints(B[x3, y3]; [x4, y4]]).
        //More information: https://en.wikipedia.org/wiki/Rectangle
        private double GetAreaRectangle(Point[] extraPoints)
        {
            double A = GetLengthBetweenTwoPoints(new Point[]
            {
                new Point
                {
                    X = extraPoints[0].X,
                    Y = extraPoints[0].Y
                },
                new Point
                {
                    X = extraPoints[1].X,
                    Y = extraPoints[1].Y
                }
            });

            double B = GetLengthBetweenTwoPoints(new Point[]
            {
                new Point
                {
                    X = extraPoints[2].X,
                    Y = extraPoints[2].Y
                },
                new Point
                {
                    X = extraPoints[3].X,
                    Y = extraPoints[3].Y
                }
            });

            return A * B;
        }

        //|X1 X2| = sqrt((x2 - x1)^2 + (y2 - y1)^2)
        //More information: https://en.wikipedia.org/wiki/Euclidean_distance
        private double GetLengthBetweenTwoPoints(Point[] points)
        {
            return Math.Pow((
                (points[1].X - points[0].X) * (points[1].X - points[0].X) +
                (points[1].Y - points[0].Y) * (points[1].Y - points[0].Y)),
                (1.0 / 2.0));
        }
    }
}