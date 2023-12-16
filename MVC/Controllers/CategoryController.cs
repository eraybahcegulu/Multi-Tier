using BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Project.CoreMVCUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var categories = _categoryManager.GetAll();

            var categoryViewModel = new CategoryViewModel
            {
                Categories = categories,
            };

            return View(categoryViewModel);
        }
    }
}