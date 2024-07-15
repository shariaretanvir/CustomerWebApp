namespace CustomerApp.UI.Models
{
    public class APIResponse<T>
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public T? data { get; set; }
        public DateTimeOffset createdOn { get; set; }
    }
}
