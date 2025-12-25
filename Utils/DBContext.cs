using Microsoft.EntityFrameworkCore;
using SweatitBackEnd.Models.User;

public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
{
    public DbSet<BaseUser> Users => Set<BaseUser>();
}