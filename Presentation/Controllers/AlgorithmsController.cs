using System.Linq;
using System.Web.Mvc;
using AlgorithmsProvider.Models;
using AlgorithmsProvider.Provider.Interface;
using AutoMapper;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class AlgorithmsController : Controller
    {
        //need using configs
        private const string _pathForPointsWithoutIntersections = @"E:\Repository SourceTree\1_algo\Presentation\App_Data\Input.txt";

        private readonly IHorspoolProvider _horspoolProvider;
        private readonly IMinAreaRectangleProvider _minAreaRectangleProvider;
        private readonly IPointsWithoutIntersectionsProvider _pointsWithoutIntersectionsProvider;

        public AlgorithmsController(IHorspoolProvider horspoolProvider, IMinAreaRectangleProvider minAreaRectangleProvider,
            IPointsWithoutIntersectionsProvider pointsWithoutIntersectionsProvider)
        {
            _horspoolProvider = horspoolProvider;
            _minAreaRectangleProvider = minAreaRectangleProvider;
            _pointsWithoutIntersectionsProvider = pointsWithoutIntersectionsProvider;
        }

        public ActionResult Horspool()
        {
            return View();
        }

        public ActionResult HorspoolResult(string inputString, string searchString)
        {
            return View(Mapper.Map<HorspoolViewModel>(_horspoolProvider.AlgorithmHorspul(inputString, searchString)));
        }

        public ActionResult MinAreaRectangle()
        {
            return View();
        }

        [HttpPost]
        public double MinAreaRectangleResult(Point[] points)
        {
            if (points == null)
            {
                return 0;
            }

            return _minAreaRectangleProvider.GetMinAreaRectangle(points).MinAreaRectangle;
        }

        public ActionResult PointsWithoutIntersections()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PointsWithoutIntersectionsResultFromFiles()
        {
            Point[] points = _pointsWithoutIntersectionsProvider.GetPointsInFile(_pathForPointsWithoutIntersections);

            return Json(GetPointsForResult(points));
        }

        [HttpPost]
        public JsonResult PointsWithoutIntersectionsResultFromPoints(Point[] points)
        {
            return Json(GetPointsForResult(points));
        }

        private Point[] GetPointsForResult(Point[] points)
        {
            if (points != null && points.Any())
            {
                return _pointsWithoutIntersectionsProvider.GetOrderPointsWithoutIntersections(points);
            }

            return new Point[0];
        }
    }
}