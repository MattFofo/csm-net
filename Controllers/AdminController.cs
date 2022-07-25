using CSM_NET.Db_context;
using CSM_NET.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSM_NET.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        
        public ActionResult ComponentList()
        {
            string rootPath = @"Views\Page\Component";

            //TODO: gestire exeption mancanza dir
            List<string> dirs = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories).ToList();

            List<string> dirsNames = new List<string>();

            foreach (var item in dirs)
            {
                string name = new DirectoryInfo(item).Name;

                dirsNames.Add(name);
            }


            ViewData["dirs"] = dirsNames;
            
            return View();
        }

        public ActionResult InstallComponent(string name)
        {
            using (CMSContext ctx = new CMSContext())
            {
                ComponentDefinition componentDefinition = new ComponentDefinition(name);

                ctx.componentDefinitions.Add(componentDefinition);
                ctx.SaveChanges();

                return RedirectToAction("ComponentList");
            }
        }

        public ActionResult UninstallComponent(string name)
        {
            using (CMSContext ctx = new CMSContext())
            {
                ComponentDefinition componentDefinition = ctx.componentDefinitions.Find(name);

                if (componentDefinition == null) return NotFound();

                ctx.componentDefinitions.Remove(componentDefinition);
                ctx.SaveChanges();

                return RedirectToAction("ComponentList");
            }
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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


        public ActionResult Edit(int id)
        {
            return View();
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

        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
