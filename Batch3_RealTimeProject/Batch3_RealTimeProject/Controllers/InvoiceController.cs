using Batch3_RealTimeProject.DAL.Repository;
using Batch3_RealTimeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch3_RealTimeProject.Controllers
{
    public class InvoiceController : Controller

    {
        private readonly IGenericRepo<Invoice> _genericRepoInvoice;
        public InvoiceController(IGenericRepo<Invoice> genericRepoInvoice)
        {
            _genericRepoInvoice = genericRepoInvoice;
        }

        [HttpGet]

        public IActionResult ShowInvoiceListWithUserId(string userId)
        {

            var listOfCate = _genericRepoInvoice.GetById(userId);
            return View(listOfCate);
        }

        //tempdata/ ViewBag/Viewdata
        //Http Verbs

        //what are the different state management techniques in mvc? -- Tempdata/ViewBag/ViewData/Query string/SEssions/Cookies

        //two way binding

        [HttpGet]
        public IActionResult GenerateInvoice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateInvoice(Invoice invoice)
        {
            double totalPrice = 0;

            _genericRepoInvoice.Create(invoice);

            TempData["Success"] = "order Created Successfully";
            //change required once UI is ready
            return RedirectToAction("ShowCategoryList");
        }

        [HttpGet]
        public IActionResult EditInvoice(int id)
        {
            return View(_genericRepoInvoice.GetById(id));
        }

        [HttpPost]

        public IActionResult EditCategory(Invoice invoice)
        {
            _genericRepoInvoice.Update(invoice);
            TempData["Success"] = "Category Updated Successfully";
            return RedirectToAction("ShowCategoryList");
        }
        [HttpGet]
        public IActionResult DeleteInvoice(int id)
        {
            var deleteInvoice = _genericRepoInvoice.GetById(id);
            if (deleteInvoice == null)
            {
                return NotFound();

            }
            _genericRepoInvoice.DeleteById(deleteInvoice);
            return RedirectToAction("ShowProductList");
        }
    }
}