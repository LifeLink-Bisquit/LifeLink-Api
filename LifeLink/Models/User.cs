using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Helpers;
using LifeLink.Models.BaseModels;
using LifeLink.ServiceErrors;
using Microsoft.IdentityModel.Tokens;

namespace LifeLink.Models;

public class User (
        Guid id,
        string email,
        bool isEmailVerified,
        string? phone,
        bool isPhoneVerified,
        string name,
        DateTime? birthDate,
        List<Guid> roles,
        string password
    ) : BaseModel (id, Guid.Empty)
{
    public string Email { get; set; } = email; 
    public bool IsEmailVerified { get; set; } = isEmailVerified;
    public string? Phone { get; set; } = phone;
    public bool IsPhoneVerified { get; set; } = isPhoneVerified;
    public string Name { get; set; } = name;
    public DateTime? BirthDate { get; set; } = birthDate;
    public List<Guid> Roles { get; set; } = roles;
    public string Password { get; set; } = password;

    private static ErrorOr<User> Create(        
        string email,
        bool isEmailVerified,
        string? phone,
        bool isPhoneVerified,
        string name,
        DateTime? birthDate,
        List<Guid> roles,
        string password,
        Guid? id = null)
    {
        List<Error> errors = [];

        if(!Helper.IsEmailValid(email)){
            errors.Add(Errors.User.InvalidEmail);
        }         

        if(name.Length < Constants.MinNameLength || name.Length > Constants.MaxNameLength){
            errors.Add(Errors.User.InvalidNameLength);
        }  

        if(!string.IsNullOrEmpty(phone) && !Helper.IsPhoneNumberValid(phone)){
            errors.Add(Errors.User.InvalidPhoneNumber);
        }

        if(password.Length < Constants.MinPasswordLength){
            errors.Add(Errors.User.InvalidPasswordLength);
        }

        if(roles.IsNullOrEmpty())
        {
            errors.Add(Errors.User.RoleNotProvided);
        }

        if(errors.Count > 0){
            return errors;
        }

        return new User (
            id ?? Guid.NewGuid(),
            email,
            isEmailVerified,
            phone,
            isPhoneVerified,
            name,
            birthDate,
            roles,
            password
        );
    }

    public static ErrorOr<User> From(SignupUserRequest request)
    {
        return Create(
            request.Email,
            false,
            request.Phone,
            false,
            request.Name,
            request.BirthDate,
            request.Roles,
            request.Password
        );
    }
}