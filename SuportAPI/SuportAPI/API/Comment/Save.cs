using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuportAPI.Data;

namespace SuportAPI.API.Comment
{
    partial class CommentController
    {
        [HttpPost("add")]
        public async Task<ActionResult<bool>> Save([FromBody] VMs.Comment comment)
        {
            try
            {
                var ticketUserID = -1;

                var tickerUser = await context.TicketUser
                    .Where(x => x.RowStatus == enRowStatus.Active && x.TicketId == comment.TicketId && x.UserId == comment.User.Id)
                    .FirstOrDefaultAsync();

                if (tickerUser != null)
                {

                    ticketUserID = tickerUser.Id;
                }
                else
                {
                    // TICKET USER
                    ticketUserID = context.TicketUser
                    .Max(x => x.Id);

                    var ticketUser = new TicketUser
                    {
                        Id = ++ticketUserID,
                        UserId = comment.User.Id,
                        TicketId = comment.TicketId,
                        RowStatus = enRowStatus.Active,
                        RowDate = DateTime.Now
                    };

                    context.TicketUser.Add(ticketUser);
                    await context.SaveChangesAsync();
                }
                
                // COMMENT
                var commentId = context.Comments
                .Max(x => x.Id);

                var dataComment = new Data.Comments
                {
                    Id = ++commentId,
                    Comment = comment.Description,
                    TicketUserId = ticketUserID,                
                    RowStatus = enRowStatus.Active,
                    RowDate = DateTime.Now,                        
                };

                context.Comments.Add(dataComment);

                await context.SaveChangesAsync();
                    
                return OkResponse(true);
                
            }
            catch(Exception ex) { return BadRequestResponse(ex); }
            finally { context.Dispose(); }
        }
    }
}
