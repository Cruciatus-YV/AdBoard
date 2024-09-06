﻿using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;

/// <summary>
/// Сущность пользователя
/// </summary>
public class UserEntity : BaseEntity<string>
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string FirstName { get; set; }
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public required string LastName { get; set; }
    /// <summary>
    /// Дата рождения пользователя
    /// </summary>
    public DateOnly Birthday { get; set; }


    /// <summary>
    /// Магазины
    /// </summary>
    public virtual List<StoreEntity> Stores { get; set; }
}
