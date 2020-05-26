using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Utills
{
    class Success<T> : IResponseWrapper
    {
        public T Data { get; }

        public Success(T data)
        {
            Data = data;
        }
    }
}
