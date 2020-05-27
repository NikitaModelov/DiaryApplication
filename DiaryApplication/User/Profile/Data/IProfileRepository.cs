﻿using System.Threading.Tasks;
using DiaryApplication.Core.ResponseWrapper;

namespace DiaryApplication.User.Profile.Data
{
    interface IProfileRepository
    {
        Task<IResponseWrapper> UpdateProfile(int id, Core.Model.Profile profile);
        Task<IResponseWrapper> GetProfileById(int id);
    }
}
