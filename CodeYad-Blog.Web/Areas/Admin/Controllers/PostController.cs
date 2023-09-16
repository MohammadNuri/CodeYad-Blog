using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Services.Posts;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.Web.Areas.Admin.Models.Posts;
using Microsoft.AspNetCore.Mvc;

namespace CodeYad_Blog.Web.Areas.Admin.Controllers
{
    public class PostController : AdminControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int pageId = 1, string title = "", string categorySlug = "")
        {
            var param = new PostFilterParams()
            {
                CategorySlug = categorySlug,
                Title = title,
                PageId = pageId,
                Take = 5
            };

            var model = _postService.GetPostsByFilter(param);

            return View(model);
        }
        //Add Post
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreatePostViewModel createViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = _postService.CreatePost(new CreatePostDto()
            {
                CategoryId = createViewModel.CategoryId,
                SubCategoryId = createViewModel.SubCategoryId == 0 ? null : createViewModel.SubCategoryId,
                UserId = User.GetUserId(),
                Title = createViewModel.Title,
                Slug = createViewModel.Slug.ToSlug(),
                Description = createViewModel.Description,
                ImageFile = createViewModel.ImageFile,
                CreationDate = DateTime.Now,
                IsSpecial = createViewModel.IsSpecial
            });

            if (result.Status != OperationResultStatus.Success)
            {
                ErrorAlert(result.Message);
                return View();
            }
            SuccessAlert("پست با موفقیت ثبت شد");
            return RedirectToAction("Index");
        }
        //Edit Post
        public IActionResult Edit(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
                return RedirectToAction("Index");

            var model = new EditPostViewModel
            {
                CategoryId = post.CategoryId,
                SubCategoryId = post.SubCategoryId,
                Title = post.Title,
                Slug = post.Slug,
                Description = post.Description,
                IsSpecial = post.IsSpecial
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditPostViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = _postService.EditPost(new EditPostDto()
            {
                CategoryId = editViewModel.CategoryId,
                SubCategoryId = editViewModel.SubCategoryId == 0 ? null : editViewModel.SubCategoryId,
                Title = editViewModel.Title,
                Slug = editViewModel.Slug,
                Description = editViewModel.Description,
                ImageFile = editViewModel.ImageFile,
                PostId = id,
                IsSpecial = editViewModel.IsSpecial
            });

            if (result.Status != OperationResultStatus.Success)
            {
                ErrorAlert(result.Message);
                return View();
            }
            SuccessAlert("پست با موفقیت ویرایش شد");
            return RedirectToAction("Index");
        }

    }
}
