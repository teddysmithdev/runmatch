namespace API.Helpers
{
    public class InviteParams : PaginationParams
    {
        public int UserId { get; set; }
        public string Predicate { get; set; }
    }
}