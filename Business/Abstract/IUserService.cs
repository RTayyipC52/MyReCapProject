using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetByEmail(string mail);
        IDataResult<List<User>> GetByPassword(string password);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

        IDataResult<List<UserDetailDto>> GetUserDetails();
    }
}
