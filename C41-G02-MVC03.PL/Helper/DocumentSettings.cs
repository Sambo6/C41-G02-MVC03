using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace C41_G02_MVC03.PL.Helper
{
	public static class DocumentSettings
    {
        public static async Task<string> UploadFile(IFormFile file,string FolderName)
        {
            //  1.Get loaded folder Path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\files",FolderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            // 2.Get File name and make it UNIQUE
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            // 3.Git File Path
            var filePath = Path.Combine(folderPath,fileName);

            // 4.Safe File As Stream[Data per time]
            using var fileStream = new FileStream(filePath,FileMode.Create);
            await file.CopyToAsync(fileStream);
            return fileName;
        }

        public static void DeleteFile(string fileName, string FolderName) 
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName,fileName);
            if (File.Exists(filePath)) 
                File.Delete(filePath);
        }
    }
}
