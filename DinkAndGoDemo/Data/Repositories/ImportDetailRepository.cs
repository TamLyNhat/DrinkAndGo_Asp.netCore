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
        }

        public void CreateImportDetail(ImportDetail importDetail)
        {
            _appDbContext.ImportDetails.Add(importDetail);

            _appDbContext.SaveChanges();
        }

        public void DeleteImportDetail(int id)
        {
            var entity = dbSet.Find(id);
            _appDbContext.Remove(entity);

            _appDbContext.SaveChanges();
        }

        public IEnumerable<ImportDetail> GetAll()
        {
            return _appDbContext.ImportDetails.ToList().OrderBy(a => a.ImportDetailId);
        }

        public ImportDetail GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public void UpdateImportDetail(int id)
        {
             var entity = dbSet.Find(id);
            dbSet.Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;

            _appDbContext.SaveChanges();
        }
    }
}
