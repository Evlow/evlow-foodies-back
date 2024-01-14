using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.DTO
{
    public class FavoriDTO
    {
        public int FavorisId { get; set; }
        public int? UserId { get; set; }
        public int? RecipeId { get; set; }
    }
}
