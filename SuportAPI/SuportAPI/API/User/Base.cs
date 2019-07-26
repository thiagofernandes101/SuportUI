using Microsoft.AspNetCore.Mvc;
using SuportAPI.Data;
using System;

namespace SuportAPI.API.User
{
    [Route("api/user")]
    public partial class UserController : BaseAPI
    {
        private BaseContext context;        

        public UserController(BaseContext context)
        {
            this.context = context;
        }        
    }
}
