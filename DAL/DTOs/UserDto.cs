namespace DAL.DTOs;

public class UserDto
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string DisplayName { get; set; }
    public byte[]? Photo { get; set; }
    public required string Token { get; set; }
}
