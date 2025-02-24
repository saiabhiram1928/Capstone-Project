﻿using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.Repositories.Interfaces
{
    public interface IAdminRepository : IRepository<int, Admin>
    {
        public Task<bool> CheckUserExistByUid(int uid);
    }
}
