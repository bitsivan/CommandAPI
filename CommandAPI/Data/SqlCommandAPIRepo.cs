using System;
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
            if(cmd==null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Add(cmd);
        }

        public void Delete(Command cmd)
        {
            if(cmd==null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()=>_context.CommandItems.ToList();

        public Command GetCommandById(int id)=>_context.CommandItems.FirstOrDefault(p=>p.Id==id);

        public bool SaveChanges()=>(_context.SaveChanges()>=0);
        public void Update(Command cmd)
        {
            //We don't need to do anything here
        }
    }
}