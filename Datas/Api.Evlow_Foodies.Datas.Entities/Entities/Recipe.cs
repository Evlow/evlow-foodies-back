using System;
using System.Collections.Generic;

namespace Api.Evlow_Foodies.Datas.Entities.Entities
{
    public partial class Recipe
    {
        public Recipe()
        {
            Comments = new HashSet<Comment>();
            Favoris = new HashSet<Favori>();
            Preparations = new HashSet<Preparation>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string? RecipeTitle { get; set; }
        public string? RecipePicture { get; set; }
        public DateTime? RecipeCreatedAt { get; set; }
        public DateTime? RecipeUpdatedAt { get; set; }
        public decimal? RecipeStarNote { get; set; }

        public virtual Category? Category { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Favori> Favoris { get; set; }
        public virtual ICollection<Preparation> Preparations { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
