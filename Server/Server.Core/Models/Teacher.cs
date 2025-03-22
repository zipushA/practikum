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
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Link { get; set; }
        public int MatchingDataId { get; set; }
        public MatchingData Data { get; set; }
        public Teacher()
        {
            
        }

        public Teacher(Teacher t)
        {
            
            Name = t.Name;
            Email = t.Email;
            Link = t.Link;
            MatchingDataId = t.MatchingDataId;
            //MatchingData = t.MatchingData;
        }
        public Teacher(int id_from_body, Teacher t)
        {
            Id = id_from_body;
            Name = t.Name;
            Email = t.Email;
            MatchingDataId = t.MatchingDataId;
            //MatchingData = t.MatchingData;
        }

    }
}
