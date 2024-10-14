namespace AdBoard.Contracts.Models.Entities.User;

public class UserContextLight(string id, string email, string role, DateOnly dateOfBirth)
{
    public string Id { get; } = id;

    public string Email { get; } = email;

    public string Role { get; } = role;

    public DateOnly DateOfBirth { get; } = dateOfBirth;

    public bool IsUser => Role == "User";

    public bool IsSuperManager => Role == "SuperManager";

    public bool IsSuperAdmin => Role == "SuperAdmin";
}
