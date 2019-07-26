using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuportAPI.Data;

namespace SuportAPI.API.Comment
{
    partial class CommentController
    {
        [HttpPost("remove/{id}")]
        public async Task<ActionResult<bool>> Remove(int id)
        {
            try
            {
                var comment = await context.Comments
                    .Where(x => x.RowStatus == enRowStatus.Active && x.Id == id)
                    .FirstOrDefaultAsync();

                if (comment != null)
                {
                    comment.RowStatus = enRowStatus.Removed;
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
