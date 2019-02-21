using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Forms;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            ViewBag.Header = "Lista de Clientes";
            return View();
        }

        public ActionResult List()
        {
            using (var context = new SalesEntities())
            {
                var Clients = context.Clients.ToList();
                return PartialView("List.Partial", Clients);
            }
        }

        public ActionResult Save()
        {
            return PartialView("Save.Partial", new ClientsViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClientsViewModel form)
        {
            System.Threading.Thread.Sleep(2500);

            if (!ModelState.IsValid)
            {
                form.Email = string.Empty;
                return PartialView("Save.Partial", form);
            }

            using (var context = new SalesEntities())
            {
                //Clients entity = form.toClients();
                Clients entity = new Clients(form);
                //entity.Active = true;
                context.Clients.Add(entity);
                context.SaveChanges();
            }

            // JGCC
            return Redirect("Index");
            // return PartialView("Save.Partial", new ClientsViewModel());
        }
    }
}