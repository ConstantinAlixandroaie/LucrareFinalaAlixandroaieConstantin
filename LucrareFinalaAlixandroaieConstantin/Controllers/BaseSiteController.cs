using System.Collections.Generic;
using System.Threading.Tasks;
using LucrareFinalaAlixandroaieConstantin.Database;

namespace LucrareFinalaAlixandroaieConstantin.Controllers
{
    public abstract class BaseSiteController<T>
    {
        protected readonly ArticlesDbContext _ctx;

        public BaseSiteController(ArticlesDbContext ctx)
        {
            _ctx = ctx;
        }

        public abstract Task<List<T>> GetAsync();
        public abstract Task<T> GetByIdAsync(int id);
        public abstract Task Add(T vm);
        public abstract Task Edit(T vm);
        public abstract Task Delete(int id);
    }
}

