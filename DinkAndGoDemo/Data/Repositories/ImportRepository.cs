using DinkAndGoDemo.Data.Interfaces;
using DinkAndGoDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Repositories
{
    public class ImportRepository : IImportRepositoy
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Import> dbSet;

        public ImportRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            dbSet = appDbContext.Set<Import>();
        }

        public void CreateImport(Import import)
        {
            import.ImportDate = DateTime.Now;

            _appDbContext.Imports.Add(import);

            _appDbContext.SaveChanges();
        }

        public void DeleteImport(Import entity)
        {
            _appDbContext.Remove(entity);

            _appDbContext.SaveChanges();
        }

        public IEnumerable<Import> GetByName(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return dbSet.Where(a => a.ProductName.Contains(keyword));
            else
                return GetAll();
        }

        public IEnumerable<Import> GetAll()
        {
            return _appDbContext.Imports.OrderBy(a => a.ImportId);
        }

        public void Update(Import entity)
        {
            dbSet.Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;

            _appDbContext.SaveChanges();
        }

        public async Task<Import> GetById(int? id)
        {
            return await _appDbContext.Imports.FirstOrDefaultAsync(m => m.ImportId == id);
        }

        public Import GetById(int id)
        {
            return dbSet.Find(id);
        }

    }
}
