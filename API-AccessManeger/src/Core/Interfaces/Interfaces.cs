using API_AccessManeger.src.Application.DTOs.User.Create;

namespace API_AccessManeger;

public interface IUserRepository
{
    public Task<CreateUserResponse> CreateUser(CreateUserRequest request);
    public Task<ReadUsersResponse> ReadUser(ReadUsersRequest request);
    public Task<bool> VerifyEmailExists(string email);
    public Task<bool> VerifyExistsUser(Guid id);
    public Task<UpdateUserResponse> UpdateUser(Guid id, UpdateUserRequest request);
    public Task<bool> DeleteUser(Guid id);
    public Task<User?> GetUserDataByEmail(string email);
    public Task<List<User>> ReadUserADM();
    public Task<UpdateUserResponse> UpdateUserADM(Guid id, UpdateUserRequest request);
    public Task<bool> DeleteUsersADM(Guid id);
}

public interface ITokenService
{
    string GenerateToken(User user);
}

public interface IHashesService
{
    public string HashPassword(User user, string password);
    public bool VerifyPassword(User user, string password, string hashedPassword);
}