using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcelDataAPI.Models
{
    [Keyless]
    public class FileUpload
    {
        [NotMapped]
        public IFormFile ExcelFile { get; set; }
        [NotMapped]
        public List<FileUploadSave> FileUploadSave{ get; set; }
        [NotMapped]
        public List<FileUploadError> FileUploadError { get; set; }

        public FileUpload()
        {
            FileUploadSave = new List<FileUploadSave>();
            FileUploadError = new List<FileUploadError>();
        }

    }
}
