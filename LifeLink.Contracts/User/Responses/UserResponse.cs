namespace LifeLink.Contracts.User.Responses;

public record UserResponse (
    Guid Id,
    Guid CreatorId,
    DateTime CreateTime,
    Guid ModifierId, 
    DateTime ModifyTime,
    string Username,
    string Email,
    bool IsEmailVerified,
    string? Phone,
    bool IsPhoneVerified,
    string Name,
    DateTime? BirthDate,
    List<Guid> Roles
);