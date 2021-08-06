using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewCRUD_NetCore.Repository.Models.CustomExceptions
{
    public class DataErrorException : Exception
    {
        public DataErrorException()
        {
        }

        public DataErrorException(string message)
            : base(message)
        {
        }

        public DataErrorException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}