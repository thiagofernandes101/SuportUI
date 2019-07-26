using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SuportAPI.Data;

namespace SuportAPI.API.User
{
    partial class UserController
    {
        [HttpGet("validate/{login}/{password}")]
        public async Task<ActionResult<VMs.User>> ValidadeUser(string login, string password)
        {
            try
            {
                // VERIFY
                var userID = await context.Users
                    .Where(x => x.Login == login && x.Password == password)
                    .Select( x => x.Id)
                    .FirstOrDefaultAsync();

                // RESULT
                if (userID > 0)
                    return OkResponse(await GetUserData(userID));
                else
                    throw new Exception("Usuario não cadastrado");                

            }
            catch(Exception ex) { return BadRequestResponse(ex); }
        }      
        
    }
}
