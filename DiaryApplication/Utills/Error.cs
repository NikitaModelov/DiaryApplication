using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Utills
{
    class Error : IResponseWrapper
    {
        public string Message { get; }

        public Error(string message)
        {
            Message = message;
        }
    }
}
