using PilotTask_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotTask_MVC.Services.Interfaces
{
    public interface IProfileService
    {
        void CreateProfile(Profile profile);
        void UpdateProfile(Profile profile);
        void DeleteProfile(int profileId);
        Profile GetProfileById(int profileId);
        List<Profile> GetProfiles();
    }
}
