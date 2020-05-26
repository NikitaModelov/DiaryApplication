using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;
using DiaryApplication.Core.ResponseWrapper;
using DiaryApplication.Utills;

namespace DiaryApplication.SignIn.Data
{
    interface IProfilesRepository
    {
        Task<IResponseWrapper> GetAllProfiles();
        Task<IResponseWrapper> SendProfile(Profile profile);
    }
}
