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
    public class PreparationRepository : IPreparationRepository
    {
        /// <summary>
        ///  Context de connexion à la base de données
        /// </summary>
        private readonly IEvlow_FoodiesDBContext _dBContext;

        public PreparationRepository(IEvlow_FoodiesDBContext dBContext)

        {
            _dBContext = dBContext;
        }


        /// <summary>
        /// Cette méthode permet de récupérer la liste de toutes les unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Preparation>> GetPreparationsAsync()
        {
            return await _dBContext.Preparations.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une unité de mesure par identifiant.
        /// </summary>
        /// <param name="id">L'identifiant.</param>
        /// <returns></returns>
        public async Task<Preparation> GetPreparationByIdAsync(int id)
        {

            return await _dBContext.Preparations.FirstOrDefaultAsync(preparation => preparation.PreparationId == id);

        }

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une unité de mesure par son nom.
        /// </summary>
        /// <param name="name">le nom de l'unité.</param>
        /// <returns></returns>
        public async Task<Preparation> GetPreparationByDescriptionAsync(string description)
        {
            return await _dBContext.Preparations.FirstOrDefaultAsync(preparation => preparation.PreparationDescription == description)
                .ConfigureAwait(false);
        }


        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Preparation> CreatePreparationAsync(Preparation preparation)
        {
            var elementAdded = await _dBContext.Preparations.AddAsync(preparation).ConfigureAwait(false);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementAdded.Entity;
        }


        /// <summary>
        /// Cette méthode permet de mettre une unité de mesure .
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Preparation> UpdatePreparationAsync(Preparation preparation)
        {
            var elementUpdated = _dBContext.Preparations.Update(preparation);

            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }
        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Preparation> DeletePreparationAsync(Preparation preparation)
        {
            var elementDeleted = _dBContext.Preparations.Remove(preparation);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementDeleted.Entity;
        }
    }
}
