using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Mapper
{
    public static class CategoryMapper
    {
        public static Category TransformDTOToEntity(CategoryDTO categoryDTO)
        {
            return new Category()
            {
                CategoryName = categoryDTO.CategoryName
            };
        }

        public static CategoryDTO TransformEntityToDTO(Category categoryEntity)
        {
            return new CategoryDTO()
            {
                CategoryId = categoryEntity.CategoryId,
                CategoryName = categoryEntity.CategoryName
            };
        }

    }

}

