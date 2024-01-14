using System;
using System.Collections.Generic;

namespace Api.Evlow_Foodies.Datas.Entities.Entities
{
    public partial class Unity
    {
        public Unity()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int UnityId { get; set; }
        public string? UnityName { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
