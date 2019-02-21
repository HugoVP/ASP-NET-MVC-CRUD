using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Forms;

namespace WebApplication1.Models
{
    public partial class Clients
    {
        public Clients()
        {

        }

        public Clients(ClientsViewModel form)
        {
            this.Id = form.Id;
            this.FirstName = form.FirstName;
            this.LastName = form.LastName;
            this.Email = form.Email;
            this.Discount = form.Discount;
        }

        public bool Active { set; get;  }
    }
}