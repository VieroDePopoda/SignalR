using System;
using Microsoft.AspNetCore.Mvc;
using FootballCatalog.Interfaces;
using FootballCatalog.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace FootballCatalog.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPlayerRepository playerRepository;
        private readonly ITeamRepository teamRepository;

        public HomeController(IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            this.playerRepository = playerRepository;
            this.teamRepository = teamRepository;
        }
        
        [HttpGet]
        public IActionResult GetPlayers()
        {
            return Ok(playerRepository.GetPlayers());
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            return Ok(teamRepository.GetTeams());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
