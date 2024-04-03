using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace C41_G02_MVC03.PL.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file,string FolderName)
        {
            //  1.Get loaded folder Path
            string folderParh = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\files",FolderName);
            if (!Directory.Exists(folderParh))
            {
                Directory.CreateDirectory(folderParh);
            }
            // 2.Get File name and make it UNIQUE
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            // 3.Git File Path
            string filePath= Path.Combine(folderParh,fileName);

            // 4.Safe File As Stream[Data per time]
            using var fileStream = new FileStream(filePath,FileMode.Create);
            file.CopyTo(fileStream);
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
