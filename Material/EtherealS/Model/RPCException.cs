using System;

namespace Material.EtherealS.Model
{
    public class RPCException : Exception
    {
        int Code;
        public RPCException(string message) : base(message)
        {

        }
    }
}
