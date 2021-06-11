using System.Collections.Generic;
using CommandAPI.Data.Models;

namespace CommandAPI.Data.Interfaces
{
    public interface ICommandAPIRepo
    {
         bool SaveChanges();
         IEnumerable<Command> GetAllCommands();
         Command GetCommandById(int id);
         void Create(Command cmd);
         void Update(Command cmd);
         void Delete(Command cmd);
    }
}