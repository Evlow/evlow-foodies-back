using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.DTO
{
    public class RecipeDTO
    {
        public int RecipeId { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string? RecipeTitle { get; set; }
        public string? RecipePicture { get; set; }
        public DateTime? RecipeCreatedAt { get; set; } // Changer DateOnly en DateTime
        public DateTime? RecipeUpdatedAt { get; set; } // Changer DateOnly en DateTime
        public decimal? RecipeStarNote { get; set; }
    }
}
