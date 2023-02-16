﻿

using AppCore.Results;
using AppCore.Results.Bases;
using Business.Models;
using DataAccess.Enums;

namespace Business.Services
{
	public interface IAccountService
	{
		Result Login(AccountLoginModel accountLoginModel, UserModel userResultModel);

		Result Register(AccountRegisterModel accountRegisterModel);
	}
	public class AccountService : IAccountService
	{
		private readonly IUserService _userService;

		public AccountService(IUserService userService)
		{
			_userService = userService;
		}

		public Result Login(AccountLoginModel accountLoginModel, UserModel userResultModel)
		{
			UserModel existingUser = _userService.Query().SingleOrDefault(us => us.UserName == accountLoginModel.UserName && us.Password == accountLoginModel.Password && us.IsActive);
			if (existingUser is null)
				return new ErrorResult("Invalid username and password!");
			userResultModel.UserName = existingUser.UserName;
			userResultModel.RoleName = existingUser.RoleName;

			userResultModel.Id = existingUser.Id;
			return new SuccessResult();
		}

		public Result Register(AccountRegisterModel accountRegisterModel)
		{
			UserModel userModel = new UserModel()
			{
				IsActive = true,
				Password = accountRegisterModel.Password,
				UserName = accountRegisterModel.UserName,
				RoleId = (int)Roles.User
			};
			return _userService.Add(userModel);
		}
	}
}
