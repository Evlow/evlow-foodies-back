using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Service.Contract
{
    public interface IRecipeService
    {
        /// <summary>
        /// Cette méthode permet de récupérer les listes des unités de mesure.
        /// </summary>
        /// <returns></returns>
        Task<List<RecipeDTO>> GetRecipeAsync();

        /// <summary>
        /// Cette méthode permet de récupérer un id d'une unité de mesure.
        /// </summary>
        /// <returns></returns>
        Task<RecipeDTO> GetRecipeIdAsync(int recipeId);

        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">L'unité à créer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il existe déjà une unité de mesure du même nom !!</exception>
        Task<RecipeDTO> CreateRecipeAsync(RecipeDTO recipe);

        /// <summary>
        /// Cette méthode permet de mettre à jour une unité de mesure .
        /// </summary>
        /// <param name="unityId">l'identifiant de unité</param>
        /// <param name="unity">l'unité modifié</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// Il existe déjà une unité de mesure du même nom !!
        /// or
        /// Il n'existe aucune unité de mesure avec cet identifiant : {idUnite}
        /// </exception>
        Task<RecipeDTO> UpdateRecipeAsync(int recipeId, RecipeDTO recipe);

        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="UnityId">L'identifiant de l'unité à supprimer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il n'existe aucune unité de mesure avec cet identifiant : {idUnite}</exception>
        Task<RecipeDTO> DeleteRecipeAsync(int recipeId);
        Task<List<RecipeDTO>> GetSaltRecipesByCategoryIdAsync(int categoryId);

    }
}
