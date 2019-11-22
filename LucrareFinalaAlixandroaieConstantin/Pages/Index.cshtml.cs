using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LucrareFinalaAlixandroaieConstantin.Controllers;
using LucrareFinalaAlixandroaieConstantin.Database;
using LucrareFinalaAlixandroaieConstantin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LucrareFinalaAlixandroaieConstantin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ArticleController _articleController;
        [BindProperty]
        public List<ArticleViewModel> Articles { get; set; }
        [BindProperty]
        public ArticleViewModel SingleArticle { get; set; }
        [BindProperty]
        public bool IsById { get; set; }
        public IndexModel(ArticlesDbContext ctx)
        {
            _articleController = new ArticleController(ctx);
        }


    }
}
