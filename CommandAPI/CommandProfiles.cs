using AutoMapper;
using CommandAPI.Data.DTOs;
using CommandAPI.Data.Models;

namespace CommandAPI
{
    public class CommandProfiles:Profile
    {
        public CommandProfiles()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command >();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command,CommandUpdateDto>();
            
        }
    }
}