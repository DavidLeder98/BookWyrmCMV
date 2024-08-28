using BookWyrm.DataAccess.Data;
using BookWyrm.DataAccess.Repository.IRepository;
using BookWyrm.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWyrmCMV.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }

        public IActionResult Index()
        {
            List<CategoryModel> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        // - - CREATE CATEGORY - -
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryModel obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
				TempData["success"] = "Category created successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        // - - EDIT CATEGORY - -
		public IActionResult Edit(int? id)
		{
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            CategoryModel categoryFromDb = _categoryRepo.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

			return View(categoryFromDb);
		}
		[HttpPost]
		public IActionResult Edit(CategoryModel obj)
		{
			if (ModelState.IsValid)
			{
				_categoryRepo.Update(obj);
				_categoryRepo.Save();
				TempData["success"] = "Category updated successfully.";
				return RedirectToAction("Index");
			}
			return View();
		}

		// - - DELETE CATEGORY - -
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			CategoryModel? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View(categoryFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			CategoryModel? obj = _categoryRepo.Get(u => u.Id == id);
			if(obj == null)
			{
				return NotFound();
			}
			_categoryRepo.Remove(obj);
			_categoryRepo.Save();
			TempData["success"] = "Category deleted successfully.";
			return RedirectToAction("Index");
		}
	}
}
