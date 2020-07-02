using System;
using FootballCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using FootballCatalog.Interfaces;

namespace FootballCatalog.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IHubContext<SignalServer> context;
        private readonly ITeamRepository teamRepository;

        public PlayersController(IPlayerRepository playerRepository, IHubContext<SignalServer> context, ITeamRepository teamRepository)
        {
            this.playerRepository = playerRepository;
            this.context = context;
            this.teamRepository = teamRepository;
        }

        public IActionResult Index()
        {
            return View(playerRepository.GetPlayers());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = playerRepository.GetTeams();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Player player)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teams = playerRepository.GetTeams();
                return View(player);
            }

            playerRepository.Add(player);
            playerRepository.SaveChanges();
            context.Clients.All.SendAsync("refreshPlayers");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (id != null)
            {
                ViewBag.Teams = playerRepository.GetTeams();
                var player = playerRepository.Find(id);
                return View(player);
            }

            return NotFound();
            
        }

        [HttpPost]
        public IActionResult Edit(Player model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teams = playerRepository.GetTeams();
                return View(model);
            }

            playerRepository.Update(model);
            playerRepository.SaveChanges();

            context.Clients.All.SendAsync("refreshPlayers");
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var player = playerRepository.Find(id);
            playerRepository.Delete(player);
            playerRepository.SaveChanges();
            context.Clients.All.SendAsync("refreshPlayers");
            return RedirectToAction("index", "Home");
        }

        [HttpPost]
        public JsonResult AddTeam(string team)
        {
            teamRepository.Add(new Team { IsDelete = false, Name = team });
            teamRepository.SaveChanges();
            context.Clients.All.SendAsync("refreshOpts");
            return Json(team);
        }

    }
}
