using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportExcelDataAPI.Models
{
    public class ImportItem
    {
        [Key]
        public int ImportItemID { get; set; }

        [Required]
        [Column(TypeName ="date")]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string ProductName { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public double UnitaryValue { get; set; }
        [Required]
        public int ImportID { get; set; }
        public Import Import { get; set; }


        public ImportItem()
        {
        }

        public ImportItem(int importItemID, DateTime deliveryDate, string productName, int amount, double unitaryValue, Import import, int importID)
        {
            ImportItemID = importItemID;
            DeliveryDate = deliveryDate;
            ProductName = productName;
            Amount = amount;
            UnitaryValue = unitaryValue;
            Import = import;
            ImportID = importID;
        }

        public double SubTotal(ImportItem item)
        {
            return item.Amount + item.UnitaryValue;
        }

    }
}
