namespace CollegeAPIs.Models.DTO
{
    public class UpdateTokenRequestDto
    {
        public int employeeid { get; set; } = 0;
        public string token { get; set; } = string.Empty;
    }

    public class UpdateTokenResponseDto
    {

        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;
    }
}
