
using AppCore.DataAccess.EntityFramework.Bases;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public abstract class UserRepoBase : RepoBase<User>
	{
		protected UserRepoBase(DbContext dbContext) : base(dbContext)
		{
		}
	}

	public class UserRepo : UserRepoBase
	{
		public UserRepo(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
