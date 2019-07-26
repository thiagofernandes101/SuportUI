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
        [HttpGet("getUser/{id}")]
        public async Task<ActionResult<VMs.User>> GetUser(int id)
        {
            try
            {               
                // GET DATA
                var result = await GetUserData(id);                

                // RESULT
                return OkResponse(result);
            }
            catch(Exception ex) { return BadRequestResponse(ex); }
        }

        public async Task<VMs.User> GetUserData(int id)
        {
            try
            {
                // QUERY
                var dataUser = await context.Users
                    .Where(x => x.RowStatus == Data.enRowStatus.Active && x.Id == id)
                    .FirstOrDefaultAsync();

                // MODELING
                var result = ConvertVMUser(dataUser);

                return result;
            }
            catch (Exception ex) { throw ex; }
            finally { context.Dispose(); }            
        }

        private VMs.User ConvertVMUser(Data.User user)
        {
            VMs.User result = new VMs.User();

            try
            {
                result.Id = user.Id;
                result.Name = user.Name;
                result.Type = user.Type.ToString();
                result.Login = user.Login;
                result.Password = user.Password;
                result.Company = user.Company;
                               
                return result;
            }
            catch(Exception ex) { throw ex; }
            
        }

    }
}
