using ImportExcelDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDataAPI.Services
{
    public class ImportItemService 
    {
        private readonly APIContext _context;

        public ImportItemService(APIContext context)
        {
            _context = context;
        }

    }
}
