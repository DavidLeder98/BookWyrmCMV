using BookWyrmCMV.Data;
using BookWyrmCMV.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWyrmCMV.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<CategoryModel> objCategoryList = _db.Categories.ToList();
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
                _db.Categories.Add(obj);
                _db.SaveChanges();
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
            CategoryModel categoryFromDb = _db.Categories.Find(id);
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
				_db.Categories.Update(obj);
				_db.SaveChanges();
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
			CategoryModel categoryFromDb = _db.Categories.Find(id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View(categoryFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			CategoryModel? obj = _db.Categories.Find(id);
			if(obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
