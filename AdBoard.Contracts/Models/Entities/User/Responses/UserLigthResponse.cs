﻿namespace AdBoard.Contracts.Models.Entities.User.Responses;

public class UserLigthResponse
{
    public string Id { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string Email { get; set; }

    public long? AvatarId { get; set; }

    public UserLigthResponse(string id, string firstName, string lastName, string email, long? avatarId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        AvatarId = avatarId;
    }
}
