using API_AccessManeger.src.Application.DTOs.User.Create;
using API_AccessManeger.src.Application.Exceptions;
using API_AccessManeger.src.Application.Exceptions.EmptyExceptions;
using API_AccessManeger.src.Application.Exceptions.InvalidRequests;

namespace API_AccessManeger;

public class RegisterUserUseCase {
    private readonly IUserRepository _repo;
    private readonly ITokenService _tokenService;
    private readonly IHashesService _hashesService;
    public RegisterUserUseCase(IUserRepository repo, IHashesService hashesService, ITokenService tokenService)
    {
        _repo = repo;
        _tokenService = tokenService;
        _hashesService = hashesService;
    }

    public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
    {
        var verify = await _repo.VerifyEmailExists(request.Email);
        if (verify)
        {
            throw new UserExistsException();
        }
        var Data = new User() {
           Name = request.Name, 
           Email = request.Email, 
           Password =request.Password, 
           Telephone = request.Telephone, 
           Role = request.Role
        };
        Data.ValidateUser(request.Name, request.Email, request.Password, request.Telephone, request.Role);
        var hashPassword = _hashesService.HashPassword(Data, request.Password);
        request.Password = hashPassword;
        Console.WriteLine($"O valor do treco ai arrombado {request.Role}");
        return await _repo.CreateUser(request);
    }
    public async Task<ReadUsersResponse> ReadUser(ReadUsersRequest request)
    {
        var verify = await _repo.VerifyExistsUser(request.ID_user);
        if (!verify)
        {
            throw new UserNotFoundException();
        }
        return await _repo.ReadUser(request);
    }
    public async Task<UpdateUserResponse> UpdateUser(Guid id, UpdateUserRequest request)
    {
        var verify = await _repo.VerifyExistsUser(id);
        if (verify != true)
        {
            throw new UserNotFoundException();
        }
        var Data = new User() {
          Name =  request.Name, 
          Email =  request.Email, 
          Password =  request.Password, 
          Telephone =  request.Telephone, 
          Role =  request.Role
        };
        Data.ValidateUser(request.Name, request.Email, request.Password, request.Telephone, request.Role);
        var hashPassword = _hashesService.HashPassword(Data, Data.Password);
        request.Password = hashPassword;
        return await _repo.UpdateUser(id, request);
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var verify = await _repo.VerifyExistsUser(id);
        if (!verify)
        {
            throw new UserNotFoundException();
        }
        var result = await _repo.DeleteUser(id);
        if (!result)
        {
            throw new UserNotFoundException();
        }
        return result;
    }

    public async Task<LoginUserResponse> LoginUser (LoginUserRequest request)
    {
        var verify = await _repo.VerifyEmailExists(request.Email);
        if (!verify)
        {
            throw new Email_NotFoundException();
        }
        var Data = new User() {};
        Data.ValidateUserLogin(request.Email, request.Password);

        var resultEmail = await _repo.GetUserDataByEmail(request.Email);
        if (resultEmail == null)
        {
            throw new Email_NotFoundException();
        }
        var verifyPassword = _hashesService.VerifyPassword(resultEmail, request.Password, resultEmail.Password);
        if (!verifyPassword)
        {
            throw new InvalidPasswordException();
        }
        var resultToken = _tokenService.GenerateToken(resultEmail);
        return new LoginUserResponse
        {
            token = resultToken
        };
    }

    public async Task<List<User>> ReadUserADM()
    {
        return await _repo.ReadUserADM();
    }

    public async Task<UpdateUserResponse> UpdateUserADM(Guid id, UpdateUserRequest request)
    {
        var verify = await _repo.VerifyExistsUser(id);
        if (verify != true)
        {
            throw new UserNotFoundException();
        }
        var Data = new User() { };
        Data.ValidateUser(request.Name, request.Email, request.Password, request.Telephone, request.Role);
        var hashPassword = _hashesService.HashPassword(Data, request.Password);
        Console.WriteLine($"valor aqui {hashPassword}");
        request.Password = hashPassword;
        var result = await _repo.UpdateUserADM(id, request);
        return result;
    }

    public async Task<bool> DeleteUsersADM(Guid id)
    {
        var verify = await _repo.VerifyExistsUser(id);
        if (!verify)
        {
            throw new UserNotFoundException();
        }
        var result = await _repo.DeleteUsersADM(id);
        return result;
    }
}