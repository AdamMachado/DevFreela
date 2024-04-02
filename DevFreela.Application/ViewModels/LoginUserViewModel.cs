using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string password)
        {
            Email = email;
            Token = password;
        }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
