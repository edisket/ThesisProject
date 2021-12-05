using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Abstract
{
    public abstract class BaseProcess
    {

        public BaseMessage _message;
        public BaseResponseMessage _responseMessage;

        public abstract string trancode { get; }
        public abstract Type messageType { get; }

        public abstract void DoProcess();
    }
}
