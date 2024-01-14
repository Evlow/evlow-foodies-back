using System;
using System.Collections.Generic;

namespace Api.Evlow_Foodies.Datas.Entities.Entities
{
    public partial class RecipeIngredient
    {
        public int RecipeIngredientId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int? UnityId { get; set; }
        public decimal? RecipeIngredientQuantity { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;
        public virtual Recipe Recipe { get; set; } = null!;
        public virtual Unity? Unity { get; set; }
    }
}
