using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Core
{
    
    public static class Session
    {
        public static int IdProfile { get; private set; }
        public static Status Status { get; private set; }

        public static void SetId(int value)
        {
            IdProfile = value;
            Status = Status.Authorized;
        }

        public static void DeleteStatus()
        {
            IdProfile = -1;
            Status = Status.NotAuthorized;
        }
    }
}
