using DinkAndGoDemo.Data.Interfaces;
using DinkAndGoDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> Categories => _appDbContext.Categories;

        public IEnumerable<Category> GetAll()
        {
            return _appDbContext.Categories.OrderBy(s => s.CategoryId);
        }
    }
}
