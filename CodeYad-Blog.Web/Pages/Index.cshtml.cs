﻿using CodeYad_Blog.CoreLayer.DTOs.MainPage;
using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Services.MainPage;
using CodeYad_Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeYad_Blog.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly IMainPageService _mainPageService;
        public IndexModel(IPostService postService, IMainPageService mainPageService)
        {
            _postService = postService;
            _mainPageService = mainPageService;
        }

        public MainPageDto MainPageData { get; set; }

        public void OnGet()
        {
            MainPageData = _mainPageService.GetData();
        }

        public IActionResult OnGetLatestPosts(string categorySlug)
        {
            var filterDto = _postService.GetPostsByFilter(new PostFilterParams()
            {
                CategorySlug = categorySlug,
                PageId = 1,
                Take = 6
            });
            return Partial("_LatestPosts", filterDto.Posts);
        }
        public IActionResult OnGetPopularPost()
        {
            return Partial("_PopularPosts", _postService.GetPopularPosts());
        }

    }
}
