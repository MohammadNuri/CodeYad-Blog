using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.CoreLayer.Services.Categories;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace CodeYad_Blog.Web.Areas.Admin.Controllers
{
    public class CategoryController : AdminControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }

        [Route("/admin/category/add/{parentId?}")]
        public IActionResult Add(int? parentId)
        {
            return View();
        }

        [HttpPost("/admin/category/add/{parentId?}")]
        public IActionResult Add(int? parentId, CreateCategoryViewModel createViewModel)
        {
            createViewModel.ParentId = parentId;
            var result = _categoryService.CreateCategory(createViewModel.MapToDto());

            //Alert Using global.js and AdminControllerBase
            if (result.Status != OperationResultStatus.Success)
            {
                ErrorAlert(result.Message);
                return View();
            }
            SuccessAlert("گروه با موفقیت به دسته بندی اضافه شد");
            return RedirectToAction("Index");

            //or =>
            //return RedirectAndShowAlert(result, RedirectToAction("Index"));

        }
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryBy(id);

            if (category == null)
                return RedirectToAction("Index");

            var model = new EditCategoryViewModel()
            {
                Title = category.Title,
                Slug = category.Slug,
                MetaDescription = category.MetaDescription,
                MetaTag = category.MetaTag
            };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryViewModel editModel)
        {
            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Title = editModel.Title,
                Slug = editModel.Slug,
                MetaDescription = editModel.MetaDescription,
                MetaTag = editModel.MetaTag,
                Id = id
            });


            if (result.Status != OperationResultStatus.Success)
            {
                ErrorAlert(result.Message);
                return View();
            }
            SuccessAlert("گروه با موفقیت ویرایش شد");
            return RedirectToAction("Index");
        }

        public IActionResult GetChildCategories(int parentId)
        {
            var category = _categoryService.GetChildCategories(parentId);

            return new JsonResult(category);
        }
    }
}
