using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Evlow_Foodies.Datas.Entities.Entities
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Favoris = new HashSet<Favori>();
            Recipes = new HashSet<Recipe>();
        }

        public int UserId { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserPseudo { get; set; }
        public string? UserEmail { get; set; }
        [JsonIgnore] public string UserPassword { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Favori> Favoris { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
