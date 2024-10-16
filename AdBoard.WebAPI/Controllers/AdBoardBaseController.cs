﻿using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Infrastructure.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers;

public abstract class AdBoardBaseController : ControllerBase
{
    protected UserContextLight GetUserContextLigth()
    {
        if (!User.Identity.IsAuthenticated)
        {
            throw new NotFoundException("Такой пользователь не существует"); //TODO поменять ошибку на 402 (Пользак не аутентифицирован)
        }

        var id = User.GetUserId();
        var email = User.GetUserEmail();
        var role = User.GetUserRole();
        var dateOfBirth = User.GetUserDateOfBirth();

        return new UserContextLight(id, email, role, dateOfBirth);
    }
}
