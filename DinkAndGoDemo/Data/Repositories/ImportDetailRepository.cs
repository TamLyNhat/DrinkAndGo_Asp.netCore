using DinkAndGoDemo.Data.Interfaces;
using DinkAndGoDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Repositories
{
    public class ImportDetailRepository : IImportDetailRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<ImportDetail> dbSet;

        public ImportDetailRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            dbSet = appDbContext.Set<ImportDetail>();
        }

        //public void CreateImportDetail(ImportDetail importDetail)
        //{
        //    _appDbContext.ImportDetails.Add(importDetail);

        //    _appDbContext.SaveChanges();
        //}

        //public void DeleteImportDetail(ImportDetail importDetail)
        //{
        //    _appDbContext.Remove(importDetail);

        //    _appDbContext.SaveChanges();
        //}

        public IEnumerable<ImportDetail> GetAll()
        {
            return _appDbContext.ImportDetails.OrderBy(a => a.ImportDetailId).Include(a => a.Category).Include(t => t.Import);
        }

        public async Task<ImportDetail> GetById(int? id)
        {
            return await _appDbContext.ImportDetails.Include(a => a.Category).Include(t => t.Import).FirstOrDefaultAsync(s => s.ImportDetailId == id);
        }

        public ImportDetail GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public void UpdateImportDetail(ImportDetail importDetail)
        {
            dbSet.Attach(importDetail);
            _appDbContext.Entry(importDetail).State = EntityState.Modified;

            _appDbContext.SaveChanges();
        }

        //public async Task CreateImportDetail(ImportDetail importDetail)
        //{
        //    dbSet.Add(importDetail);

        //    await _appDbContext.SaveChangesAsync();
        //}

        public async Task CreateImportDetail(ImportDetail importDetail)
        {
            dbSet.Add(importDetail);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteImportDetail(ImportDetail importDetail)
        {
            dbSet.Remove(importDetail);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
