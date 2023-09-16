using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeYad_Blog.DataLayer.Entities
{
    public class PostComment : BaseEntity
    {

        public int UserId { get; set; }
        public int PostId { get; set; }
        [Required]
        public string Text { get; set; }

        #region Relations
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion

    }
}