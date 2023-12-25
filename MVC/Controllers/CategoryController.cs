using BLL.ManagerServices.Abstracts;
using ENTITIES.Models;
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
            List<Category> objCategoryList = _categoryManager.GetActives().ToList();

            List<CategoryViewModel> viewModelList = objCategoryList
                .Select(category => new CategoryViewModel
                {
                    CategoryID = category.ID,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                })
                .ToList();

            return View(viewModelList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                Category c = new()
                {
                    CategoryName = item.CategoryName,
                    Description = item.Description,
                };

                _categoryManager.Add(c);
                return RedirectToAction("Index", "Category");

            }
            return View();
        }
    }
}