using System.Collections.Generic;
using CommandAPI.Data.Interfaces;
using CommandAPI.Data.Models;

namespace CommandAPI.Data
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        public void Create(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Command cmd)
        {
            throw new System.NotImplementedException();
        }


        public IEnumerable<Command> GetAllCommands()
        {
            var commands=new List<Command>
            {
                new Command{
                    Id=0,
                    HowTo="How To generate a migration",
                    CommandLine="dotnet ef migrations add <Name of Migrations>",
                    Platform=".Net Core EF"
                },
                new Command{
                    Id=1,
                    HowTo="How To generate a migration",
                    CommandLine="dotnet ef migrations add <Name of Migrations>",
                    Platform=".Net Core EF"
                },
                new Command{
                    Id=2,
                    HowTo="How To generate a migration",
                    CommandLine="dotnet ef migrations add <Name of Migrations>",
                    Platform=".Net Core EF"
                },
                
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{
                Id=0,
                HowTo="How to generate migration",
                CommandLine="dotnet ef migrations add <Name of Migration>",
                Platform=".Net Core EF"
            };
        }

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