using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Mapper;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using AutoMapper;


namespace Api.Evlow_Foodies.Buisness.Service
{
    public class IngredientService : IIngredientService
    {
        /// <summary>
        /// Le repository de gestion des unités de mesures
        /// </summary>
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientService"/> class.
        /// </summary>
        /// <param name="unityRepository">The unite repository.</param>
        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Cette méthode permet de récupérer les listes des unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<IngredientDTO>> GetIngredientsAsync()
        {
            var ingredients = await _ingredientRepository.GetIngredientsAsync().ConfigureAwait(false);
            List<IngredientDTO> listIngredientDTO = new List<IngredientDTO>(ingredients.Count);

            foreach (var ingredient in ingredients)
            {
                listIngredientDTO.Add(_mapper.Map<IngredientDTO>(ingredient));
            }

            return listIngredientDTO;
        }


        public async Task<IngredientDTO> GetIngredientIdAsync(int ingredientId)
        {
            var ingredientGet = await _ingredientRepository.GetIngredientByIdAsync(ingredientId).ConfigureAwait(false);
            return _mapper.Map<IngredientDTO>(ingredientGet);
        }



        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">L'unité à créer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il existe déjà une unité de mesure du même nom !!</exception>
        public async Task<IngredientDTO> CreateIngredientAsync(IngredientDTO ingredient)
        {
            var isExiste = await CheckIngredientNameExisteAsync(ingredient.IngredientName).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà une unité de mesure du même nom !!");

            var ingredientToAdd = _mapper.Map<Ingredient>(ingredient);

            var ingredientAdded = await _ingredientRepository.CreateIngredientAsync(ingredientToAdd).ConfigureAwait(false);

            return _mapper.Map<IngredientDTO>(ingredientAdded);

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
        public async Task<IngredientDTO> UpdateIngredientAsync(int ingredientId, IngredientDTO ingredient)
        {
            var isExiste = await CheckIngredientNameExisteAsync(ingredient.IngredientName).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà une unité de mesure du même nom !!");

            var ingredientGet = await _ingredientRepository.GetIngredientByIdAsync(ingredientId).ConfigureAwait(false);
            if (ingredientGet == null)
                throw new Exception($"Il n'existe aucune categorie de mesure avec cet identifiant : {ingredientId}");

            ingredientGet.IngredientName = ingredient.IngredientName;

            var ingredientUpdated = await _ingredientRepository.UpdateIngredientAsync(ingredientGet).ConfigureAwait(false);

            return _mapper.Map<IngredientDTO>(ingredientUpdated);

        }

        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="ingredientId">L'identifiant de l'unité à supprimer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il n'existe aucune unité de mesure avec cet identifiant : {idUnite}</exception>
        public async Task<IngredientDTO> DeleteIngredientAsync(int ingredientId)
        {
            var ingredientGet = await _ingredientRepository.GetIngredientByIdAsync(ingredientId).ConfigureAwait(false);
            if (ingredientGet == null)
                throw new Exception($"Il n'existe aucune unité de mesure avec cet identifiant : {ingredientId}");

            var ingredientDeleted = await _ingredientRepository.DeleteIngredientAsync(ingredientGet).ConfigureAwait(false);

            return _mapper.Map<IngredientDTO>(ingredientDeleted);
        }




        /// <summary>
        /// Cette méthode permet de vérifier si une unité existe déjà avec le même nom.
        /// </summary>
        /// <param name="ingredientName">le nom de l'unité.</param>
        private async Task<bool> CheckIngredientNameExisteAsync(string ingredientName)
        {
            var ingredientGet = await _ingredientRepository.GetIngredientByNameAsync(ingredientName).ConfigureAwait(false);

            return ingredientGet != null;
        }




    }
}
