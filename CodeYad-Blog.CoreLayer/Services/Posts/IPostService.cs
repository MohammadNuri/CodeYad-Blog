using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Utilities;

namespace CodeYad_Blog.CoreLayer.Services.Posts;

public interface IPostService
{
    OperationResult CreatePost(CreatePostDto command);
    OperationResult EditPost(EditPostDto command);
    PostDto GetPostById(int postId);
    PostDto GetPostBySlug(string slug);
    List<PostDto> GetRelatedPosts(int categoryId);
    List<PostDto> GetPopularPosts();
    PostFilterDto GetPostsByFilter(PostFilterParams filterParams);
    bool IsSlugExists(string slug);
    void IncreaseVisit(int postId);
}