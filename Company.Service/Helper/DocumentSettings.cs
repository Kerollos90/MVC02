using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {

        public static string FileUpload(IFormFile File , string FolderName)
        {
            var FoledrPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Files", FolderName);

            var filename = $"{Guid.NewGuid() }-{File.FileName }";

            var filepath = Path.Combine(FoledrPath, FolderName);

            using var filestream = new FileStream(filepath, FileMode.Create);
            File.CopyTo(filestream);
            return filename;






        }
    }
}
