using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ImportExcelDataAPI.Models
{
    public class Import
    {
        [Key]
        [Display(Name = "ID do Item")]
        public int ImportID { get; set; }

        [Display(Name = "Data e Hora da Importação")]
        public DateTime CreatedON { get; set; }

        [Display(Name = "Local do Arquivo")]
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

        public double TotalItemListAmount()
        {
            return ItemsList.Sum(Item => Item.Amount);
        }

        public double TotalItemListUnitayValue()
        {
            return ItemsList.Sum(item => item.Amount * item.UnitaryValue);
        }
    }
}
