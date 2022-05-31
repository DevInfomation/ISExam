using ISExam.Data;
using Moq;
using AutoMapper;
using ISExam.Models;
using ISExam.Service;
using ISExam.WebApi;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class UnitTest1 
    {
        PlayerInterface playerRepo;
        IMapper mapper;
        Mock<PlayerInterface> playerRepoMock = new Mock<PlayerInterface>();
        Player player;
        Club club;
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        List<Player> players = new List<Player>();
        
        private void SetupMock()
        {
            playerRepo = playerRepoMock.Object;
            mapper = mapperMock.Object;
        }

        private void SetupPlayer()
        {
            player = GetPlayer(); 
        }

        private static Player GetPlayer()
        {
            return new Player
            {
                Id = 4,
                FirstName = "Stefan",
                LastName = "Milkovski",
                Rank = 13,
                Club = "Dinamo"
            };
        }
    }
}
