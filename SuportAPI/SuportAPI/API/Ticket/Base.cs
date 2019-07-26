using Microsoft.AspNetCore.Mvc;
using SuportAPI.Data;
using System;

namespace SuportAPI.API.Ticket
{
    [Route("api/ticket")]
    public partial class TicketController : BaseAPI
    {
        private BaseContext context;

        public TicketController(BaseContext context)
        {
            this.context = context;
        }        
    }
}
