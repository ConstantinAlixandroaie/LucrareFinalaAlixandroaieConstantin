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
            if (vm.CategoryNames == null)
            {
                throw new ArgumentException("Category Name cannot be null");
            }
            //The input field for categories can be a string of multiple categories split by either comma "," or space " "
            // So I split that field into individual strings and create categories for each string.
            char[] separator = { ',', ' ' };
            var categoryname = vm.CategoryNames.Split(separator, StringSplitOptions.None);
            var categories = await _ctx.Categories.ToListAsync();
            //here I verify if the category name already exists. if it does I do not want to add another category with the same name
            //
            foreach (var categ in categories)
            {
                foreach (var categname in categoryname)
                {
                    if (categ.CategoryName != categname)
                    {
                        var category = new Category()
                        {
                            CategoryName = categname,
                        };
                        _ctx.Categories.Add(category);
                        await _ctx.SaveChangesAsync();
                    }
                }
            }
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
                    CategoryNames = category.CategoryName,
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
