using Base;
using Base.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisAPI.Controllers
{
   
    [ApiController]
    [Route("[controller]")]

    public class AuthController : ControllerBase
    {
        RequestManager reqManager = RequestManager.Instance;


        [HttpPost]
        public BaseResponseMessage Post([FromBody] string msg)
        {

            var returnMessage = reqManager.OnProcessRequest(msg);

            return returnMessage;

        }

    }
}
