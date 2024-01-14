using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        /// <summary>
        ///  Le service de gestion des unités de mesure
        /// </summary>
        private readonly IRecipeService _recipeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityController"/> class.
        /// </summary>
        /// <param name="unityService">The unite service.</param>
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la liste des unités de mesure.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<RecipeDTO>), 200)]
        public async Task<ActionResult> GetRecipesAsync()
        {
            var recipes = await _recipeService.GetRecipeAsync().ConfigureAwait(false);

            return Ok(recipes);
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la un Id d'une unité de mesure
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RecipeDTO), 200)]
        public async Task<ActionResult> ReccipeId(int id)
        {
            try
            {
                var recipeId = await _recipeService.GetRecipeIdAsync(id).ConfigureAwait(false);

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

        // POST api/Unites
        /// <summary>
        /// Ressource pour créer une nouvelle unité de mesure.
        /// </summary>
        /// <param name="unity">les données de l'unité à créer</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(RecipeDTO), 200)]
        public async Task<ActionResult> CreateUnityAsync([FromBody] RecipeDTO recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe.RecipeTitle))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var recipeAdded = await _recipeService.CreateRecipeAsync(recipe).ConfigureAwait(false);

                return Ok(recipeAdded);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message,
                });
            }

        }

        // PUT api/Unites/1
        /// <summary>
        /// Ressource pour mettre à jour une unité de mesure.
        /// </summary>
        /// <param name="id">L'identifiant de l'unité.</param>
        /// <param name="unite">les données modifiées.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RecipeDTO), 200)]
        public async Task<ActionResult> UpdateUniteAsync(int id, [FromBody] RecipeDTO recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe.RecipeTitle))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var recipeUpdated = await _recipeService.UpdateRecipeAsync(id, recipe).ConfigureAwait(false);

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
        [ProducesResponseType(typeof(RecipeDTO), 200)]
        public async Task<ActionResult> DeleteRecipeyAsync(int id)
        {
            try
            {
                var recipeDeleted = await _recipeService.DeleteRecipeAsync(id).ConfigureAwait(false);

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
        [HttpGet("Category/{categoryId}")]
        [ProducesResponseType(typeof(List<RecipeDTO>), 200)]
        public async Task<ActionResult> GetSaltRecipesByCategoryIdAsync(int categoryId)
        {
            try
            {
                var recipesByCategory = await _recipeService.GetSaltRecipesByCategoryIdAsync(categoryId).ConfigureAwait(false);

                return Ok(recipesByCategory);
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