using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLib;
using DataBaseLib.Database;

namespace DiaryApplication.User.Profile.Data.Local
{
    public class ProfileLocalDataSource : IProfileDataSource
    {
        private readonly IDataBaseProfile<ProfileDTO, bool> database;

        public ProfileLocalDataSource()
        {
            database = new DatabaseProfile();
        }

        public async Task<bool> UpdateProfile(ProfileDTO profile)
        {
            return await database.Update(profile);
        }

        public async Task<ProfileDTO> GetProfileById(int id)
        {
            return await database.SelectById(id);
        }
    }
}
