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


        public ActionResult Select(int pageId)
        {
            string rootPath = @"Views\Page\Component";

            //TODO: gestire exeption mancanza dir
            List<string> dirs = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories).ToList();

            List<string> dirsNames = new List<string>();

            List<ComponentDefinition> componentDefinitionsList = new List<ComponentDefinition>(); //TODO: prima aggiungere ComponentDefinition al DB nel admincontroller e poi prendere la lista dal db

            //new COmponentdefinition??? 

            foreach (var item in dirs)
            {
                string name = new DirectoryInfo(item).Name;

                ComponentDefinition componentDefinition = new ComponentDefinition(name);

                componentDefinitionsList.Add(componentDefinition);

                dirsNames.Add(name);
            }

            ViewData["pageId"] = pageId;
            ViewData["componentDefinitionsList"] = componentDefinitionsList;

            return View();
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
