using DinkAndGoDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Interfaces
{
    public interface IImportDetailRepository
    {
        void CreateImportDetail(ImportDetail importDetail);
        void UpdateImportDetail(int id);
        void DeleteImportDetail(int id);
        ImportDetail GetByID(int id);
        IEnumerable<ImportDetail> GetAll();
    }
}
