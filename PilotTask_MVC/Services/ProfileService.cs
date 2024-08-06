﻿using PilotTask_MVC.DataAccess;
using PilotTask_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PilotTask_MVC.Services
{
    public class ProfileService
    {
        private readonly ProfileRepository _profileDAL;

        public ProfileService(ProfileRepository profileDAL)
        {
            _profileDAL = profileDAL;
        }

        public void CreateProfile(Profile profile)
        {
            _profileDAL.InsertProfile(profile);
        }

        public void UpdateProfile(Profile profile)
        {
            _profileDAL.UpdateProfile(profile);
        }

        public void DeleteProfile(int profileId)
        {
            _profileDAL.DeleteProfile(profileId);
        }

        public Profile GetProfileById(int profileId)
        {
            var profiles = _profileDAL.GetProfiles();
            return profiles.Find(p => p.ProfileId == profileId);
        }

        public List<Profile> GetProfiles()
        {
            return _profileDAL.GetProfiles();
        }
    }
}