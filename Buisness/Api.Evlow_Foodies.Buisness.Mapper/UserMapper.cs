using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Mapper
{
    public static class UserMapper
    {
        public static User TransformDTOToEntity(UserDTO userDTO)
        {
            return new User()
            {
                UserId = userDTO.UserId,
                UserFirstName = userDTO.UserFirstName,
                UserLastName = userDTO.UserLastName,
                UserPseudo = userDTO.UserPseudo,
                UserEmail = userDTO.UserEmail,
                UserPassword = userDTO.UserPassword
            };
        }

        public static UserDTO TransformEntityToDTO(User userEntity)
        {
            return new UserDTO()
            {
                UserId = userEntity.UserId,
                UserFirstName = userEntity.UserFirstName,
                UserLastName = userEntity.UserLastName,
                UserPseudo = userEntity.UserPseudo,
                UserEmail = userEntity.UserEmail,
                UserPassword = userEntity.UserPassword
            };
        }
    }
}
