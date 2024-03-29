﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LucrareFinalaAlixandroaieConstantin.Controllers;
using LucrareFinalaAlixandroaieConstantin.Database;
using LucrareFinalaAlixandroaieConstantin.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LucrareFinalaAlixandroaieConstantin.Pages
{
    public class AddArticleModel : PageModel
    {
        private readonly ArticleController _articleController;
        [BindProperty]
        public ArticleViewModel Article { get; set; }
        public AddArticleModel(ArticlesDbContext ctx)
        {
            _articleController = new ArticleController(ctx);
        }

        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("/Login");
            return Page();
        }
        public async Task<IActionResult> OnPostAdd()
        {
            Article.Author = User.Identity.Name;
            await _articleController.Add(Article);
            return RedirectToPage("/Index");
        }

    }
}