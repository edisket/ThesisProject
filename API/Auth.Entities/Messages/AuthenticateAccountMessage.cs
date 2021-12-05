using Base.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Entities.Messages
{

    public class AuthenticateAccountMessage:BaseMessage
    {


        public AuthenticateAccountMessage() {

            RequestMessage = new Request();
            ResponseMessage = new Response();
        }

        public Request RequestMessage { get; set; }

        public Response ResponseMessage { get; set; }



        public class Request {
        
            public string username { get; set; }
            public string password { get; set; }
        }
        public class Response:BaseResponseMessage {
            public bool isValid { get; set; }
        }
    }
}
