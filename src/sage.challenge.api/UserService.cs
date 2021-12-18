using sage.challenge.data.Cache;
using sage.challenge.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sage.challenge.api
{
    public class UserService : IUserService
    {
        private readonly ISimpleObjectCache<Guid, User> _cache;

        public UserService(ISimpleObjectCache<Guid, User> cache)
        {
            _cache = cache;
        }

        public async Task<OperationResult<User>> CreateUser(User user)
        {
            var users = await _cache.GetAllAsync();
            if (users.Any(u => u.Email == user.Email))
            {
                return OperationResult<User>.BuildFailure(("Email is not unique"));
            }

            var age = (DateTime.Now - user.DateOfBirth).TotalDays / (365);
            if (age < 18)
            {

                return OperationResult<User>.BuildFailure("User must be at least 18 years old");
            }
            await _cache.AddAsync(user.Id, user);

            return OperationResult<User>.BuildSuccess(user);
        }


        public async Task<OperationResult<IList<User>>> GetUsers()
        {
            try
            {
                var users = await _cache.GetAllAsync();
                return OperationResult<IList<User>>.BuildSuccess(users.ToList());
            }
            catch (Exception ex)
            {

                return OperationResult<IList<User>>.BuildFailure(ex);
            }
        }

        public async Task<OperationResult<User>> GetUser(Guid id)
        {
            try
            {
                var user = await _cache.GetAsync(id);
                if (user is not null)
                    OperationResult<User>.BuildSuccess(user);

            }
            catch (Exception ex)
            {

                return OperationResult<User>.BuildFailure(ex);
            }

            return OperationResult<User>.BuildFailure($"User {id} not found");

        }

        public async Task<OperationResult<User>> UpdateUser(User user)
        {
            var users = await _cache.GetAllAsync();
            if (users.Any(u => u.Email == user.Email))
            {
                return OperationResult<User>.BuildFailure(("Email is not unique"));
            }

            var age = (DateTime.Now - user.DateOfBirth).TotalDays / (365);
            if (age < 18)
            {

                return OperationResult<User>.BuildFailure("User must be at least 18 years old");
            }

            try
            {
                await _cache.UpdateAsync(user.Id, user);
                return OperationResult<User>.BuildSuccess(user);
            }
            catch (Exception ex)
            {

                return OperationResult<User>.BuildFailure(ex);
            }

        }

        public async Task<OperationResult<Guid>> DeleteUser(Guid id)
        {
            try
            {
                await _cache.DeleteAsync(id);
                return OperationResult<Guid>.BuildSuccess(id);
            }
            catch (Exception ex)
            {

                return OperationResult<Guid>.BuildFailure(ex);
            }

        }
    }
}
