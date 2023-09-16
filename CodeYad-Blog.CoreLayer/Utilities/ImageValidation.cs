using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace CodeYad_Blog.CoreLayer.Utilities
{
    public class ImageValidation
    {
        public static bool Validate(string imageName)
        {
            var extension = Path.GetExtension(imageName);
            if (extension == null)
                return false;

            return extension.ToLower() == ".png" || extension.ToLower() == ".jpg";
        }

        public static bool Validate(IFormFile file)
        {
            try
            {
                using var image = Image.FromStream(file.OpenReadStream());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}