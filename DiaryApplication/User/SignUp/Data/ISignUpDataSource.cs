using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLib;

namespace DiaryApplication.User.SignUp.Data
{
    interface ISignUpDataSource
    {
        Task<bool> SendProfile(ProfileDTO profile);
    }
}
