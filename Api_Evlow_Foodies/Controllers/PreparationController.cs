using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreparationController : ControllerBase
    {
        /// <summary>
        ///  Le service de gestion des unités de mesure
        /// </summary>
        private readonly IPreparationService _preparationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityController"/> class.
        /// </summary>
        /// <param name="unityService">The unite service.</param>
        public PreparationController(IPreparationService preparationService)
        {
            _preparationService = preparationService;
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la liste des unités de mesure.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<PreparationDTO>), 200)]
        public async Task<ActionResult> GetPreparationsAsync()
        {
            var preparations = await _preparationService.GetPreparationAsync().ConfigureAwait(false);

            return Ok(preparations);
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la un Id d'une unité de mesure
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PreparationDTO), 200)]
        public async Task<ActionResult> ReccipeId(int id)
        {
            try
            {
                var preparationId = await _preparationService.GetPreparationIdAsync(id).ConfigureAwait(false);

                return Ok(preparationId);
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
        [ProducesResponseType(typeof(PreparationDTO), 200)]
        public async Task<ActionResult> CreateUnityAsync([FromBody] PreparationDTO preparation)
        {
            if (string.IsNullOrWhiteSpace(preparation.PreparationDescription))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var preparationAdded = await _preparationService.CreatePreparationAsync(preparation).ConfigureAwait(false);

                return Ok(preparationAdded);
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
        [ProducesResponseType(typeof(PreparationDTO), 200)]
        public async Task<ActionResult> UpdateUniteAsync(int id, [FromBody] PreparationDTO preparation)
        {
            if (string.IsNullOrWhiteSpace(preparation.PreparationDescription))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var preparationUpdated = await _preparationService.UpdatePreparationAsync(id, preparation).ConfigureAwait(false);

                return Ok(preparationUpdated);
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
        [ProducesResponseType(typeof(PreparationDTO), 200)]
        public async Task<ActionResult> DeletePreparationyAsync(int id)
        {
            try
            {
                var preparationDeleted = await _preparationService.DeletePreparationAsync(id).ConfigureAwait(false);

                return Ok(preparationDeleted);
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