using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TakeTeste.Service
{
    public abstract class Service
    {
        protected string BaseApiUrl = "https://api.github.com/users/takenet/repos";
        protected string UserName = "";
        protected string PassWord = "";

    }
}
