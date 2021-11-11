using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public class UserToUserDTO: IMapper<User, UserDTO>
    {
        public UserDTO Map(User user)
        {
            if (user is null)
            {
                return null;
            }
            else
            {
                return new UserDTO { Name = user.Name, Address = user.Address, Age = user.Age };
            }
        }
    }
}
