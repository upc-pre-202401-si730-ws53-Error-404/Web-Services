﻿namespace ChaquitacllaError404.API.Users.Domain.Model.Commands;

public record CreateUserCommand(string FirstName, string LastName, string Email, string Password, int Price, string Description, string City, string Country);