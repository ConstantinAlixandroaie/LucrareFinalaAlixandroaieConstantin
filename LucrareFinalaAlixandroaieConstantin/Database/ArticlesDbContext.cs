using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LucrareFinalaAlixandroaieConstantin.Database
{
    public class ArticlesDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ArticleEditorMapping> ArticleEditorMappings { get; set; }
        protected ArticlesDbContext()
        {

        }
        public ArticlesDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}

