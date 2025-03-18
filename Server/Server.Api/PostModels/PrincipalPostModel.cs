using MatchingAPI.Core.Models;

namespace Server.Api.PostModels
{
    public class PrincipalPostModel
    {
        public string name { get; set; }
        public string paswword { get; set; }
        public string email { get; set; }
        public string schoolName { get; set; }
        public string citySchool { get; set; }
        public int MatchingDataId { get; set; }

        //public MatchingDataPostModel demand { get; set; }
    }
}
