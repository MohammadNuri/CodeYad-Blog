using CodeYad_Blog.CoreLayer.Utilities;

namespace CodeYad_Blog.CoreLayer.DTOs.Posts;

public class PostFilterDto : BasePagination
{
    public List<PostDto> Posts { get; set; }
    public PostFilterParams FilterParams { get; set; }

}

public class PostFilterParams
{
    public int PageId { get; set; }
    public int Take { get; set; }
    public string Title { get; set; }
    public string CategorySlug { get; set; }
}