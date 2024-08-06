using PilotTask_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotTask_MVC.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        void InsertProfile(Profile profile);
        void UpdateProfile(Profile profile);
        void DeleteProfile(int profileId);
        List<Profile> GetProfiles();

    }
}
