using Api.Evlow_Foodies.Datas.Context.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Datas.Repository
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        /// <summary>
        ///  Context de connexion à la base de données
        /// </summary>
        private readonly IEvlow_FoodiesDBContext _dBContext;

        public RecipeIngredientRepository(IEvlow_FoodiesDBContext dBContext)

        {
            _dBContext = dBContext;
        }


        /// <summary>
        /// Cette méthode permet de récupérer la liste de toutes les unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RecipeIngredient>> GetRecipeIngredientsAsync()
        {
            return await _dBContext.RecipeIngredients.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une unité de mesure par identifiant.
        /// </summary>
        /// <param name="id">L'identifiant.</param>
        /// <returns></returns>
        public async Task<RecipeIngredient> GetRecipeIngredientByIdAsync(int id)
        {

            return await _dBContext.RecipeIngredients.FirstOrDefaultAsync(recipeIngredient => recipeIngredient.RecipeId == id);

        }

        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<RecipeIngredient> CreateRecipeIngredientAsync(RecipeIngredient recipeIngredient)
        {
            var elementAdded = await _dBContext.RecipeIngredients.AddAsync(recipeIngredient).ConfigureAwait(false);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementAdded.Entity;
        }


        /// <summary>
        /// Cette méthode permet de mettre une unité de mesure .
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<RecipeIngredient> UpdateRecipeIngredientAsync(RecipeIngredient recipeIngredient)
        {
            var elementUpdated = _dBContext.RecipeIngredients.Update(recipeIngredient);

            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }
        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<RecipeIngredient> DeleteRecipeIngredientAsync(RecipeIngredient recipeIngredient)
        {
            var elementDeleted = _dBContext.RecipeIngredients.Remove(recipeIngredient);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementDeleted.Entity;
        }
    }
}
