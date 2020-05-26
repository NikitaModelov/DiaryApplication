using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core;
using DiaryApplication.Core.Model;

namespace DiaryApplication.SignIn.Data
{
    interface IProfilesRepository
    {
        Task<List<Profile>> GetAllProfiles();
        void SendProfile(Profile profile);
    }
}
