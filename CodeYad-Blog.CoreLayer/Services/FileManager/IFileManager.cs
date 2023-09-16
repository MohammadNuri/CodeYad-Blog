using Microsoft.AspNetCore.Http;

namespace CodeYad_Blog.CoreLayer.Services.FileManager;

public interface IFileManager
{
    string SaveImageAndReturnImageName(IFormFile file, string savePath);
    string SaveFileReturnName(IFormFile file, string savePath);
    void DeleteFile(string fileName, string path);
}
