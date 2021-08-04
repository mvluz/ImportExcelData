using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ImportExcelDataAPI.Models
{
    public class ImportItem
    {
        [Key]
        [Display(Name = "ID do Item")]
        public int ImportItemID { get; set; }

        [Required(ErrorMessage = "{0} é uma informação obrigatória")]
        [Display(Name = "Data de Entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "{0} é uma informação obrigatória")]
        [Display(Name = "Nome do Produto")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "{0} é uma informação obrigatória")]
        [Display(Name = "Quantidade")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "{0} é uma informação obrigatória")]
        [Display(Name = "Valor Unitário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double UnitaryValue { get; set; }

        public Import Import { get; set; }

        [Required]
        public int ImportID { get; set; }

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
