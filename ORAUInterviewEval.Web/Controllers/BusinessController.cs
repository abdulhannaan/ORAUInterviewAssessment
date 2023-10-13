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

        public IActionResult GetUsersByPaging(int draw, int start, int length)
        {
            var model = new Task6ViewModel();

            // Calculate the page index based on start and length
            int pageIndex = start / length + 1;

            // Retrieve a paginated list of users
            model.Users = _taskService.GetUsers(pageIndex, length);

            // Get the total count of users (for pagination)
            int totalRecords = _taskService.GetTotalUsersCount();

            // Return JSON response with paginated user data for DataTables
            return Json(new
            {
                draw = draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = model.Users
            });
        }



    }
}
