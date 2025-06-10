using Authentication.API.Data;
using Authentication.API.Models;

namespace Authentication.API.Services
{
    public class UserAccountService
    {
        private readonly DatabaseConnection _databaseConnection;

        public UserAccountService(DatabaseConnection databaseConnection)
        {
            this._databaseConnection = databaseConnection;
        }

        public async Task<ApiResponse> UserRegister(RegisterRequestModel userRegister)
        {
            try
            {
                // A classe já valida com required, porém uma dupla checagem por segurança.
                if (string.IsNullOrWhiteSpace(userRegister.Nome) || string.IsNullOrWhiteSpace(userRegister.Email) || string.IsNullOrWhiteSpace(userRegister.Senha))
                {
                    return new ApiResponse
                    {
                        Sucess = false,
                        Errors = "Todos os campos são obrigatórios!"
                    };
                }

                var verifyUser = await _databaseConnection.GetDataTable("SELECT TOP 1 * FROM Users WHERE email = @email".ToString(), new Dictionary<string, object>
                {
                    { "@email", userRegister.Email }
                });

                if (verifyUser.Rows.Count != 0)
                {
                    return new ApiResponse
                    {
                        Sucess = false,
                        Errors = "Já existe um usuário cadastrado com este e-mail!"
                    };
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
