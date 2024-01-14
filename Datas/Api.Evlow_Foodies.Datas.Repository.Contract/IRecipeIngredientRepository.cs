using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Datas.Repository.Contract
{
    public interface IRecipeIngredientRepository
    {
        /// <summary>
        /// Cette méthode permet de récupérer la liste de toutes les mesures.
        /// </summary>
        /// <returns></returns>
        Task<List<RecipeIngredient>> GetRecipeIngredientsAsync();

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une mesure par identifiant.
        /// </summary>
        /// <param name="id">L'identifiant.</param>
        /// <returns></returns>
        Task<RecipeIngredient> GetRecipeIngredientByIdAsync(int id);



        /// <summary>s
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        Task<RecipeIngredient> CreateRecipeIngredientAsync(RecipeIngredient recipeIngredient);

        /// <summary>
        /// Cette méthode permet de mettre à jour une unité de mesure .
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        Task<RecipeIngredient> UpdateRecipeIngredientAsync(RecipeIngredient recipeIngredient);


        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        Task<RecipeIngredient> DeleteRecipeIngredientAsync(RecipeIngredient recipeIngredient);
    }
}
