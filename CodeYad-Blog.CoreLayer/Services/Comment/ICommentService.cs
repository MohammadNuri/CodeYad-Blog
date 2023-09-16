using CodeYad_Blog.CoreLayer.DTOs.Comments;
using CodeYad_Blog.CoreLayer.Utilities;

namespace CodeYad_Blog.CoreLayer.Services.Comment;


public interface ICommentService
{
    OperationResult CreateComment(CreateCommentDto command);
    List<CommentDto> GetPostComment(int postId);
}