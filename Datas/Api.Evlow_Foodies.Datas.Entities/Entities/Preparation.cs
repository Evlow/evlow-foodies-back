using System;
using System.Collections.Generic;

namespace Api.Evlow_Foodies.Datas.Entities.Entities
{
    public partial class Preparation
    {
        public int PreparationId { get; set; }
        public int RecipeId { get; set; }
        public int PreparationEtape { get; set; }
        public string? PreparationDescription { get; set; }

        public virtual Recipe Recipe { get; set; } = null!;
    }
}
