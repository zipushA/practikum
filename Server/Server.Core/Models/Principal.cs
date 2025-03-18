using MatchingAPI.Core.Models;
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
        public int id { get; set; }    
        public string name { get; set; }
        public string paswword { get; set; }
        public string email { get; set; }
        public string schoolName { get; set; }
        public string citySchool { get; set; }

        public MatchingData demand { get; set; }
        public Principal()
        {
            
        }

        public Principal(Principal p)
        {
            
            name = p.name;
            paswword = p.paswword;
            email = p.email;
            schoolName = p.schoolName;
            citySchool = p.citySchool;
            demand = p.demand;

        }
        public Principal(int id_from_body, Principal p)
        {
            id = id_from_body;
            name = p.name;
            paswword = p.paswword;
            email = p.email;
            schoolName = p.schoolName;
            citySchool = p.citySchool;
            demand = p.demand;
        }

    }
}
