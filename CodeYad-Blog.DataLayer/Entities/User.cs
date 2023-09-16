using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.DataLayer.Entities
{
    public class User : BaseEntity
    {

        [Required]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRole Role { get; set; }


        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> PostComments { get; }

    }

    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}
