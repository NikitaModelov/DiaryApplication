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
        private readonly IDataBaseProfile<ProfileDTO, bool> databaseProfile;
        private readonly IDataBaseTask<TaskEntityDTO, bool> databaseTask;

        public ProfileLocalDataSource()
        {
            databaseProfile = new DatabaseProfile();
            databaseTask = new DatabaseTask();
        }

        public async Task<bool> UpdateProfile(ProfileDTO profile)
        {
            return await databaseProfile.Update(profile);
        }

        public async Task<ProfileDTO> GetProfileById(int id)
        {
            return await databaseProfile.SelectById(id);
        }

        public async Task<List<TaskEntityDTO>> GetProfileTasks(int idProfile)
        {
            return await databaseTask.GetTaskByProfile(idProfile);
        }
    }
}
