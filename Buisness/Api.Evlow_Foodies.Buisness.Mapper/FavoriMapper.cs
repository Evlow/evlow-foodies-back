//using Api.Evlow_Foodies.Buisness.DTO;
//using Api.Evlow_Foodies.Datas.Entities.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Api.Evlow_Foodies.Buisness.Mapper
//{
//    public static class FavorisMapper
//    {
//        public static Favori TransformDTOToEntity(FavoriDTO favoriDTO)
//        {
//            return new Favori()
//            {
//                  FavorisId = favoriDTO.FavorisId,
//                UserId = favoriDTO.UserId,
//                RecipeId = favoriDTO.RecipeId,

//            };
//        }

//        public static FavoriDTO TransformEntityToDTO(Favori favoriEntity)
//        {
//            return new FavoriDTO()
//            {

//                FavorisId = favoriEntity.FavorisId,
//                UserId = favoriEntity.UserId,
//                RecipeId = favoriEntity.RecipeId,

//            };
//        }
//    }
//}
