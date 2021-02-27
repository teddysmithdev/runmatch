using API.Helpers;

namespace api.Helpers
{
    public class ClubParams : PaginationParams
    {
        public string State { get; set; }
        public string City { get; set; }
    }
}