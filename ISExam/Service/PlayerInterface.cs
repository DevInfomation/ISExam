using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ISExam.Models;
using ISExam.Data;
using ISExam.Service;

namespace ISExam.Service
{
    public interface PlayerInterface
    {
        IEnumerable<Player> GetPlayers();
        Task<Player> GetPlayerById(int id);
        Player AddPlayer(Player player);
        Player UpdatePlayer(Player player);
        Task<bool> DeletePlayer(int id);
    }
}
