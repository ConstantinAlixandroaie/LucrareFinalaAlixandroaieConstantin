using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucrareFinalaAlixandroaieConstantin.Database
{
    public class ArticleCategoryMapping
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }
    }
}
