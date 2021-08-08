using ImportExcelDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDataAPI.Services
{
    public interface IImportItem
    {
        Task<ICollection<ImportItem>> GetImportItems(int id);
    }
}
