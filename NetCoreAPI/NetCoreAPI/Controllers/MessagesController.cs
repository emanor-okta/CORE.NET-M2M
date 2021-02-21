using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        
        [HttpGet]
        [Route("~/api/messages")]
        //[Authorize]
        [Authorize("ScopeCheck")]
        public IEnumerable<Message> Get()
        {

            Console.WriteLine(HttpContext.User.Claims.Count());
            foreach (var claim in HttpContext.User.Claims)
            {
                Console.WriteLine(claim);
            }

            List<Message> messages = new List<Message>() {
                new Message() {Date = DateTime.Now, Text = "This endpoint is protected."},
                new Message() { Date = DateTime.Now, Text = "Hello, world!" }
            };

            return messages;
            
        }
    }
}
