using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Datas.Repository.Contract
{
    public interface IUserRepository
    {
        /// <summary>
        /// Cette méthode permet de récupérer la liste de toutes les mesures.
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetUsersAsync();

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une mesure par identifiant.
        /// </summary>
        /// <param name="id">L'identifiant.</param>
        /// <returns></returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une unité par son nom.
        /// </summary>
        /// <param name="name">le nom de l'unité de mesure.</param>
        /// <returns></returns>
        Task<User> GetUserByPseudoAsync(string pseudo);

        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="user">The unite.</param>
        /// <returns></returns>
        Task<User> CreateUserAsync(User user);

        /// <summary>
        /// Cette méthode permet de mettre à jour une unité de mesure .
        /// </summary>
        /// <param name="user">The unite.</param>
        /// <returns></returns>
        Task<User> UpdateUserAsync(User user);


        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="user">The unite.</param>
        /// <returns></returns>
        Task<User> DeleteUserAsync(User user);
    }
}
