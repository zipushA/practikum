using MatchingAPI.Core.Models;

namespace Server.Api.PostModels
{
    public class TeacherPostModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string link { get; set; }
        public int MatchingDataId { get; set; }
        // public MatchingDataPostModel data { get; set; }
    }
}
