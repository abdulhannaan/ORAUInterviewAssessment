using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ORAUInterviewEval.Core.Common;
using ORAUInterviewEval.Core.Interfaces;
using ORAUInterviewEval.Infrastructure.ViewModels;

namespace ORAUInterviewEval.Web.Controllers
{
    public class BusinessController : Controller
    {
        private readonly ITaskService _taskService;

        public BusinessController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Task1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task1(Task1ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.SaveEmail(model.PrimaryEmail);
                return RedirectToAction("Task1");
            }
            return View(model);
        }

        public IActionResult Task2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Task2(Task2ViewModel model)
        {
            return View();
        }

        public IActionResult Task3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task3(Task3ViewModel model)
        {
            if (model.Comment.Length > 99)
                return Json(new { ResponseMessage = "Error in saving comments.", Status = false });


            _taskService.SaveComment(model.Comment);
            return Json(new { ResponseMessage = "Comment Saved.", Status = true });
        }

        public IActionResult Task4()
        {
            return View();
        }

        public IActionResult Task5()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task5(Task5ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.SaveProfile(model.Profile);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Task5NewContactPartial()
        {
            return PartialView("Task5ContactPartial");
        }

        public IActionResult Task6()
        {
            return View();
        }

        /// <summary>
        /// Retrieves a paginated list of users for DataTables plugin.
        /// </summary>
        /// <param name="draw">Draw counter for DataTables.</param>
        /// <param name="start">Index of the first record to return (0-based).</param>
        /// <param name="length">Number of records to retrieve.</param>
        /// <returns>A JSON response containing paginated user data for DataTables.</returns>

        public IActionResult GetUsersByPaging()
       {
            int start, length = 0;

			var draw = Request.Form["draw"].FirstOrDefault();
			int.TryParse( Request.Form["start"].FirstOrDefault(), out start);
			int.TryParse( Request.Form["length"].FirstOrDefault(), out length);
			var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
			var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
			var searchValue = Request.Form["search[value]"].FirstOrDefault();

			// Calculate the page index based on start and length
			int pageIndex = start / length + 1;

            // Retrieve a paginated list of users
            var task6Vm = _taskService.GetUsers(pageIndex, length, searchValue, sortColumn, sortColumnDirection);

            // Return JSON response with paginated user data for DataTables
            return Json(new
            {
                draw = draw,
                recordsTotal = task6Vm.Total,
                recordsFiltered = task6Vm.Total,
                data = task6Vm.Users
            });
        }



    }
}
