using MatchingAPI.Core.Models;

namespace Server.Api.PostModels
{
    public class PrincipalPostModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int MatchingDataId { get; set; }

        //public MatchingDataPostModel demand { get; set; }
    }
}
