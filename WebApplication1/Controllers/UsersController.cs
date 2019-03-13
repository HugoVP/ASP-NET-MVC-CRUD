using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Forms;
using WebApplication1.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {        
        // GET: Users
        public ActionResult Index(int id = 0)
        {
            ViewBag.Header = "Lista de Clientes";

            if (TempData.ContainsKey("Success"))
            {
                TempData.Remove("Success");
                ViewBag.Success = true;                
            }

            ClientsViewModel clientsViewModel = null;

            if (id != 0)
            {
                using(var context = new SalesEntities())
                {
                    var resultClient = context.Clients.SingleOrDefault(e => e.Id == id);
                    clientsViewModel = new ClientsViewModel(resultClient);
                }
            }
            else
            {
                clientsViewModel = new ClientsViewModel();
            }

            return View(clientsViewModel);
        }

        public ActionResult List()
        {
            using (var context = new SalesEntities())
            {
                var Clients = context.Clients.ToList();
                return PartialView("List.Partial", Clients);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClientsViewModel form)
        {
            System.Threading.Thread.Sleep(2500);

            if (!ModelState.IsValid)
            {
                return View(nameof(Index), form);
            }

            using (var context = new SalesEntities())
            {
                if(form.Id != 0)
                {
                    var clientToUpdate = context.Clients.SingleOrDefault(e => e.Id == form.Id);
                    clientToUpdate.Email = form.Email;
                    clientToUpdate.FirstName = form.FirstName;
                    clientToUpdate.LastName = form.LastName;
                    clientToUpdate.Discount = form.Discount;
                }
                else
                {
                    Clients entity = new Clients(form);
                    context.Clients.Add(entity);
                }
                
                context.SaveChanges();
            }

            TempData["Success"] = true;
            return Redirect(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            using (var context = new SalesEntities())
            {
                var clientDelete = await context.Clients.SingleOrDefaultAsync(e => e.Id == id);
                context.Clients.Remove(clientDelete);
                await context.SaveChangesAsync();
            }

            return Redirect(nameof(Index));
        }
    }
}