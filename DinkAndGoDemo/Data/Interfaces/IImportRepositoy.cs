using DinkAndGoDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Interfaces
{
    public interface IImportRepositoy
    {
        void CreateImport(Import import);
        void DeleteImport(Import import);

        void Update(Import import);

        IEnumerable<Import> GetByName(string keyword);
        IEnumerable<Import> GetAll();
        Import GetById(int id);
        Task<Import> GetById(int? id);
    }
}
