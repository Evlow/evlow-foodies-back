using System;
using System.Collections.Generic;

namespace Api.Evlow_Foodies.Datas.Entities.Entities
{
    public partial class Category
    {
        public Category()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
