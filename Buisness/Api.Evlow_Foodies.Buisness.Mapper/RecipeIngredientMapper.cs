//using Api.Evlow_Foodies.Buisness.DTO;
//using Api.Evlow_Foodies.Datas.Entities.Entities;

//namespace Api.Evlow_Foodies.Buisness.Mapper
//{
//    namespace Api.Evlow_Foodies.Buisness.Mapper
//    {
//        public static class RecipeIngredientMapper
//        {
//            public static RecipeIngredient TransformDTOToEntity(RecipeIngredientDTO recipeIngredientDTO)
//            {
//                return new RecipeIngredient()
//                {
//                    RecipeIngredientId = recipeIngredientDTO.RecipeIngredientId,
//                    RecipeId = recipeIngredientDTO.RecipeId,
//                    IngredientId = recipeIngredientDTO.IngredientId,
//                    UnityId = recipeIngredientDTO.UnityId,
//                    RecipeIngredientQuantity = recipeIngredientDTO.RecipeIngredientQuantity,

//                };
//            }

//            public static RecipeIngredientDTO TransformEntityToDTO(RecipeIngredient recipeIngredientEntity)
//            {
//                return new RecipeIngredientDTO()
//                {
//                    RecipeIngredientId = recipeIngredientEntity.RecipeIngredientId,
//                    RecipeId = recipeIngredientEntity.RecipeId,
//                    IngredientId = recipeIngredientEntity.IngredientId,
//                    UnityId = recipeIngredientEntity.UnityId,
//                    RecipeIngredientQuantity = recipeIngredientEntity.RecipeIngredientQuantity,
//                };
//            }
//        }
//    }
//}