using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        /// <summary>
        ///  Le service de gestion des unités de mesure
        /// </summary>
        private readonly IRecipeIngredientService _recipeIngredientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityController"/> class.
        /// </summary>
        /// <param name="unityService">The unite service.</param>
        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService)
        {
            _recipeIngredientService = recipeIngredientService;
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la liste des unités de mesure.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<RecipeIngredientDTO>), 200)]
        public async Task<ActionResult> GetRecipeIngredientsAsync()
        {
            var recipes = await _recipeIngredientService.GetRecipeIngredientsAsync().ConfigureAwait(false);

            return Ok(recipes);
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la un Id d'une unité de mesure
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RecipeIngredientDTO), 200)]
        public async Task<ActionResult> GetRecipeIngredientIdAsync(int id)
        {
            try
            {
                var recipeId = await _recipeIngredientService.GetRecipeIngredientIdAsync(id).ConfigureAwait(false);

                return Ok(recipeId);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message,
                });
            }

        }

        //POST api/Unites
        /// <summary>
        /// Ressource pour créer une nouvelle unité de mesure.
        /// </summary>
        /// <param name = "unity" > les données de l'unité à créer</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(RecipeIngredient), 200)]
        public async Task<ActionResult> CreateRecipeIngredientAsync([FromBody] RecipeIngredientDTO recipeIngredient)
        {
            // Omitted the check for RecipeIngredientQuantity

            var recipeIngredientAdded = await _recipeIngredientService.CreateRecipeIngredientAsync(recipeIngredient).ConfigureAwait(false);

            return Ok(recipeIngredientAdded);
        }

        //PUT api/Unites/1
        /// <summary>
        /// Ressource pour mettre à jour une unité de mesure.
        /// </summary>
        /// <param name = "id" > L'identifiant de l'unité.</param>
        /// <param name = "unite" > les données modifiées.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RecipeIngredient), 200)]
        public async Task<ActionResult> UpdateRecipeIngredientAsync(int id, [FromBody] RecipeIngredientDTO recipeIngredient)
        {
            if (recipeIngredient.RecipeIngredientQuantity == null)
            {
                return Problem("Echec : la quantité d'ingrédient ne peut pas être vide ou nulle !");
            }

            try
            {
                var recipeUpdated = await _recipeIngredientService.UpdateRecipeIngredientAsync(id, recipeIngredient).ConfigureAwait(false);
                return Ok(recipeUpdated);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message,
                });
            }
        }

        // DELETE api/Unites/1
        /// <summary>
        /// Ressource pour supprimer une unité de mesure.
        /// </summary>
        /// <param name="id">L'identifiant de l'unité.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RecipeIngredientDTO), 200)]
        public async Task<ActionResult> DeleteRecipeIngredientyAsync(int id)
        {
            try
            {
                var recipeDeleted = await _recipeIngredientService.DeleteRecipeIngredientAsync(id).ConfigureAwait(false);

                return Ok(recipeDeleted);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message,
                });
            }

        }

    }
}