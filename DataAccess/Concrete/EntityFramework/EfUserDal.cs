using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from u in context.Users                           
                             join r in context.Rentals
                             on u.Id equals r.CustomerId
                             select new UserDetailDto
                             {
                                 UserId = r.CustomerId,
                                 UserName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
