using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;

namespace DiaryApplication.User.SignUp.Data
{
    interface ISignUpRepository
    {
        Task<IResponseWrapper> SendProfile(Core.Model.Profile profile);
    }
}
