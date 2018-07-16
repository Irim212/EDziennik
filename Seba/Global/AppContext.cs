using Microsoft.EntityFrameworkCore;
using Seba.Entities;

namespace Seba.Global
{
	public class AppContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }

		public AppContext(DbContextOptions<AppContext> options) : base(options)
		{
		}
	}
}
