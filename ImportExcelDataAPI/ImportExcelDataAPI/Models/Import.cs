using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportExcelDataAPI.Models
{
    public class Import
    {
        [Key]
        public int ImportID { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedON { get; set; }

        [Required]
        public string FileLocal { get; set; }
        public ICollection<ImportItem> ItemsList { get; set; } = new List<ImportItem>();

        public Import()
        {
        }

        public Import(int importID, DateTime createdON, string fileLocal)
        {
            ImportID = importID;
            CreatedON = createdON;
            FileLocal = fileLocal;
        }

        public void AddItems(ImportItem Item)
        {
            ItemsList.Add(Item);
        }

        public int TotalItemListAmount()
        {
            return ItemsList.Sum(Item => Item.Amount);
        }

        public double TotalItemListUnitayValue()
        {
            return ItemsList.Sum(item => item.Amount * item.UnitaryValue);
        }
    }
}
