using DAL.DTOs;
using Domain.Entities;
using DAL.Interfaces;

namespace api.Extensions;

public static class AppUserExtensions
{
    public static async Task<UserDto> ToDto(this User user, ITokenService tokenService)
    {
        return new UserDto
        {
            Id = user.Id,
            DisplayName = user.DisplayName,
            Email = user.Email!,
            Photo = user.Photo,
            Token = await tokenService.CreateToken(user)
        };
    }
}
