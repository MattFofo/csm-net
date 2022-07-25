using CSM_NET.Db_context;
using CSM_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CSM_NET.Controllers
{
    public class PageController : Controller
    {
        private readonly ILogger<PageController> _logger;

        public PageController(ILogger<PageController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using(CMSContext ctx = new CMSContext())
            {
                List<Page> pages = ctx.pages.ToList();

                return View(pages);
            }
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Page page)
        {
            if (!ModelState.IsValid)
            {
                return View(page);
            }
            
            using(CMSContext ctx = new CMSContext())
            {
                ctx.pages.Add(page);
                ctx.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
           
        }


        public ActionResult Edit(int id)
        {
            using(CMSContext ctx = new CMSContext())
            {
                Page page = ctx.pages.Where(p => p.Id == id).Include(page => page.Components).FirstOrDefault();

                if (page == null) return NotFound();

                return View(page);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}