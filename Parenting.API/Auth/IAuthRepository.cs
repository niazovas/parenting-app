using System;
using Microsoft.AspNetCore.Mvc;
using Parenting.Server.Models;
using Parenting.Server.Services;

namespace Parenting.Server.Auth
{
	public interface IAuthRepository
	{
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string usernmae, string password);
        Task<bool> UserExist(string username);

    }
}

