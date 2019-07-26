using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SuportAPI.Data;
using SuportAPI.API.User;

namespace SuportAPI.API.Comment
{
    partial class CommentController
    {
        [HttpGet("getComments/{id}")]
        public async Task<ActionResult<List<VMs.Comment>>> GetComments(int id)
        {
            try
            {
                var result = await GetCommentData(id);

                // RESULT
                return OkResponse(result);
            }
            catch(Exception ex) { return BadRequestResponse(ex); }
        }

        public async Task<List<VMs.Comment>> GetCommentData(int ticketId)
        {
            try
            {
                // QUERY
                List<int> dataIDComment = await context.TicketUser
                .Where(x => x.RowStatus == Data.enRowStatus.Active && x.TicketId == ticketId)
                .Select(x => x.Id)
                .ToListAsync();

                List<Data.Comments> comments = await context.Comments
                    .Where(x => x.RowStatus == Data.enRowStatus.Active && dataIDComment.Contains(x.TicketUserId))
                    .ToListAsync();

                List<VMs.Comment> vmComments = new List<VMs.Comment>();

                foreach (var comment in comments)
                {
                    vmComments.Add(await ConvertVMComment(comment));
                }

                return vmComments;
            }
            catch (Exception ex) { throw ex; }
            finally { context.Dispose(); }
        }

        private async Task<VMs.Comment> ConvertVMComment(Data.Comments comment)
        {
            VMs.Comment result = new VMs.Comment();

            try
            {
                result.Id = comment.Id;
                result.Description = comment.Comment;

                using (var user = new UserController(context))
                {
                    TicketUser ticketUserId = await context.TicketUser
                        .Where(x => x.RowStatus == Data.enRowStatus.Active && x.Id == comment.TicketUserId)                        
                        .FirstOrDefaultAsync();

                    result.TicketId = ticketUserId.TicketId;
                    result.User = await user.GetUserData(ticketUserId.UserId);
                }

                return result;
            }
            catch (Exception ex) { throw ex; }
            finally { context.Dispose(); }
        }
    }
}
