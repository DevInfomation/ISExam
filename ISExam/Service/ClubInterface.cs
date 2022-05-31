using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISExam.Models;

namespace ISExam.Service
{
    interface ClubInterface
    {
        IEnumerable<Club> GetClub();
        Task<Club> GetClubById(int id);
        Club AddClub(Club player);
        Club UpdateClub(Club player);
        Task<bool> DeleteClub(int id);
    }
}
