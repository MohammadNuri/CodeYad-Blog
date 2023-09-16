namespace CodeYad_Blog.CoreLayer.Utilities;

public class Directories
{
    public const string PostImage = "wwwroot/img/posts";
    public const string PostContentImage = "wwwroot/img/posts/content";
    public static string GetPostImage(string imageName) => $"{PostImage.Replace("wwwroot", "")}/{imageName}";
    public static string GetPostContentImage(string imageName) => $"{PostContentImage.Replace("wwwroot", "")}/{imageName}";

}