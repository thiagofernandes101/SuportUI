using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuportAPI.Data;

namespace SuportAPI.API.Ticket
{
    partial class TicketController
    {
        [HttpPost("add")]
        public async Task<ActionResult<bool>> Save([FromBody] VMs.Ticket ticket)
        {
            try
            {
                //Validation
                if (!context.Tickets
                    .Where(x => x.RowStatus == Data.enRowStatus.Active && x.Code == ticket.Code && x.Description == x.Description)
                    .Any())
                {
                    // TICKETS

                    var ticketId = context.Tickets
                    .Max(x => x.Id);

                    var dataTicket = new Data.Ticket
                    {                        
                        Id = ++ticketId,
                        Code = ticket.Code,
                        Description = ticket.Description,
                        UserId = ticket.Owner.Id,
                        OpeningDate = ticket.OpeningDate,
                        ClosingDate = ticket.ClosingDate,
                        TypeInner = (short)Enum.Parse(typeof(enType), ticket.Type),
                        StatusInner = (short)Enum.Parse(typeof(enStatus), ticket.Status),
                        PriorityInner = (short)Enum.Parse(typeof(enPriority), ticket.Priority),
                        RowStatus = enRowStatus.Active,
                        RowDate = DateTime.Now,                        
                    };

                    context.Tickets.Add(dataTicket);

                    // TICKET USER

                    var idTicketUser = context.TicketUser
                    .Max(x => x.Id);

                    var ticketUser = new TicketUser
                    {
                        Id = ++idTicketUser,
                        UserId = ticket.Owner.Id,
                        TicketId = ticketId,
                        RowStatus = enRowStatus.Active,
                        RowDate = DateTime.Now
                    };

                    context.TicketUser.Add(ticketUser);

                    await context.SaveChangesAsync();
                    
                    return OkResponse(true);
                }
                else
                    throw new Exception("Ticket já cadastrado!");
            }
            catch(Exception ex) { return BadRequestResponse(ex); }
            finally { context.Dispose(); }
        }
    }
}
