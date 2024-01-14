using System;
using System.Collections.Generic;

namespace Api.Evlow_Foodies.Datas.Entities.Entities
{
    public partial class Favori
    {
        public int FavorisId { get; set; }
        public int? UserId { get; set; }
        public int? RecipeId { get; set; }

        public virtual Recipe? Recipe { get; set; }
        public virtual User? User { get; set; }
    }
}
