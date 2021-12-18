using sage.challenge.data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sage.challenge.api
{
    public interface IUserService
    {
        Task<OperationResult<User>> CreateUser(User user);
        Task<OperationResult<Guid>> DeleteUser(Guid id);
        Task<OperationResult<User>> GetUser(Guid id);
        Task<OperationResult<IList<User>>> GetUsers();
        Task<OperationResult<User>> UpdateUser(User user);
    }
}