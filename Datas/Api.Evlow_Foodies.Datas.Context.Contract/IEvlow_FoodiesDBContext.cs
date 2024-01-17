using Api.Evlow_Foodies.Datas.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Datas.Context.Contract
{
    public interface IEvlow_FoodiesDBContext : IDbContext
    {

        DbSet<Category> Categories { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Favori> Favoris { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Preparation> Preparations { get; set; }
        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        DbSet<Unity> Unities { get; set; }
        DbSet<User> Users { get; set; }
    }
}