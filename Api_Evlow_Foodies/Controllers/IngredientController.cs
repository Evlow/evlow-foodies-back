using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        /// <summary>
        ///  Le service de gestion des unités de mesure
        /// </summary>
        private readonly IIngredientService _ingredientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityController"/> class.
        /// </summary>
        /// <param name="unityService">The unite service.</param>
        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la liste des unités de mesure.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<IngredientDTO>), 200)]
        public async Task<ActionResult> GetIngredientsAsync()
        {
            var ingredients = await _ingredientService.GetIngredientsAsync().ConfigureAwait(false);

            return Ok(ingredients);
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la un Id d'une unité de mesure
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IngredientDTO), 200)]
        public async Task<ActionResult> GetIngredientIdAsync(int id)
        {
            try
            {
                var ingredientId = await _ingredientService.GetIngredientIdAsync(id).ConfigureAwait(false);

                return Ok(ingredientId);
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
        [ProducesResponseType(typeof(IngredientDTO), 200)]
        public async Task<ActionResult> CreateIngredientAsync([FromBody] IngredientDTO ingredient)
        {
            if (string.IsNullOrWhiteSpace(ingredient.IngredientName))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var ingredientAdded = await _ingredientService.CreateIngredientAsync(ingredient).ConfigureAwait(false);

                return Ok(ingredientAdded);
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
        [ProducesResponseType(typeof(IngredientDTO), 200)]
        public async Task<ActionResult> UpdateIngredientAsync(int id, [FromBody] IngredientDTO ingredient)
        {
            if (string.IsNullOrWhiteSpace(ingredient.IngredientName))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var ingredientUpdated = await _ingredientService.UpdateIngredientAsync(id, ingredient).ConfigureAwait(false);

                return Ok(ingredientUpdated);
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
        [ProducesResponseType(typeof(IngredientDTO), 200)]
        public async Task<ActionResult> DeleteIngredientyAsync(int id)
        {
            try
            {
                var ingredientDeleted = await _ingredientService.DeleteIngredientAsync(id).ConfigureAwait(false);

                return Ok(ingredientDeleted);
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