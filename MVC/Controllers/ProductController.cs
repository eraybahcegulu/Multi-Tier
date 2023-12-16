using BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Project.CoreMVCUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var products = _productManager.GetAll();

            var productViewModel = new ProductViewModel
            {
                Products = products,
            };

            return View(productViewModel);
        }
    }
}