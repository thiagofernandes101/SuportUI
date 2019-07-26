using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuportAPI.Data;

namespace SuportAPI.API.Ticket
{
    partial class TicketController
    {
        [HttpPost("remove/{id}")]
        public async Task<ActionResult<bool>> Remove(int id)
        {
            try
            {
                var ticket = await context.Tickets
                    .Where(x => x.RowStatus == enRowStatus.Active && x.Id == id)
                    .FirstOrDefaultAsync();

                if (ticket != null)
                {
                    ticket.RowStatus = enRowStatus.Removed;
                    await context.SaveChangesAsync();

                    return OkResponse(true);
                }
                else
                    throw new Exception("Registro não existe!");
            }
            catch(Exception ex) { return BadRequestResponse(ex); }
            finally { context.Dispose(); }
        }
    }
}
