using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Service.Contract
{
    public interface IPreparationService
    {
        /// <summary>
        /// Cette méthode permet de récupérer la liste des étapes de préparation.
        /// </summary>
        /// <returns></returns>
        Task<List<PreparationDTO>> GetPreparationAsync();

        /// <summary>
        /// Cette méthode permet de récupérer une étape de préparation par son identifiant.
        /// </summary>
        /// <param name="recipeId">L'identifiant de la recette.</param>
        /// <param name="preparationEtape">L'étape de préparation.</param>
        /// <returns></returns>
        Task<PreparationDTO> GetPreparationIdAsync(int preparationId);

        /// <summary>
        /// Cette méthode permet de créer une étape de préparation.
        /// </summary>
        /// <param name="preparation">L'étape de préparation à créer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il existe déjà une étape de préparation avec le même nom !!</exception>
        Task<PreparationDTO> CreatePreparationAsync(PreparationDTO preparation);

        /// <summary>
        /// Cette méthode permet de mettre à jour une étape de préparation.
        /// </summary>
        /// <param name="recipeId">L'identifiant de la recette.</param>
        /// <param name="preparation">L'étape de préparation modifiée.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// Il existe déjà une étape de préparation avec le même nom !!
        /// or
        /// Il n'existe aucune étape de préparation avec cet identifiant : {recipeId}
        /// </exception>
        Task<PreparationDTO> UpdatePreparationAsync(int preparationId, PreparationDTO preparation);

        /// <summary>
        /// Cette méthode permet de supprimer une étape de préparation.
        /// </summary>
        /// <param name="recipeId">L'identifiant de la recette.</param>
        /// <param name="preparationEtape">L'étape de préparation à supprimer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il n'existe aucune étape de préparation avec cet identifiant : {recipeId}</exception>
        Task<PreparationDTO> DeletePreparationAsync(int preparationId);
    }
}
