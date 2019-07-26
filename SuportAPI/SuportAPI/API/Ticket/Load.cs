using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SuportAPI.Data;
using SuportAPI.API.User;
using SuportAPI.API.Comment;

namespace SuportAPI.API.Ticket
{
    partial class TicketController
    {
        [HttpGet("getTickets")]
        public async Task<ActionResult<List<VMs.Ticket>>> GetTickets()
        {
            try
            {
                // QUERY
                var ticketList = await context.Tickets
                    .Where(x => x.RowStatus == Data.enRowStatus.Active)
                    .ToListAsync();

                // MODELING
                List<Data.Ticket> dataTicktes = ticketList.ToList();
                List<VMs.Ticket> result = new List<VMs.Ticket>();
                foreach(Data.Ticket item in dataTicktes)
                {
                    result.Add(await ConvertVMTicket(item));
                }

                // RESULT
                return OkResponse(result);
            }
            catch(Exception ex) { return BadRequestResponse(ex); }
            finally { context.Dispose(); }
        }

        [HttpGet("getTicket/{id}")]
        public async Task<ActionResult<VMs.Ticket>> GetTickets(int id)
        {
            try
            {
                // QUERY
                var ticket = await context.Tickets
                    .Where(x => x.RowStatus == Data.enRowStatus.Active && x.Id == id)
                    .FirstOrDefaultAsync();

                // MODELING                
                var result = await ConvertVMTicket(ticket);                

                // RESULT
                return OkResponse(result);
            }
            catch (Exception ex) { return BadRequestResponse(ex); }
            finally { context.Dispose(); }
        }

        private async Task<VMs.Ticket> ConvertVMTicket(Data.Ticket ticket)
        {
            VMs.Ticket result = new VMs.Ticket();

            try
            {
                result.Id = ticket.Id;
                result.Code = ticket.Code;
                result.Description = ticket.Description;
                result.OpeningDate = ticket.OpeningDate;
                result.ClosingDate = ticket.ClosingDate;
                result.Priority = ticket.Priority.ToString();
                result.Status = ticket.Status.ToString();
                result.Type = ticket.Type.ToString();

                using (var user = new UserController(context))
                {
                    result.Owner = await user.GetUserData(ticket.UserId);
                }

                using (var comment = new CommentController(context))
                {
                    result.Comments = await comment.GetCommentData(ticket.Id);
                }

                    return result;
            }
            catch(Exception ex) { throw ex; }
            
        }

    }
}
