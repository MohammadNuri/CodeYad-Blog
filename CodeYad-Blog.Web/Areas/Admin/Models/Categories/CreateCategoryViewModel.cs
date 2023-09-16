using CodeYad_Blog.CoreLayer.DTOs.Categories;
using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.Web.Areas.Admin.Models.Categories;

public class CreateCategoryViewModel
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
    public int? ParentId { get; set; }

    public CreateCategoryDto MapToDto()
    {
        return new CreateCategoryDto()
        {
            Title = Title,
            Slug = Slug,
            MetaTag = MetaTag,
            MetaDescription = MetaDescription,
            ParentId = ParentId,

        };
    }
}