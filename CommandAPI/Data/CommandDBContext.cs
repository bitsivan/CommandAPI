using CommandAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Data
{
    public class CommandDBContext:DbContext
    {
        public CommandDBContext(DbContextOptions<CommandDBContext> options):base(options){}
        
        public DbSet<Command> CommandItems{get;set;}
    }
}