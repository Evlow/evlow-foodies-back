using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Mapper;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Service
{
    public class FavoriService : IFavoriService
    {
        /// <summary>
        /// Le repository de gestion des unités de mesures
        /// </summary>
        private readonly IFavoriRepository _favoriRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FavoriService"/> class.
        /// </summary>
        /// <param name="unityRepository">The unite repository.</param>
        public FavoriService(IFavoriRepository favoriRepository, IMapper mapper)
        {
            _favoriRepository = favoriRepository;
            _mapper = mapper;
        }




        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">L'unité à créer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il existe déjà une unité de mesure du même nom !!</exception>
        public async Task<FavoriDTO> CreateFavoriAsync(FavoriDTO favori)
        {
            var isExiste = await isFavori(favori.FavorisId).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà un commentaire identitique !!");

            var favoriToAdd = _mapper.Map<Favori>(favori);

            var favoriAdded = await _favoriRepository.CreateFavoriAsync(favoriToAdd).ConfigureAwait(false);

            return _mapper.Map<FavoriDTO>(favoriAdded);
        }





        /// <summary>
        /// Cette méthode permet de récupérer les listes des unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<FavoriDTO>> GetFavorisAsync()
        {
            var favories = await _favoriRepository.GetFavorisAsync().ConfigureAwait(false);
            List<FavoriDTO> listFavoriDTO = new List<FavoriDTO>(favories.Count);

            foreach (var favori in favories)
            {
                listFavoriDTO.Add(_mapper.Map<FavoriDTO>(favori));
            }

            return listFavoriDTO;
        }


        public async Task<FavoriDTO> GetFavoriIdAsync(int favoriId)
        {
            var favoriGet = await _favoriRepository.GetFavoriByIdAsync(favoriId).ConfigureAwait(false);
            return _mapper.Map<FavoriDTO>(favoriGet);
        }



        /// <summary>
        /// Cette méthode permet de mettre à jour une unité de mesure .
        /// </summary>
        /// <param name="UnityId">l'identifiant de unité</param>
        /// <param name="unity">l'unité modifié</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// Il existe déjà une unité de mesure du même nom !!
        /// or
        /// Il n'existe aucune unité de mesure avec cet identifiant : {UnityId}
        /// </exception>
        //public async Task<FavoriDTO> UpdateFavoriAsync(int favoriId, FavoriDTO favori)
        //{
        //    var isExiste = await CheckFavoriNameExisteAsync(favori.FavoriName).ConfigureAwait(false);
        //    if (isExiste)
        //        throw new Exception("Il existe déjà une unité de mesure du même nom !!");

        //    var favoriGet = await _favoriRepository.GetFavoriByIdAsync(favoriId).ConfigureAwait(false);
        //    if (favoriGet == null)
        //        throw new Exception($"Il n'existe aucune categorie de mesure avec cet identifiant : {favoriId}");

        //    favoriGet.FavoriName = favori.FavoriName;

        //    var favoriUpdated = await _favoriRepository.UpdateFavoriAsync(favoriGet).ConfigureAwait(false);

        //    return _mapper.Map<FavoriDTO>(favoriUpdated);

        //}

        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="favoriId">L'identifiant de l'unité à supprimer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il n'existe aucune unité de mesure avec cet identifiant : {idUnite}</exception>
        public async Task<FavoriDTO> DeleteFavoriAsync(int favoriId)
        {
            var favoriGet = await _favoriRepository.GetFavoriByIdAsync(favoriId).ConfigureAwait(false);
            if (favoriGet == null)
                throw new Exception($"Il n'existe aucune unité de mesure avec cet identifiant : {favoriId}");

            var favoriDeleted = await _favoriRepository.DeleteFavoriAsync(favoriGet).ConfigureAwait(false);

            return _mapper.Map<FavoriDTO>(favoriDeleted);
        }




    /// <summary>
    /// Cette méthode permet de vérifier si une unité existe déjà avec le même nom.
    /// </summary>
    /// <param name="favoriName">le nom de l'unité.</param>
    private async Task<bool> isFavori(int id)
    {
        var favoriGet = await _favoriRepository.GetFavoriByIdAsync(id).ConfigureAwait(false);

        return favoriGet != null;
    }




}
}
