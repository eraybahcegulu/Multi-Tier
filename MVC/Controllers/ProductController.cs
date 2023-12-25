using BLL.ManagerServices.Abstracts;
using BLL.ManagerServices.Concretes;
using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        public ProductController(IProductManager productManager, ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }


        /*
        public async Task<IActionResult> Index()
        {
            List<Product> obProductList = _productManager.GetActives().ToList();

            List<ProductViewModel> viewModelList = new List<ProductViewModel>();

            foreach (var product in obProductList)
            {
                var category = await _categoryManager.GetCategoryByIdAsync(product.CategoryID);

                viewModelList.Add(new ProductViewModel
                {
                    ProductID = product.ID,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice,
                    CategoryID = product.CategoryID,
                    CategoryName = category.CategoryName
                });
            }

            return View(viewModelList);
        }*/


        public IActionResult Index()
        {
            List<Product> obProductList = _productManager.GetActives().ToList();

            List<ProductViewModel> viewModelList = obProductList
                .Select(product => new ProductViewModel
                {
                    ProductID = product.ID,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice,
                    CategoryID = product.CategoryID
                })
                .ToList();

            return View(viewModelList);
        }

        public IActionResult Add()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult Add(ProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                Product c = new()
                {
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    CategoryID = item.CategoryID,
                };

                _productManager.Add(c);
                return RedirectToAction("Index", "Product");

            }
            return View();
        }
    }
}
