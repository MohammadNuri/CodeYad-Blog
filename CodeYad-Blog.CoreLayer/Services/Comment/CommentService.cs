using CodeYad_Blog.CoreLayer.DTOs.Comments;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using CodeYad_Blog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeYad_Blog.CoreLayer.Services.Comment;

public class CommentService : ICommentService
{
    private readonly BlogContext _context;

    public CommentService(BlogContext context)
    {
        _context = context;
    }

    public OperationResult CreateComment(CreateCommentDto command)
    {
        var comment = new PostComment()
        {
            PostId = command.PostId,
            Text = command.Text,
            UserId = command.UserId
        };
        _context.Add(comment);
        _context.SaveChanges();
        return OperationResult.Success();
    }

    public List<CommentDto> GetPostComment(int postId)
    {
        return _context.PostComments
            .Include(c => c.User)
            .Where(c => c.PostId == postId)
            .Select(comment => new CommentDto()
            {
                PostId = comment.PostId,
                Text = comment.Text,
                UserName = comment.User.UserName,
                CommentId = comment.Id,
                CreationDate = comment.CreationDate
            }).ToList();
    }
}