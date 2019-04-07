using System.Web.Mvc;
using AlgorithmsProvider.Models;
using AlgorithmsProvider.Provider.Interface;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class AlgorithmsController : Controller
    {
        private readonly IHorspoolProvider _horspoolProvider;
        private readonly IMinAreaRectangleProvider _minAreaRectangleProvider;

        public AlgorithmsController(IHorspoolProvider horspoolProvider, IMinAreaRectangleProvider minAreaRectangleProvider)
        {
            _horspoolProvider = horspoolProvider;
            _minAreaRectangleProvider = minAreaRectangleProvider;
        }

        public ActionResult Horspool()
        {
            return View();
        }

        public ActionResult HorspoolResult(string inputString, string searchString)
        {
            return View(GetHorspoolViewModel(_horspoolProvider.AlgorithmHorspul(inputString, searchString)));
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

        //need add automap
        private HorspoolViewModel GetHorspoolViewModel(HorspoolModel horspoolModel)
        {
            return new HorspoolViewModel
            {
                InputString = horspoolModel.InputString,
                SearchString = horspoolModel.SearchString,
                IsFound = horspoolModel.IsFound,
                NumberOfLine = horspoolModel.NumberOfLine
            };
        }
    }
}