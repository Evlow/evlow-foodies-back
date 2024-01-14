using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Mapper;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Service
{
    public class PreparationService : IPreparationService
    {
        private readonly IPreparationRepository _preparationRepository;

        public PreparationService(IPreparationRepository preparationRepository)
        {
            _preparationRepository = preparationRepository;
        }

        public async Task<List<PreparationDTO>> GetPreparationAsync()
        {
            var preparations = await _preparationRepository.GetPreparationsAsync().ConfigureAwait(false);
            List<PreparationDTO> listPreparationDTO = new List<PreparationDTO>(preparations.Count);

            foreach (var preparation in preparations)
            {
                listPreparationDTO.Add(PreparationMapper.TransformEntityToDTO(preparation));
            }

            return listPreparationDTO;
        }

        public async Task<PreparationDTO> GetPreparationIdAsync(int preparationId)
        {
            var preparationGet = await _preparationRepository.GetPreparationByIdAsync(preparationId).ConfigureAwait(false);
            var preparationGetDTO = PreparationMapper.TransformEntityToDTO(preparationGet);

            return preparationGetDTO;
        }

        public async Task<PreparationDTO> CreatePreparationAsync( PreparationDTO preparation)
        {
            var isExiste = await CheckPreparationDescriptionExisteAsync(preparation.PreparationDescription).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà une unité de mesure du même nom !!");

            var preparationToAdd = PreparationMapper.TransformEntityToDTO(preparation);

            var preparationAdded = await _preparationRepository.CreatePreparationAsync(preparationToAdd).ConfigureAwait(false);

            return PreparationMapper.TransformEntityToDTO(preparationAdded);
        }

        public async Task<PreparationDTO> UpdatePreparationAsync(int preparationId, PreparationDTO preparation )
        {
            var isExiste = await CheckPreparationDescriptionExisteAsync(preparation.PreparationDescription).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà une unité de mesure du même nom !!");

            var preparationGet = await _preparationRepository.GetPreparationByIdAsync(preparationId).ConfigureAwait(false);
            if (preparationGet == null)
                throw new Exception($"Il n'existe aucune unité de mesure avec cet identifiant : {preparationId}");

            preparationGet.PreparationDescription = preparation.PreparationDescription;

            var preparationUpdated = await _preparationRepository.UpdatePreparationAsync(preparationGet).ConfigureAwait(false);

            return PreparationMapper.TransformEntityToDTO(preparationUpdated);
        }

        public async Task<PreparationDTO> DeletePreparationAsync(int preparationId)
        {
            var preparationGet = await _preparationRepository.GetPreparationByIdAsync(preparationId).ConfigureAwait(false);
            if (preparationGet == null)
                throw new Exception($"Il n'existe aucune unité de mesure avec cet identifiant : {preparationId}");

            var preparationDeleted = await _preparationRepository.DeletePreparationAsync(preparationGet).ConfigureAwait(false);

            return PreparationMapper.TransformEntityToDTO(preparationDeleted);
        }

        private async Task<bool> CheckPreparationDescriptionExisteAsync(string preparationDescription)
        {
            var preparationGet = await _preparationRepository.GetPreparationByDescriptionAsync(preparationDescription).ConfigureAwait(false);

            return preparationGet != null;
        }
    }
}
