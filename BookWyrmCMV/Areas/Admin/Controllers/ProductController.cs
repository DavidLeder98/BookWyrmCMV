using BookWyrm.DataAccess.Data;
using BookWyrm.DataAccess.Repository.IRepository;
using BookWyrm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWyrmCMV.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // - - SHOW PRODUCT LIST - -
        public IActionResult Index()
        {
            List<ProductModel> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        // - - CREATE PRODUCT - -
        public IActionResult Create()
        {
			//for the category select dropdown
			IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.Id.ToString()
			});
            ViewBag.CategoryList = CategoryList;
			return View();
        }
        [HttpPost]
        public IActionResult Create(ProductModel obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        // - - EDIT PRODUCT - -
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ProductModel productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(ProductModel obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        // - - DELETE PRODUCT - -
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ProductModel? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            ProductModel? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
