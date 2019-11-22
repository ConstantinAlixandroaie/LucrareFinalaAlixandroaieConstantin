using LucrareFinalaAlixandroaieConstantin.Database;
using LucrareFinalaAlixandroaieConstantin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucrareFinalaAlixandroaieConstantin.Controllers
{
    public class CategoryController : BaseSiteController<CategoryViewModel>
    {
        public CategoryController(ArticlesDbContext ctx) : base(ctx)
        {

        }
        public override Task Add(CategoryViewModel vm)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Edit(CategoryViewModel vm)
        {
            //not used
            throw new NotImplementedException();
        }

        public override Task<List<CategoryViewModel>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<CategoryViewModel> GetByIdAsync(int id)
        {
            //not used
            throw new NotImplementedException();
        }
    }
}
