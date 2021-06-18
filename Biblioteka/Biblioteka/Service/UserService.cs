using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Biblioteka.Service
{
    public class UserService : IUserService
    {

        private readonly IHttpContextAccessor _httpContext;
        public UserService(IHttpContextAccessor _httpContext)
        {
            this._httpContext = _httpContext;

        }
        public string getUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
