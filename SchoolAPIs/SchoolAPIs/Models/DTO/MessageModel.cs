namespace CollegeAPIs.Models.DTO
{
    public class ResponseModel
    {
        public bool success { get; set; }
        public string message { get; set; } = string.Empty;

        public object? data { get; set; } = null;
    }
}
