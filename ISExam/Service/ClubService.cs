using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ISExam.Models;
using ISExam.Data;
using ISExam.Service;

namespace ISExam.Service
{
    public class ClubService : ClubInterface
    {
        private readonly ClubContext _clubContext;
        private readonly IMapper _mapper;

        public ClubService(ClubContext clubContext, IMapper mapper)
        {
            _clubContext = clubContext;
            _mapper = mapper;
        }

        public Club AddClub(Club club)
        {
            Club newClub = _mapper.Map<Club>(club);

            if (_clubContext.Clubs.FirstOrDefault(c => c.Id == club.Id) == null)
            {
                _clubContext.Clubs.Add(newClub);
                _clubContext.SaveChanges();
            }

            return _mapper.Map<Club>(newClub);
        }

        public async Task<bool> DeleteClub(int id)
        {
            var clubEntity = await _clubContext.Clubs.FindAsync(id);

            _clubContext.Clubs.Remove(clubEntity);
            return await SaveAsync() > 0;
        }

        public async Task<int> SaveAsync()
        {
            return await _clubContext.SaveChangesAsync();
        }

        public IEnumerable<Club> GetClub()
        {
            return _clubContext.Clubs.Select(x => new Club
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                Country = x.Country
            });
        }

        public async Task<Club> GetClubById(int id)
        {
            var clubs = await _clubContext.Clubs.Include(c => c.City).FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Club>(clubs);
        }

        public Club UpdateClub(Club club)
        {
            Club newClub = _mapper.Map<Club>(club);
            Club oldClub = _clubContext.Clubs.FirstOrDefault(c => c.Id == newClub.Id);

            if (oldClub != null)
            {
                _clubContext.Entry(oldClub).CurrentValues.SetValues(newClub);
                _clubContext.SaveChanges();
            }

            return _mapper.Map<Club>(newClub);
        }
    }
}
