using API.Helpers;

namespace api.Helpers
{
    public class ClubParams : PaginationParams
    {
        public string state { get; set; }
        public string city { get; set; }
    }
}