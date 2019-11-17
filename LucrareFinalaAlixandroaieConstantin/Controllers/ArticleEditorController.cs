using LucrareFinalaAlixandroaieConstantin.Database;
using LucrareFinalaAlixandroaieConstantin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucrareFinalaAlixandroaieConstantin.Controllers
{
    public class ArticleEditorController :BaseSiteController<ArticleEditorViewModel>
    {
        public ArticleEditorController(ArticlesDbContext ctx):base(ctx)
        {

        }

        public override async Task Add(ArticleEditorViewModel vm)
        {
            var articleEditor = new ArticleEditorMapping()
            {
                ArticleId = vm.ArticleId,
                UserId = vm.UserId
            };
            _ctx.ArticleEditorMappings.Add(articleEditor);
            await _ctx.SaveChangesAsync();
        }

        public override Task Delete(int id)
        {
            //not used
            throw new NotImplementedException();
        }

        public override Task Edit(ArticleEditorViewModel vm)
        {
            //not used
            throw new NotImplementedException();
        }

        public override Task<List<ArticleEditorViewModel>> GetAsync()
        {
            //not used
            throw new NotImplementedException();
        }

        public override Task<ArticleEditorViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
