using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Result
{
    public class RevokeStatus
    {
        public bool Revokestatus { get; set; }
        public string Message { get; set; }

        public static RevokeStatus SuccessResult(bool success, string message)
        {
            return new RevokeStatus
            { Revokestatus = true, Message = message };
        } 
        public static RevokeStatus FailedResult(bool success, string message)
        {
            return new RevokeStatus
            { Revokestatus = false, Message = message };
        }
    }
}
