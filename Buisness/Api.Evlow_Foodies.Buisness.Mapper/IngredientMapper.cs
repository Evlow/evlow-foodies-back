
using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;

namespace Api.Evlow_Foodies.Buisness.Mapper
{

    public static class IngredientMapper
    {
        public static Ingredient TransformDTOToEntity(IngredientDTO ingredientDTO)
        {
            return new Ingredient()
            {
                IngredientName = ingredientDTO.IngredientName
            };
        }
        public static IngredientDTO TransformEntityToDTO(Ingredient ingredientEntity)
        {
            return new IngredientDTO()
            {
                IngredientId = ingredientEntity.IngredientId,
                IngredientName = ingredientEntity.IngredientName
            };
        }

        public static IngredientDTO TransformEntityToDTO(int ingredientId)
        {
            throw new NotImplementedException();
        }
    }
}