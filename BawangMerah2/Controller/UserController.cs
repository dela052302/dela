using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BawangMerah2.Model;

namespace BawangMerah2.Controller
{
    public class UserController
    {
        private loginQuery loginQuery = new loginQuery();

        public bool Login(User user)
        {
            return loginQuery.CekLogin(user.Username, user.Password);
        }
    }
}
