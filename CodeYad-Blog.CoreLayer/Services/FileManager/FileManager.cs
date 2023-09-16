using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Http;

namespace CodeYad_Blog.CoreLayer.Services.FileManager
{
    public class FileManager : IFileManager
    {
        public void DeleteFile(string fileName, string path)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public string SaveImageAndReturnImageName(IFormFile file, string savePath)
        {
            var isNotImage = !ImageValidation.Validate(file);
            if (isNotImage)
                throw new Exception();

            return SaveFileReturnName(file, savePath);
        }

        public string SaveFileReturnName(IFormFile file, string savePath)
        {
            if (file == null)
                throw new Exception("File Is Null");

            var fileName = $"{Guid.NewGuid()}{file.FileName}";

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), savePath.Replace("/", "\\"));
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fullPath = Path.Combine(folderPath, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);
            return fileName;
        }
    }
}