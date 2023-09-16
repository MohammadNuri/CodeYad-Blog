using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.Web.Areas.Admin.Models.Categories
{
    public class EditCategoryViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Title { get; set; }
        [Display(Name = "CategorySlug")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Slug { get; set; }
        [Display(Name = "MetaTag (با - از هم جدا کنید)")]
        public string MetaTag { get; set; }
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }
    }
}
