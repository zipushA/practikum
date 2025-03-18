using MatchingAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Models
{
    public class Teacher
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string link { get; set; }
        public int MatchingDataId { get; set; }
        public MatchingData data { get; set; }
        public Teacher()
        {
            
        }

        public Teacher(Teacher t)
        {
            
            name = t.name;
            email = t.email;
            link = t.link;
            MatchingDataId = t.MatchingDataId;
            //MatchingData = t.MatchingData;
        }
        public Teacher(int id_from_body, Teacher t)
        {
            id = id_from_body;
            name = t.name;
            email = t.email;
            MatchingDataId = t.MatchingDataId;
            //MatchingData = t.MatchingData;
        }

    }
}
