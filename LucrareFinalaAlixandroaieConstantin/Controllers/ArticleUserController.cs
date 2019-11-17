using LucrareFinalaAlixandroaieConstantin.Database;
using LucrareFinalaAlixandroaieConstantin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucrareFinalaAlixandroaieConstantin.Controllers
{
    public class ArticleUserController : BaseSiteController<ArticleUserViewModel>
    {
        public ArticleUserController(ArticlesDbContext ctx) : base(ctx)
        {
        }
        public override async Task Add(ArticleUserViewModel vm)
        {
            var articleUser = new ArticleUserMapping()
            {
                ArticleId = vm.ArticleId,
                UserId = vm.UserId
            };
            _ctx.ArticleUserMappings.Add(articleUser);
            await _ctx.SaveChangesAsync();
        }

        public override Task Delete(int id)
        {
            //not used
            throw new NotImplementedException();
        }

        public override Task Edit(ArticleUserViewModel vm)
        {
            //not used
            throw new NotImplementedException();
        }

        public override Task<List<ArticleUserViewModel>> GetAsync()
        {
            //not used
            throw new NotImplementedException();
        }

        public override Task<ArticleUserViewModel> GetByIdAsync(int id)
        {
            //pending
            throw new NotImplementedException();
        }
    }
}
