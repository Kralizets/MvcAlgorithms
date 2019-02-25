using System.Web.Mvc;
using AlgorithmsProvider.Models;
using AlgorithmsProvider.Provider.Interface;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class AlgorithmsController : Controller
    {
        private readonly IHorspoolProvider _horspoolProvider;

        public AlgorithmsController(IHorspoolProvider horspoolProvider)
        {
            _horspoolProvider = horspoolProvider;
        }

        public ActionResult Horspool()
        {
            return View();
        }

        public ActionResult HorspoolResult(string inputString, string searchString)
        {
            return View(GetHorspoolViewModel(_horspoolProvider.AlgorithmHorspul(inputString, searchString)));
        }

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