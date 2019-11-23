using LucrareFinalaAlixandroaieConstantin.Database;
using LucrareFinalaAlixandroaieConstantin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LucrareFinalaAlixandroaieConstantin.Controllers
{
    public class CategoryController : BaseSiteController<CategoryViewModel>
    {
        public CategoryController(ArticlesDbContext ctx) : base(ctx)
        {

        }
        public override async Task Add(CategoryViewModel vm)
        {
            if (vm == null)
            {
                throw new ArgumentNullException(nameof(vm));
            }
            if (vm.CategoryName == null)
            {
                throw new ArgumentException("Category Name cannot be null");
            }

            var category = new Category()
            {
                CategoryName = vm.CategoryName,
            };
            _ctx.Categories.Add(category);
            await _ctx.SaveChangesAsync();
        }

        public override Task Delete(int id)
        {
            //most probably never used
            throw new NotImplementedException();
        }

        public override Task Edit(CategoryViewModel vm)
        {
            //not used
            throw new NotImplementedException();
        }

        public override async Task<List<CategoryViewModel>> GetAsync()
        {
            var rv = new List<CategoryViewModel>();
            var categories = await _ctx.Categories.ToListAsync();
            foreach (var category in categories)
            {
                var vm = new CategoryViewModel()
                {
                    CategoryName = category.CategoryName,
                };
                rv.Add(vm);
            }
            return rv;
        }

        public override Task<CategoryViewModel> GetByIdAsync(int id)
        {
            //not used
            throw new NotImplementedException();
        }
    }
}
