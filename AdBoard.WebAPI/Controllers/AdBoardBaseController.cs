using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Infrastructure.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers;

public abstract class AdBoardBaseController : ControllerBase
{
    protected UserContextLightDto GetUserContextLigth()
    {
        if (!User.Identity.IsAuthenticated)
        {
            throw new NotFoundException("Такой пользователь не существует"); //TODO поменять ошибку на 402
        }

        var id = User.GetUserId();
        var email = User.GetUserEmail();
        var role = User.GetUserRole();
        var dateOfBirth = User.GetUserDateOfBirth();

        return new UserContextLightDto(id, email, role, dateOfBirth);
    }
}
