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
    public class IngredientRepository : IIngredientRepository
    {
        /// <summary>
        ///  Context de connexion à la base de données
        /// </summary>
        private readonly IEvlow_FoodiesDBContext _dBContext;

        public IngredientRepository(IEvlow_FoodiesDBContext dBContext)

        {
            _dBContext = dBContext;
        }


        /// <summary>
        /// Cette méthode permet de récupérer la liste de toutes les unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Ingredient>> GetIngredientsAsync()
        {
            return await _dBContext.Ingredients.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une unité de mesure par identifiant.
        /// </summary>
        /// <param name="id">L'identifiant.</param>
        /// <returns></returns>
        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {

            return await _dBContext.Ingredients.FirstOrDefaultAsync(ingredient => ingredient.IngredientId == id);

        }

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une unité de mesure par son nom.
        /// </summary>
        /// <param name="name">le nom de l'unité.</param>
        /// <returns></returns>
        public async Task<Ingredient> GetIngredientByNameAsync(string name)
        {
            return await _dBContext.Ingredients.FirstOrDefaultAsync(ingredient => ingredient.IngredientName == name)
                .ConfigureAwait(false);
        }


        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        {
            var elementAdded = await _dBContext.Ingredients.AddAsync(ingredient).ConfigureAwait(false);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementAdded.Entity;
        }


        /// <summary>
        /// Cette méthode permet de mettre une unité de mesure .
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient)
        {
            var elementUpdated = _dBContext.Ingredients.Update(ingredient);

            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }
        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Ingredient> DeleteIngredientAsync(Ingredient ingredient)
        {
            var elementDeleted = _dBContext.Ingredients.Remove(ingredient);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementDeleted.Entity;
        }
    }
}
