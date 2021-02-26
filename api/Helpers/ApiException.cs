namespace api.Helpers
{
    public class ApiException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}