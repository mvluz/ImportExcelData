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
        public FileUploadSave FileUploadSave { get; set; }
        [NotMapped]
        public FileUploadError FileUploadError { get; set; }
        public FileUpload()
        {
        }
        public FileUpload(IFormFile excelFile)
        {
            ExcelFile = excelFile;
            FileUploadSave = new FileUploadSave();
            FileUploadError = new FileUploadError();
        }

        public FileUpload(IFormFile excelFile, FileUploadSave fileUploadSave, FileUploadError fileUploadError) : this(excelFile)
        {
            FileUploadSave = new FileUploadSave(); ;
            FileUploadError = new FileUploadError();
        }
    }
}
