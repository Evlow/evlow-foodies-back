using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Mapper

{
    public static class PreparationMapper
    {
        public static Preparation TransformDTOToEntity(PreparationDTO preparationDTO)
        {
            return new Preparation
            {
                PreparationId = preparationDTO.PreparationId,
                PreparationEtape = preparationDTO.PreparationEtape,
                PreparationDescription = preparationDTO.PreparationDescription,
            };
        }

        public static PreparationDTO TransformEntityToDTO(Preparation preparationEntity)
        {
            return new PreparationDTO
            {
                PreparationId = preparationEntity.PreparationId,
                PreparationEtape = preparationEntity.PreparationEtape,
                PreparationDescription = preparationEntity.PreparationDescription
            };
        }

        public static Preparation TransformEntityToDTO(PreparationDTO preparation)
        {
            throw new NotImplementedException();
        }
    }
}
