using Microsoft.AspNetCore.Mvc;
using SuportAPI.Data;
using System;

namespace SuportAPI.API.Comment
{
    [Route("api/comment")]
    public partial class CommentController : BaseAPI
    {
        private BaseContext context;

        public CommentController(BaseContext context)
        {
            this.context = context;
        }        
    }
}
