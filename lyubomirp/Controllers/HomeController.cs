using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lyubomirp.Models;

namespace lyubomirp.Controllers
{
    public class HomeController : Controller
    {
        private readonly identity.Data.ApplicationDbContext _context;

        public HomeController(identity.Data.ApplicationDbContext context)
        {
            _context = context;
            ProjectsAndIDEs projectsAndIDEs = new ProjectsAndIDEs();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ProjectsAndIDEs projectsAndIDEs = new ProjectsAndIDEs();
            projectsAndIDEs.Programs = _context.ProgramsList;
            projectsAndIDEs.Technologies = _context.Summary;
            return View(projectsAndIDEs);
        }

        public IActionResult Projects()
        {
            var projects = _context.Projects.ToList();

            return View(projects);
        }

        public IActionResult BrickBreak()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
