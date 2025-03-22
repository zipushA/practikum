using MatchingAPI.Core.Models;
using Server.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Models
{
   public class Principal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int MatchingDataId { get; set; }

        public MatchingData demand { get; set; }
        public Principal()
        {
            
        }

        public Principal(Principal p)
        {
            
            Name = p.Name;
            Password = p.Password;
            Email = p.Email;
            //demand = p.demand;

        }
        public Principal(int id_from_body, Principal p)
        {
            Id = id_from_body;
            Name = p.Name;
            Password = p.Password;
            Email = p.Email;
            //demand = p.demand;
        }

    }
}
