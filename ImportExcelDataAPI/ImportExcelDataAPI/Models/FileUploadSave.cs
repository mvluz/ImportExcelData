using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDataAPI.Models
{
    [Keyless]
    public class FileUploadSave
    {
        [NotMapped]
        public DateTime DeliveryDate { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        [NotMapped]
        public int Amount { get; set; }
        [NotMapped]
        public double UnitaryValue { get; set; }
        [NotMapped]
        public List<FileUploadSave> ItemsList { get; set; }
        public FileUploadSave()
        {
            ItemsList = new List<FileUploadSave>();
        }
    }
}
