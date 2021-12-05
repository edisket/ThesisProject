using Auth.Dao;
using Auth.Entities.Messages;
using Base.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Process
{
    public class AuthenticateAccountProcess:BaseProcess
    {
        public override string trancode {
            get {
                return "AuthAccount";
            }
        }

        public override Type messageType => typeof(AuthenticateAccountMessage);

         public override void DoProcess()
        {

            var msg = (AuthenticateAccountMessage) _message;

            var dao = new AuthDao();

             msg.ResponseMessage.isValid =  dao.AuthenticateAccount(msg.RequestMessage.username, msg.RequestMessage.password);


            _responseMessage = msg.ResponseMessage;

        }
    }
}
