using CSM_NET.Db_context;
using CSM_NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSM_NET.Controllers
{
    public class ComponentController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Select(int Id)
        {

            using(CMSContext ctx = new CMSContext())
            {
                List<ComponentDefinition> componentDefinitionsList = ctx.componentDefinitions.ToList();


                ViewData["pageId"] = Id;

                return View(componentDefinitionsList);
            }

        }

        public ActionResult AddComponent(int pageId, string name)
        {
            using (CMSContext ctx = new CMSContext())
            {
                Page page = ctx.pages.Find(pageId);
                if (page == null) return NotFound();

                ComponentDefinition componentDefinition = ctx.componentDefinitions.Find(name);
                if (componentDefinition == null) return NotFound();

                Component component = new Component()
                {
                    ComponentDefinition = componentDefinition,
                    ComponentDefinitionKey = name,
                    PageId = pageId
                };


                page.Components.Add(component); //errore??


                return RedirectToAction("Select");
            }
        }


        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string key, int pageId)
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

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
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
