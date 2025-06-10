using Authentication.API.Models;

namespace Authentication.API.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ApiResponse> Login(LoginRequestModelDTO login)
        {
            try
            {
                if (login)
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
