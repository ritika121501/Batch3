using Batch3_RealTimeProject.DAL.Repository;
using Batch3_RealTimeProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static NuGet.Packaging.PackagingConstants;

namespace Batch3_RealTimeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepo<Product> _productRepo;
        private readonly IGenericRepo<ProductImage> _productImageRepo;

        public HomeController(ILogger<HomeController> logger, IGenericRepo<Product> productRepo, IGenericRepo<ProductImage> productImageRepo)
        {
            _productRepo = productRepo;
            _productImageRepo = productImageRepo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> result; 
            
            var products = _productRepo.GetByIdForList();
            
            
            return View(products);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
