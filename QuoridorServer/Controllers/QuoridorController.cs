using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuoridorServerBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoridorServer.Controllers
{
    [Route("QuoridorAPI")]
    [ApiController]
    public class QuoridorController : ControllerBase
    {
        #region Add connection to the db context using dependency injection
        QuoridorDBContext context;
        public QuoridorController(QuoridorDBContext context)
        {
            this.context = context;
        }
        #endregion
    }
}
