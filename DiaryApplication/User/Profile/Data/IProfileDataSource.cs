using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLib;

namespace DiaryApplication.User.Profile.Data
{
    interface IProfileDataSource
    {
        Task<bool> UpdateProfile(ProfileDTO profile);
        Task<ProfileDTO> GetProfileById(int id);
    }
}
