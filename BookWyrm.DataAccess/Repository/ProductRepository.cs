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
	public class ProductRepository : Repository<ProductModel>, IProductRepository
	{
		private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

		public void Update(ProductModel obj)
		{
			_db.Products.Update(obj);
		}
	}
}
