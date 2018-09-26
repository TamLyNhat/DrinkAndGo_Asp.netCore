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
        void DeleteImport(int id);

        void Update(int id);

        IEnumerable<Import> GetByName(string keyword);
        IEnumerable<Import> GetAll();
    }
}
