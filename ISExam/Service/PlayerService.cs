using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ISExam.Models;
using ISExam.Data;
using ISExam.Service;
using Microsoft.EntityFrameworkCore;

namespace ISExam.Service
{
    public class PlayerService : PlayerInterface
    {
        private readonly PlayerContext _playerContext;
        private readonly IMapper _mapper;

        public PlayerService(PlayerContext playerContext, IMapper mapper)
        {
            _playerContext = playerContext;
            _mapper = mapper;
        }

        public Player AddPlayer(Player player)
        {
            //return await _playerContext.Players.ToListAsync();
            Player newPlayer = _mapper.Map<Player>(player);

            if (_playerContext.Players.FirstOrDefault(p => p.Id == player.Id) == null)
            {
                _playerContext.Players.Add(newPlayer);
                _playerContext.SaveChanges();
            }

            return _mapper.Map<Player>(newPlayer);
        }

        public async Task<bool> DeletePlayer(int id)
        {
            var playerEntity = await _playerContext.Players.FindAsync(id);

            _playerContext.Players.Remove(playerEntity);
            return await SaveAsync() > 0;

        }

        public async Task<int> SaveAsync()
        {
            return await _playerContext.SaveChangesAsync();
        }
        public async Task<Player> GetPlayerById(int id)
        {
            var player = await _playerContext.Players.Include(p => p.Club).FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Player>(player);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _playerContext.Players.Select(x => new Player
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DOB = x.DOB,
                SigningDate = x.SigningDate,
                Rank = x.Rank,
                TotalGoals = x.TotalGoals,
                Club = x.Club
            }).ToList();
        }

        public Player UpdatePlayer(Player player)
        {
            Player newPlayer = _mapper.Map<Player>(player);
            Player oldPlayer = _playerContext.Players.FirstOrDefault(p => p.Id == newPlayer.Id);

            if (oldPlayer != null)
            {
                _playerContext.Entry(oldPlayer).CurrentValues.SetValues(newPlayer);
                _playerContext.SaveChanges();
            }

            return _mapper.Map<Player>(newPlayer);
        }
    }
}
