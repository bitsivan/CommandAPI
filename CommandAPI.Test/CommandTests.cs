using System;
using CommandAPI.Data.Models;
using Xunit;

namespace CommandAPI.Test
{
    public class CommandTests: IDisposable
    {
        Command testCommand;
        public CommandTests()
        {
            testCommand=new Command
            {
                HowTo="Do something",
                Platform="Some platform",
                CommandLine="Some commandline"
            };

        }

        [Fact]
        public void CanChangeHowTo()
        {
            //Arrange
            // var testCommand=new Command
            // {
            //     HowTo="Do something awesome",
            //     Platform="xUnit",
            //     CommandLine="dotnet test"
            // };

            //Act
            testCommand.HowTo="Execute unit tests";

            //assert
            Assert.Equal("Execute unit tests", testCommand.HowTo);
        }

        [Fact]
        public void CanChangePlatform_Test()
        {
            //Act
            testCommand.Platform="xUnit";
            //Assert
            Assert.Equal("xUnit", testCommand.Platform);
        }

        [Fact]
        public void CanChangeCommandLine()
        {
            //Act
            testCommand.CommandLine="dotnet test";
            //Assert
            Assert.Equal("dotnet test",testCommand.CommandLine);
        }

        public void Dispose()
        {
            testCommand=null;
        }
    }
}   