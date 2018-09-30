using DinkAndGoDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Interfaces
{
    public interface IImportDetailRepository
    {
        //void CreateImportDetail(ImportDetail importDetail);
        void UpdateImportDetail(ImportDetail importDetail);
        //void DeleteImportDetail(ImportDetail importDetail);
        ImportDetail GetByID(int id);
        Task<ImportDetail> GetById(int? id);
        IEnumerable<ImportDetail> GetAll();
        Task CreateImportDetail(ImportDetail importDetail);
        Task DeleteImportDetail(ImportDetail importDetail);
    }
}
