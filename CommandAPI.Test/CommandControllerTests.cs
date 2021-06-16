using System;
using System.Collections.Generic;
using AutoMapper;
using CommandAPI.Controllers;
using CommandAPI.Data.DTOs;
using CommandAPI.Data.Interfaces;
using CommandAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CommandAPI.Test
{
    public class CommandControllerTests: IDisposable
    {
        Mock<ICommandAPIRepo>mockRepo;
        CommandProfiles realProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        public CommandControllerTests()
        {
            mockRepo=new Mock<ICommandAPIRepo>();
            realProfile=new CommandProfiles();
            configuration=new MapperConfiguration(cfg=>cfg.AddProfile(realProfile));
            mapper=new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo=null;
            mapper=null;
            configuration=null;
            realProfile=null;
        }

        [Fact]
        public void GetCommandItems_ReturnsZeroItems_WhenDBIsEmpty()
        {
            //Arrange
            mockRepo=new Mock<ICommandAPIRepo>();
            mockRepo.Setup(r=>r.GetAllCommands()).Returns(GetCommands(0));

             realProfile=new CommandProfiles();
             configuration=new MapperConfiguration(cfg=>cfg.AddProfile(realProfile));
            IMapper mapper=new Mapper(configuration);

            //We need to create an instance of our CommandsController class
            var controller=new CommandsController(mockRepo.Object, mapper);

            //Act
            var result=controller.GetAllCommands();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllCommands_ReturnsOneItem_Tests()
        {
            //Arrange
            mockRepo.Setup(repo=>repo.GetAllCommands()).Returns(GetCommands(1));
            var controller=new CommandsController(mockRepo.Object, mapper);
            //Act
            var result=controller.GetAllCommands();
            //Assert
            var okResult=result.Result as OkObjectResult;
            var commands=okResult.Value as List<CommandReadDto>;
            Assert.Single(commands);
            
        }

        [Fact]
        public void GetAllCommands_Returns200OK_Tests()
        {
            //arrange
            mockRepo.Setup(repo=>repo.GetAllCommands()).Returns(GetCommands(1));
            var controller=new CommandsController(mockRepo.Object, mapper);
            //Act
            var result=controller.GetAllCommands();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllCommands_ReturnsCorrectType_Tests()
        {
            //Arrange
            mockRepo.Setup(repo=>repo.GetAllCommands()).Returns(GetCommands(1));
            var controller=new CommandsController(mockRepo.Object, mapper);
            //Act
            var result=controller.GetAllCommands();
            //Assert
            Assert.IsType<ActionResult<IEnumerable<CommandReadDto>>>(result);
        }

        [Fact]
        public void GetCommandByID_Returns404NotFound_Test()
        {
            //Arrange
            mockRepo.Setup(repo=>repo.GetCommandById(0)).Returns(()=>null);
            var controller=new CommandsController(mockRepo.Object, mapper);
            //Act
            var result=controller.GetCommandById(1);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CreateCommandReturnsCorrectResourceType()
        {
            //Arrange
            mockRepo.Setup(repo=>repo.GetCommandById(1)).Returns(new Command{
                Id=1,
                HowTo="Mock",
                Platform="mock",
                CommandLine="Mock"
            });
            var controller=new CommandsController(mockRepo.Object, mapper);
            //Act
            var result=controller.CreateCommand(new CommandCreateDto{});
            //Assert
            Assert.IsType<ActionResult<CommandReadDto>>(result);
        }

        public List<Command> GetCommands(int num)
        {
            var commands=new List<Command>();
            if(num>0){
                commands.Add(new Command
                {
                    Id=0,
                    HowTo="How to generate a migration",
                    CommandLine="dotnet ef migrations add <Name of Migration>",
                    Platform=".Net Core EF"
                });
            }
            return commands;
        }
        
    }
}