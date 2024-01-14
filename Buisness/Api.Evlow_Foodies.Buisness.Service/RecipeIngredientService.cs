using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Mapper;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using AutoMapper;


namespace Api.Evlow_Foodies.Buisness.Service
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        /// <summary>
        /// Le repository de gestion des unités de mesures
        /// </summary>
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeIngredientService"/> class.
        /// </summary>
        /// <param name="unityRepository">The unite repository.</param>
        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository, IMapper mapper)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
            _mapper = mapper;

        }
        /// <summary>
        /// Cette méthode permet de récupérer les listes des unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RecipeIngredientDTO>> GetRecipeIngredientsAsync()
        {
            var recipeIngredients = await _recipeIngredientRepository.GetRecipeIngredientsAsync().ConfigureAwait(false);
            List<RecipeIngredientDTO> listRecipeIngredientDTO = new List<RecipeIngredientDTO>(recipeIngredients.Count);

            foreach (var recipeIngredient in recipeIngredients)
            {
                listRecipeIngredientDTO.Add(_mapper.Map<RecipeIngredientDTO>(recipeIngredient));
            }

            return listRecipeIngredientDTO;
        }
        public async Task<RecipeIngredientDTO> GetRecipeIngredientIdAsync(int recipeIngredientId)
        {
            var recipeIngredientGet = await _recipeIngredientRepository.GetRecipeIngredientByIdAsync(recipeIngredientId).ConfigureAwait(false);
            return _mapper.Map<RecipeIngredientDTO>(recipeIngredientGet);
        }


        /// <summary>
        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">L'unité à créer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il existe déjà une unité de mesure du même nom !!</exception>
        public async Task<RecipeIngredientDTO> CreateRecipeIngredientAsync(RecipeIngredientDTO recipeIngredient)
        {

            var recipeIngredientToAdd = _mapper.Map<RecipeIngredient>(recipeIngredient);

            var recipeIngredientAdded = await _recipeIngredientRepository.CreateRecipeIngredientAsync(recipeIngredientToAdd).ConfigureAwait(false);

            return _mapper.Map<RecipeIngredientDTO>(recipeIngredientAdded);
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
        public async Task<RecipeIngredientDTO> UpdateRecipeIngredientAsync(int recipeIngredientId, RecipeIngredientDTO recipeIngredient)
        {
            // Get the existing RecipeIngredient by its ID
            var recipeIngredientGet = await _recipeIngredientRepository.GetRecipeIngredientByIdAsync(recipeIngredientId).ConfigureAwait(false);

            // Check if the RecipeIngredient exists
            if (recipeIngredientGet == null)
                throw new Exception($"No RecipeIngredient found with the ID: {recipeIngredientId}");

            // Update the properties of the existing RecipeIngredient
            recipeIngredientGet.RecipeIngredientQuantity = recipeIngredient.RecipeIngredientQuantity;
            // Update other properties as needed

            // Update the RecipeIngredient in the repository
            var updatedRecipeIngredient = await _recipeIngredientRepository.UpdateRecipeIngredientAsync(recipeIngredientGet).ConfigureAwait(false);

            // Map and return the updated RecipeIngredient
            return _mapper.Map<RecipeIngredientDTO>(updatedRecipeIngredient);
        }

        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="recipeIngredientId">L'identifiant de l'unité à supprimer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il n'existe aucune unité de mesure avec cet identifiant : {idUnite}</exception>
        public async Task<RecipeIngredientDTO> DeleteRecipeIngredientAsync(int recipeIngredientId)
        {
            var recipeIngredientGet = await _recipeIngredientRepository.GetRecipeIngredientByIdAsync(recipeIngredientId).ConfigureAwait(false);
            if (recipeIngredientGet == null)
                throw new Exception($"Il n'existe aucune unité de mesure avec cet identifiant : {recipeIngredientId}");

            var recipeIngredientDeleted = await _recipeIngredientRepository.DeleteRecipeIngredientAsync(recipeIngredientGet).ConfigureAwait(false);

            return _mapper.Map<RecipeIngredientDTO>(recipeIngredientDeleted);
        }

    }
}