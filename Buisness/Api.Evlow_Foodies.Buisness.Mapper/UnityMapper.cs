using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Mapper
{
    public static class UnityMapper
    {
        public static Unity TransformDTOToEntity(UnityDTO unityDTO)
        {
            return new Unity()
            {
                UnityName = unityDTO.UnityName
            };
        }

        public static UnityDTO TransformEntityToDTO(Unity unityEntity)
        {
            return new UnityDTO()
            {
                UnityId = unityEntity.UnityId,
                UnityName = unityEntity.UnityName
            };
        }
    }

}