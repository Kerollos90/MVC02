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

        public static string FileUpload(IFormFile file , string foldername)
        {
            var FoledrPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", foldername);

            var filename = $"{Guid.NewGuid() }-{file.FileName }";

            var filepath = Path.Combine(FoledrPath, filename);

            using var filestream = new FileStream(filepath, FileMode.Create);

            file.CopyTo(filestream);

            return filename;






        }



        
    }
}
