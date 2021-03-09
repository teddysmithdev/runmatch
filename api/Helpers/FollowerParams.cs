using API.Helpers;

namespace api.Helpers
{
    public class FollowerParams : PaginationParams
    {
        public int UserId { get; set; }
        public string Predicate { get; set; }
    }
}