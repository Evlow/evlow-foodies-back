using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Mapper;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using AutoMapper;

namespace Api.Evlow_Foodies.Buisness.Service
{
    public class UnityService : IUnityService
    {
        /// <summary>
        /// Le repository de gestion des unités de mesures
        /// </summary>
        private readonly IUnityRepository _unityRepository;
        private readonly IMapper _mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="UnityService"/> class.
        /// </summary>
        /// <param name="unityRepository">The unite repository.</param>
        public UnityService(IUnityRepository unityRepository, IMapper mapper)
        {
            _unityRepository = unityRepository;
            _mapper = mapper;

        }

        /// <summary>
        /// Cette méthode permet de récupérer les listes des unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<UnityDTO>> GetUnityMeasuresAsync()
        {
            var unities = await _unityRepository.GetUnitiesAsync().ConfigureAwait(false);
            List<UnityDTO> listUnityDTO = new List<UnityDTO>(unities.Count);

            foreach (var unity in unities)
            {
                listUnityDTO.Add(_mapper.Map<UnityDTO>(unity));
            }

            return listUnityDTO;
        }


        public async Task<UnityDTO> GetUnityMeasuresIdAsync(int UnityId)
        {
            var unityGet = await _unityRepository.GetUnityByIdAsync(UnityId).ConfigureAwait(false);
            return _mapper.Map<UnityDTO>(unityGet);

        }



        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">L'unité à créer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il existe déjà une unité de mesure du même nom !!</exception>
        public async Task<UnityDTO> CreateUnityMeasureAsync(UnityDTO unity)
        {
            var isExiste = await CheckUnityNameExisteAsync(unity.UnityName).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà une unité de mesure du même nom !!");

            var unityToAdd = UnityMapper.TransformDTOToEntity(unity);

            var unityAdded = await _unityRepository.CreateUnityAsync(unityToAdd).ConfigureAwait(false);

            return _mapper.Map<UnityDTO>(unityAdded);
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
        public async Task<UnityDTO> UpdateUnityMeasureAsync(int UnityId, UnityDTO unity)
        {
            var isExiste = await CheckUnityNameExisteAsync(unity.UnityName).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà une unité de mesure du même nom !!");

            var unityGet = await _unityRepository.GetUnityByIdAsync(UnityId).ConfigureAwait(false);
            if (unityGet == null)
                throw new Exception($"Il n'existe aucune unité de mesure avec cet identifiant : {UnityId}");

            unityGet.UnityName = unity.UnityName;

            var unityUpdated = await _unityRepository.UpdateUnityAsync(unityGet).ConfigureAwait(false);

            return _mapper.Map<UnityDTO>(unityUpdated);
        }

        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="UnityId">L'identifiant de l'unité à supprimer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il n'existe aucune unité de mesure avec cet identifiant : {idUnite}</exception>
        public async Task<UnityDTO> DeleteUnityMeasureAsync(int UnityId)
        {
            var unityGet = await _unityRepository.GetUnityByIdAsync(UnityId).ConfigureAwait(false);
            if (unityGet == null)
                throw new Exception($"Il n'existe aucune unité de mesure avec cet identifiant : {UnityId}");

            var uniteDeleted = await _unityRepository.DeleteUnityAsync(unityGet).ConfigureAwait(false);

            return _mapper.Map<UnityDTO>(uniteDeleted);
        }




        /// <summary>
        /// Cette méthode permet de vérifier si une unité existe déjà avec le même nom.
        /// </summary>
        /// <param name="unityName">le nom de l'unité.</param>
        private async Task<bool> CheckUnityNameExisteAsync(string unityName)
        {
            var unityGet = await _unityRepository.GetUnityByNameAsync(unityName).ConfigureAwait(false);

            return unityGet != null;
        }




    }
}