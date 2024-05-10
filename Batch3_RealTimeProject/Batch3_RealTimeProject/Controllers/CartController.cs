using Batch3_RealTimeProject.DAL.Repository;
using Batch3_RealTimeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch3_RealTimeProject.Controllers
{
    public class CartController : Controller

    {
       private readonly IGenericRepo<Cart> _genericRepoCart;
        public CartController(IGenericRepo<Cart> genericRepoCart)
        {
            _genericRepoCart = genericRepoCart;
        }

        [HttpGet]

        public IActionResult ShowCartListWithUserId(string userId)
        {
            
            var listOfCate = _genericRepoCart.GetById(userId);
            return View(listOfCate);
        }

        //tempdata/ ViewBag/Viewdata
        //Http Verbs

        //what are the different state management techniques in mvc? -- Tempdata/ViewBag/ViewData/Query string/SEssions/Cookies

        //two way binding

        [HttpGet]
        public IActionResult AddToCart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(Cart cart)
        {
            _genericRepoCart.Create(cart);
           
            TempData["Success"] = "order Created Successfully";
            //change required once UI is ready
            return RedirectToAction("ShowCategoryList");
        }

        [HttpGet]
        public IActionResult EditCart(int id)
        {
            return View(_genericRepoCart.GetById(id));
        }

        [HttpPost]

        public IActionResult EditCategory(Cart cart)
        {
            _genericRepoCart.Update(cart);
            TempData["Success"] = "Category Updated Successfully";
            return RedirectToAction("ShowCategoryList");
        }
        [HttpGet]
        public IActionResult DeleteCart(int id)
        {
            var deleteCart = _genericRepoCart.GetById(id);
            if (deleteCart == null)
            {
                return NotFound();

            }
            _genericRepoCart.DeleteById(deleteCart);
            return RedirectToAction("ShowProductList");
        }
    }
}