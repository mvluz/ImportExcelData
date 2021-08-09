using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDataAPI.Models
{
    [Keyless]
    public class FileUploadError
    {
        [NotMapped]
        public int Line { get; set; }
        [NotMapped]
        public string Field { get; set; }
        [NotMapped]
        public string InfoError { get; set; }
        [NotMapped]
        public List<FileUploadError> ErrorList { get; set; }
        public FileUploadError()
        {
            ErrorList = new List<FileUploadError>();
        }
    }
}
