﻿namespace CashFlow3.Domain.Repositories.User;
public interface IUserWriteOnlyRepository
{
    Task Add(Entities.User user);

    Task Delete(Entities.User user);
}
