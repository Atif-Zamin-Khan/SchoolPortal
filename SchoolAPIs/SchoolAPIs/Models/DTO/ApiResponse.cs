namespace CollegeAPIs.Models.DTO
{
    public class ApiResponse
    {
        public string ResponseCode { get; set; } = "00";
        public string ResponseDescription { get; set; } = "Success";
        public string traceId { get; set; } = string.Empty;
        public string? body { get; set; }
    }

    public class ApiResponse<T> where T : class
    {
        public string responseCode { get; set; } = "00";
        public string responseMessage { get; set; } = "Success";
        public string traceId { get; set; } = string.Empty;
        public T? body { get; set; }
    }
}
