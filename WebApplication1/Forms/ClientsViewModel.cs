using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Forms
{
    public class ClientsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obligatorio")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int Discount { get; set; }

        public Clients toClients()
        {
            return new Clients()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Discount = this.Discount
            };
        }

        public ClientsViewModel()
        {

        }

        public ClientsViewModel(Clients client)
        {
            Id = client.Id;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Email = client.Email;
            Discount = client.Discount ?? 0;
        }
    }
}