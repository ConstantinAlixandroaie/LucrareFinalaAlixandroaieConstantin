using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucrareFinalaAlixandroaieConstantin.ViewModels
{
    //This is a view model idetincal with the User class, as the user will be the author of the article. 
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public List<ArticleEditorViewModel> EditedArticles { get; set; }
    }

    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
