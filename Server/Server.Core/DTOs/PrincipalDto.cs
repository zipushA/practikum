using MatchingAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.DTOs
{
    public class PrincipalDto
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string paswword { get; set; }
        public string email { get; set; }
        public string schoolName { get; set; }
        public string citySchool { get; set; }

        public MatchingData demand { get; set; }
    }
}
