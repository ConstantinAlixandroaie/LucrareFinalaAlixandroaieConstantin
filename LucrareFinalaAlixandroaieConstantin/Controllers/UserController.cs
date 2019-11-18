using LucrareFinalaAlixandroaieConstantin.Database;
using LucrareFinalaAlixandroaieConstantin.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LucrareFinalaAlixandroaieConstantin.Controllers
{
    public class UserController : BaseSiteController<UserViewModel>
    {
        public UserController(ArticlesDbContext ctx) : base(ctx)
        {
        }
        public override Task Add(UserViewModel vm)
        {
            //performed by register
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            //never used
            throw new NotImplementedException();
        }

        public override Task Edit(UserViewModel vm)
        {
            //
            throw new NotImplementedException();
        }

        public override Task<List<UserViewModel>> GetAsync()
        {
            //never used
            throw new NotImplementedException();
        }

        public override async Task<UserViewModel> GetByIdAsync(int id)
        {
            var usr = await _ctx.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (usr == null)
                return null;
            var userArticles = await (from mapping in _ctx.ArticleUserMappings
                                      join userarticle in _ctx.Articles on mapping.UserId equals usr.UserId
                                      where mapping.UserId == usr.UserId
                                      select new ArticleUserViewModel()
                                      {
                                          ArticleId = userarticle.Id,
                                          UserId =usr.UserId
                                      }).ToListAsync();
            foreach (var art in userArticles)
            {
                art.Articles = await (from x in _ctx.Articles
                                         where x.Id == art.Id
                                         select new ArticleViewModel()
                                         {
                                             Id = x.Id,
                                             Title = x.Title,
                                             Author = x.Author,
                                             ArticleText = x.ArticleText,
                                             IssueDate = x.IssueDate,
                                             EditedDate = x.EditedDate
                                         }).ToListAsync();
            }
            var editedArticles = await (from mapping in _ctx.ArticleEditorMappings
                                        join editedarticle in _ctx.Articles on mapping.UserId equals usr.UserId
                                        where mapping.UserId == usr.UserId
                                        select new ArticleEditorViewModel()
                                        {
                                            ArticleId = editedarticle.Id,
                                            UserId = usr.UserId
                                        }).ToListAsync();
            foreach (var art in editedArticles)
            {
                art.Articles = await (from x in _ctx.Articles
                                      where x.Id == art.Id
                                      select new ArticleViewModel()
                                      {
                                          Id = x.Id,
                                          Title = x.Title,
                                          Author = x.Author,
                                          ArticleText = x.ArticleText,
                                          IssueDate = x.IssueDate,
                                          EditedDate = x.EditedDate
                                      }).ToListAsync();
            }
                
            return new UserViewModel()
            {
                EditedArticles=editedArticles,
                UserArticles = userArticles,
                UserId = usr.UserId,
                Username = usr.Username
            };
        }

        public async Task Register(string email, string password)
        {
            var hashAlgorithm = new SHA1CryptoServiceProvider();

            var u = new User()
            {
                Username = email,
                Password = Encoding.Default.GetString(hashAlgorithm.ComputeHash(Encoding.Default.GetBytes(password)))
            };

            _ctx.Users.Add(u);
            await _ctx.SaveChangesAsync();
        }

    }
}
