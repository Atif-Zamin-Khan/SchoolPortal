namespace CollegeAPIs.Models.DBO
{
    public class UpdateTokenEmployeeRequestDbo
    {
        public int employeeId { get; set; } = 0;
        public string token { get; set; } = string.Empty;   
    }

    public class UpdateTokenEmployeeResponseDbo
    {
        public string ResponseCode { get; set; } = string.Empty ;
        public string ResponseDescription {  get; set; } = string.Empty ;
    }


    public class UpdateTokenStudenRequestDbo
    {
        public int StudentId { get; set; } = 0;
        public string token { get; set; } = string.Empty;
    }

    public class UpdateTokenStudenResponseDbo
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseDescription { get; set; } = string.Empty;
    }

}

