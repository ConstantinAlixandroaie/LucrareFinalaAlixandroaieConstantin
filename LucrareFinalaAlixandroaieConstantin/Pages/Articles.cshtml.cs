using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LucrareFinalaAlixandroaieConstantin.Database;
using LucrareFinalaAlixandroaieConstantin.Controllers;
using LucrareFinalaAlixandroaieConstantin.ViewModels;


namespace LucrareFinalaAlixandroaieConstantin.Pages
{
    public class ArticlesModel : PageModel
    {
        private readonly ArticleController _articleController;
        [BindProperty]
        public List<ArticleViewModel> Articles { get; set; }
        [BindProperty]
        public ArticleViewModel Article { get; set; }
        public bool IsById { get; set; }
        public bool IsByCateg { get; set; }
        public ArticlesModel(ArticlesDbContext ctx)
        {
            _articleController = new ArticleController(ctx);
        }
    }
}