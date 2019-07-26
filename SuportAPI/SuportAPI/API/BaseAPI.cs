using Microsoft.AspNetCore.Mvc;
using System;

namespace SuportAPI.API
{
    public class BaseAPI : Controller
    {
        protected ActionResult<T> OkResponse<T>(T value)
        {
            return new OkObjectResult(value);
        }

        protected ActionResult BadRequestResponse(Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}
