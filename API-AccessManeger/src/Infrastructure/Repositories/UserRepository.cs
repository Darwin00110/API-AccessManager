using System.Runtime.CompilerServices;
using System.Xml.Linq;
using API_AccessManeger.src.Application.DTOs.User.Create;
using API_AccessManeger.src.Application.Exceptions.NotFound;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API_AccessManeger;

public class UserRepository : IUserRepository
{
    private readonly PasswordHasher<User> _passwordHasher = new();
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
    {
        var user_id = Guid.NewGuid();
        var users = new User()
        {
            ID = user_id,
            Email = request.Email,
            Name = request.Name,
            Password = request.Password,
            Telephone = request.Telephone,
            Role = request.Role
        };
        await _context.Users.AddAsync(users);
        await _context.SaveChangesAsync();

        return new CreateUserResponse
        {
            Email = request.Email,
            Name = request.Name,
            User_id = user_id,
        };
    }
    public async Task<bool> VerifyEmailExists(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserDataByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> VerifyExistsUser(Guid id)
    {
        return await _context.Users.AnyAsync(u => u.ID == id);
    }

    public async Task<ReadUsersResponse> ReadUser(ReadUsersRequest request)
    {
        var result = await _context.Users.FindAsync(request.ID_user);
        if (result == null)
        {
            return null;
        }
        return new ReadUsersResponse
        {
            Email = result.Email,
            Name = result.Name,
            Password = result.Password,
            Telephone = result.Telephone,
            Role = result.Role
        };
    }

    public async Task<UpdateUserResponse> UpdateUser(Guid id, UpdateUserRequest request)
    {
        var user = new User()
        {
            ID = id,
            Email = request.Email,
            Password = request.Password
        };
        var result_sql = await _context.Users.FindAsync(user.ID);
        if (result_sql == null)
        {
            return null;
        }
        result_sql.Name = request.Name;
        result_sql.Email = request.Email;
        result_sql.Password = request.Password;
        result_sql.Telephone = request.Telephone;
       
        await _context.SaveChangesAsync();
        var response = new UpdateUserResponse
        {
            Email = result_sql.Email,
            Name = result_sql.Name,
            Telephone = result_sql.Telephone,
            Userid = result_sql.ID
        };
        return response;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<User>> ReadUserADM()
    {
        return await _context.Users.ToListAsync(); 
    }
    public async Task<UpdateUserResponse> UpdateUserADM(Guid id, UpdateUserRequest request)
    {
        var query = await _context.Users.FindAsync(id);
        if (query == null)
        {
            throw new User_NotFoundException();
        }
        query.Email = request.Email;
        query.Name = request.Name;
        query.Password = request.Password;
        query.Telephone = request.Telephone;
        query.Role = request.Role;
        await _context.SaveChangesAsync();
        return new UpdateUserResponse {
            Email = query.Email,
            Name = query.Name,
            Telephone = query.Telephone,
            Userid = query.ID
        };
    }

    public async Task<bool> DeleteUsersADM(Guid id)
    {
        var Users = await _context.Users.FindAsync(id);
        if (Users == null)
        {
            return false;
        }
        _context.Users.Remove(Users);
        await _context.SaveChangesAsync();
        return true;
    }
}