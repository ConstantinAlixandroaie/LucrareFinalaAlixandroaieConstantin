using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LucrareFinalaAlixandroaieConstantin.Controllers;
using LucrareFinalaAlixandroaieConstantin.Database;
using LucrareFinalaAlixandroaieConstantin.ViewModels;

namespace LucrareFinalaAlixandroaieConstantin.Pages
{
    public class AddArticleModel : PageModel
    {
        private readonly ArticleController _articleController;
        public List<ArticleViewModel> Articles { get; set; }
        public ArticleViewModel Article { get; set; }
        public bool IsById { get; set; }
        public bool IsByCateg { get; set; }
        public AddArticleModel(ArticlesDbContext ctx)
        {
            _articleController = new ArticleController(ctx);
        }



    }
}