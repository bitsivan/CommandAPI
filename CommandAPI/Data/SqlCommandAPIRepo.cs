using System.Collections.Generic;
using System.Linq;
using CommandAPI.Data.Interfaces;
using CommandAPI.Data.Models;

namespace CommandAPI.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandDBContext _context;
        public SqlCommandAPIRepo(CommandDBContext context)
        {
            _context=context;
        }
        public void Create(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()=>_context.CommandItems.ToList();

        public Command GetCommandById(int id)=>_context.CommandItems.FirstOrDefault(p=>p.Id==id);

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}