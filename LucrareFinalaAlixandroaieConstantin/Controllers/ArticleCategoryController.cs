using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LucrareFinalaAlixandroaieConstantin.Database;
using LucrareFinalaAlixandroaieConstantin.Controllers;
using LucrareFinalaAlixandroaieConstantin.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LucrareFinalaAlixandroaieConstantin.Controllers
{
    public class ArticleCategoryController : BaseSiteController<ArticleCategoryViewModel>
    {
        public ArticleCategoryController(ArticlesDbContext ctx) :base(ctx)
        {

        }
        public override async Task Add(ArticleCategoryViewModel vm)
        {
            if(vm == null)
            throw new ArgumentNullException(nameof(vm));

            var artcateg = new ArticleCategoryMapping()
            {
                ArticleId = vm.ArticleId,
                CategoryId = vm.CategoryId,
            };
            _ctx.ArticleCategoryMappings.Add(artcateg);
            await _ctx.SaveChangesAsync();
        }

        public override async Task Delete(int id)
        {
            //to delete a mapping when the article is deleted
            var artcateg = await _ctx.ArticleCategoryMappings.FirstOrDefaultAsync(x => x.Id == id);
            if (artcateg == null)
                throw new ArgumentException($"The Mapping ith the give id ='{id}' was not found");
            _ctx.ArticleCategoryMappings.Remove(artcateg);
            await _ctx.SaveChangesAsync();
        }

        public override Task Edit(ArticleCategoryViewModel vm)
        {
            //never used
            throw new NotImplementedException();
        }

        public override Task<List<ArticleCategoryViewModel>> GetAsync()
        {
            //never used
           throw new NotImplementedException();
        }

        public override Task<ArticleCategoryViewModel> GetByIdAsync(int id)
        {
            //never used
            throw new NotImplementedException();
        }
    }
}
