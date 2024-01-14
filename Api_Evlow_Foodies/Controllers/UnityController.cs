using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnityController : ControllerBase
    {
        /// <summary>
        ///  Le service de gestion des unités de mesure
        /// </summary>
        private readonly IUnityService _unityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityController"/> class.
        /// </summary>
        /// <param name="unityService">The unite service.</param>
        public UnityController(IUnityService unityService)
        {
            _unityService = unityService;
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la liste des unités de mesure.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<UnityDTO>), 200)]
        public async Task<ActionResult> GetUnitiesAsync()
        {
            var unities = await _unityService.GetUnityMeasuresAsync().ConfigureAwait(false);

            return Ok(unities);
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la un Id d'une unité de mesure
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UnityDTO), 200)]
        public async Task<ActionResult> UnityMeasuresId(int id)
        {
            try
            {
                var unityId = await _unityService.GetUnityMeasuresIdAsync(id).ConfigureAwait(false);

                return Ok(unityId);
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
        [ProducesResponseType(typeof(UnityDTO), 200)]
        public async Task<ActionResult> CreateUnityAsync([FromBody] UnityDTO unity)
        {
            if (string.IsNullOrWhiteSpace(unity.UnityName))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var unityAdded = await _unityService.CreateUnityMeasureAsync(unity).ConfigureAwait(false);

                return Ok(unityAdded);
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
        [ProducesResponseType(typeof(UnityDTO), 200)]
        public async Task<ActionResult> UpdateUniteAsync(int id, [FromBody] UnityDTO unity)
        {
            if (string.IsNullOrWhiteSpace(unity.UnityName))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var unityUpdated = await _unityService.UpdateUnityMeasureAsync(id, unity).ConfigureAwait(false);

                return Ok(unityUpdated);
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
        [ProducesResponseType(typeof(UnityDTO), 200)]
        public async Task<ActionResult> DeleteUnityAsync(int id)
        {
            try
            {
                var unityDeleted = await _unityService.DeleteUnityMeasureAsync(id).ConfigureAwait(false);

                return Ok(unityDeleted);
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
