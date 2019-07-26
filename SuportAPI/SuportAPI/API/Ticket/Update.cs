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
        [HttpPost("update")]
        public async Task<ActionResult<bool>> Update([FromBody] VMs.Ticket ticket)
        {
            try
            {
                var ticketData = await context.Tickets
                    .Where(x => x.RowStatus == enRowStatus.Active && x.Id == ticket.Id)
                    .FirstOrDefaultAsync();

                if (ticket != null)
                {
                    ticketData.Code = ticket.Code;
                    ticketData.Description = ticket.Description;
                    ticketData.OpeningDate = ticket.OpeningDate;
                    ticketData.ClosingDate = ticket.ClosingDate;
                    ticketData.TypeInner = (short)Enum.Parse(typeof(enType), ticket.Type);
                    ticketData.PriorityInner = (short)Enum.Parse(typeof(enPriority), ticket.Priority);
                    ticketData.StatusInner = (short)Enum.Parse(typeof(enStatus), ticket.Status);

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
