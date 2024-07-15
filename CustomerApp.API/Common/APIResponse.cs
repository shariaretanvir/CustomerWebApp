namespace CustomerApp.API.Common
{
    public sealed class APIResponse<T>
    {
        public T? Data { get; set; }

        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public DateTime CreatedOn { get; set; }

        private APIResponse(int statusCode)
        {
            StatusCode = statusCode;
            CreatedOn = DateTime.Now;
        }

        private APIResponse(int statusCode, string message) : this(statusCode) => this.Message = message;

        private APIResponse(T data, int statusCode, string message) : this(statusCode, message) => Data = data;


        public static APIResponse<T> Success(int statusCode = 200)
        {
            return new APIResponse<T>(statusCode);
        }

        public static APIResponse<T> Success(string message, int statusCode = 200)
        {
            return new APIResponse<T>(statusCode, message);
        }

        public static APIResponse<T> Success(T data, string message = "", int statusCode = 200)
        {
            return new APIResponse<T>(data, statusCode, message);
        }


        public static APIResponse<T> Error(int statusCode = 500)
        {
            return new APIResponse<T>(statusCode);
        }

        public static APIResponse<T> Error(string message, int statusCode = 500)
        {
            return new APIResponse<T>(statusCode, message);
        }

        public static APIResponse<T> Error(T data, string message = "", int statusCode = 500)
        {
            return new APIResponse<T>(data, statusCode, message);
        }
    }
}
