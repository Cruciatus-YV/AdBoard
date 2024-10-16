using System.Security.Claims;

namespace AdBoard.Infrastructure.Extentions;

public static class ClaimsPrincipalExtention
{
    /// <summary>
    /// Получает значение клейма по указанному типу клейма.
    /// </summary>
    /// <param name="user">Пользователь, для которого извлекаются клеймы.</param>
    /// <param name="claimType">Тип клейма.</param>
    /// <returns>Значение клейма или пустую строку, если клеймо не найдено.</returns>
    public static string GetClaimValue(this ClaimsPrincipal user, string claimType)
    {
        return user.FindFirst(claimType)?.Value ?? string.Empty;
    }

    /// <summary>
    /// Получает идентификатор пользователя из клеймов.
    /// </summary>
    /// <param name="user">Пользователь, для которого извлекается идентификатор.</param>
    /// <returns>Идентификатор пользователя.</returns>
    public static string GetUserId(this ClaimsPrincipal user)
    {
        return user.GetClaimValue(ClaimTypes.NameIdentifier);
    }

    /// <summary>
    /// Получает электронную почту пользователя из клеймов.
    /// </summary>
    /// <param name="user">Пользователь, для которого извлекается электронная почта.</param>
    /// <returns>Электронная почта пользователя.</returns>
    public static string GetUserEmail(this ClaimsPrincipal user)
    {
        return user.GetClaimValue(ClaimTypes.Email);
    }

    /// <summary>
    /// Получает роль пользователя из клеймов.
    /// </summary>
    /// <param name="user">Пользователь, для которого извлекается роль.</param>
    /// <returns>Роль пользователя.</returns>
    public static string GetUserRole(this ClaimsPrincipal user)
    {
        return user.GetClaimValue(ClaimTypes.Role);
    }

    /// <summary>
    /// Получает дату рождения пользователя из клеймов.
    /// </summary>
    /// <param name="user">Пользователь, для которого извлекается дата рождения.</param>
    /// <returns>Дата рождения пользователя.</returns>
    public static DateOnly GetUserDateOfBirth(this ClaimsPrincipal user)
    {
        return DateOnly.Parse(user.GetClaimValue(ClaimTypes.DateOfBirth));
    }
}
