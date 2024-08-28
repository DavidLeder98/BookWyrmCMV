using BookWyrm.DataAccess.Data;
using BookWyrm.DataAccess.Repository.IRepository;
using BookWyrm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookWyrm.DataAccess.Repository
{
	public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
	{
		private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(CategoryModel obj)
		{
			_db.Categories.Update(obj);
		}
	}
}
