using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Entities;

namespace CodeYad_Blog.CoreLayer.Mappers;

public class PostMapper
{
    public static Post MapCreateDtoToPost(CreatePostDto dto)
    {
        return new Post()
        {
            Description = dto.Description,
            CategoryId = dto.CategoryId,
            SubCategoryId = dto.SubCategoryId,
            Slug = dto.Slug,
            Title = dto.Title,
            UserId = dto.UserId,
            Visit = 0,
            IsDelete = false,
            CreationDate = DateTime.Now,
            IsSpecial = dto.IsSpecial
        };
    }
    public static Post EditPost(EditPostDto editDto, Post post)
    {
        post.Description = editDto.Description;
        post.Title = editDto.Title;
        post.CategoryId = editDto.CategoryId;
        post.Slug = editDto.Slug.ToSlug();
        post.SubCategoryId = editDto.SubCategoryId;
        post.IsSpecial = editDto.IsSpecial;
        return post;
    }
    public static PostDto MapToDto(Post post)
    {
        return new PostDto()
        {
            Description = post.Description,
            CategoryId = post.CategoryId,
            Category = post.Category == null ? null : CategoryMapper.Map(post.Category),
            SubCategoryId = post.SubCategoryId,
            SubCategory = post.SubCategory == null ? null : CategoryMapper.Map(post.SubCategory),
            Slug = post.Slug,
            Title = post.Title,
            UserName = post.User?.FullName,
            Visit = post.Visit,
            CreationDate = post.CreationDate,
            ImageName = post.ImageName,
            PostId = post.Id,
            IsSpecial = post.IsSpecial
        };
    }
}