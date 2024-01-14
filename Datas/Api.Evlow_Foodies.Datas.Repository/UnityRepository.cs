using Api.Evlow_Foodies.Datas.Context.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Datas.Repository
{
    public class UnityRepository : IUnityRepository
    {
        /// <summary>
        ///  Context de connexion à la base de données
        /// </summary>
        private readonly IEvlow_FoodiesDBContext _dBContext;

        public UnityRepository(IEvlow_FoodiesDBContext dBContext)

        {
            _dBContext = dBContext;
        }


        /// <summary>
        /// Cette méthode permet de récupérer la liste de toutes les unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Unity>> GetUnitiesAsync()
        {
            return await _dBContext.Unities.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une unité de mesure par identifiant.
        /// </summary>
        /// <param name="id">L'identifiant.</param>
        /// <returns></returns>
       public  async Task<Unity> GetUnityByIdAsync( int id)
        {

            return await _dBContext.Unities.FirstOrDefaultAsync(unity => unity.UnityId == id);

        }

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une unité de mesure par son nom.
        /// </summary>
        /// <param name="name">le nom de l'unité.</param>
        /// <returns></returns>
        public async Task<Unity> GetUnityByNameAsync(string name)
        {
            return await _dBContext.Unities.FirstOrDefaultAsync(unity => unity.UnityName == name)
                .ConfigureAwait(false);
        }


        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Unity> CreateUnityAsync(Unity unity)
        {
            var elementAdded = await _dBContext.Unities.AddAsync(unity).ConfigureAwait(false);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementAdded.Entity;
        }


        /// <summary>
        /// Cette méthode permet de mettre une unité de mesure .
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Unity> UpdateUnityAsync(Unity unity)
        {
            var elementUpdated = _dBContext.Unities.Update(unity);

            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }
        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Unity> DeleteUnityAsync(Unity unity)
        {
            var elementDeleted = _dBContext.Unities.Remove(unity);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementDeleted.Entity;
        }



    }
}
