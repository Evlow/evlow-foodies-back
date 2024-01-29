using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserPseudo { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }

        public IEnumerable<Recipe> GetRecipesAsync()
        {
            // Filtrer les recettes en fonction de l'ID de l'utilisateur
            return Recipes.Where(recipe => recipe.UserId == UserId);
        }

        //public virtual ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<Favori> Favoris { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
