using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Mapper
{
    public static class RecipeMapper
    {
        public static Recipe TransformDTOToEntity(RecipeDTO recipeDTO)
        {
            return new Recipe()
            {

                RecipeTitle = recipeDTO.RecipeTitle,
                RecipePicture = recipeDTO.RecipePicture,
                RecipeCreatedAt = recipeDTO.RecipeCreatedAt,
                RecipeUpdatedAt = recipeDTO.RecipeUpdatedAt,
                RecipeStarNote = recipeDTO.RecipeStarNote
            };
        }

        public static RecipeDTO TransformEntityToDTO(Recipe recipeEntity)
        {
            return new RecipeDTO()
            {
                RecipeId = recipeEntity.RecipeId,
                UserId = recipeEntity.UserId,
                CategoryId = recipeEntity.CategoryId,
                RecipeTitle = recipeEntity.RecipeTitle,
                RecipePicture = recipeEntity.RecipePicture,
                RecipeCreatedAt = recipeEntity.RecipeCreatedAt,
                RecipeUpdatedAt = recipeEntity.RecipeUpdatedAt,
                RecipeStarNote = recipeEntity.RecipeStarNote
            };
        }
    }
}
