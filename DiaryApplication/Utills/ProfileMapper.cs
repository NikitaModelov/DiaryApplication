using System.Collections.Generic;
using System.Linq;
using DataBaseLib;
using DiaryApplication.Core.Model;

namespace DiaryApplication.Utills
{
    public static class ProfileMapper
    {
        public static ProfileDTO ConvertToDto(Profile profile)
        {
            return new ProfileDTO(profile.FirstName, profile.SecondName);
        }

        public static Profile ConvertFromDto(ProfileDTO profileDto)
        {
            return new Profile(profileDto.Id, profileDto.FirstName, profileDto.SecondName);
        }

        public static IEnumerable<Profile> ConvertFromProfilesDTO(List<ProfileDTO> profileDtos)
        {
            return profileDtos.Select(profile => ConvertFromDto(profile));
        }
    }
}
