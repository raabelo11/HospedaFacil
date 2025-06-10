namespace Authentication.API.Models
{
    public class ApiResponse
    {
        public bool Sucess { get; set; }
        public object? Data { get; set; }
        public string? Errors { get; set; }
    }
}
