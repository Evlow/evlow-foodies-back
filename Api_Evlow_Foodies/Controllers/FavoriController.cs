using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriController : ControllerBase
    {
        /// <summary>
        ///  Le service de gestion des unités de mesure
        /// </summary>
        private readonly IFavoriService _favoriService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityController"/> class.
        /// </summary>
        /// <param name="unityService">The unite service.</param>
        public FavoriController(IFavoriService favoriService)
        {
            _favoriService = favoriService;
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la liste des unités de mesure.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Favori>), 200)]
        public async Task<ActionResult> GetFavorisAsync()
        {
            var favoris = await _favoriService.GetFavorisAsync().ConfigureAwait(false);

            return Ok(favoris);
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la un Id d'une unité de mesure
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FavoriDTO), 200)]
        public async Task<ActionResult> ReccipeId(int id)
        {
            try
            {
                var favoriId = await _favoriService.GetFavoriIdAsync(id).ConfigureAwait(false);

                return Ok(favoriId);
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
        //[HttpPost]
        //[ProducesResponseType(typeof(Favori), 200)]
        //public async Task<ActionResult> CreateUnityAsync([FromBody] Favori favori)
        //{
        //    if (string.IsNullOrWhiteSpace(favori.FavoriTitle))
        //    {
        //        return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
        //    }

        //    try
        //    {
        //        var favoriAdded = await _favoriService.CreateFavoriAsync(favori).ConfigureAwait(false);

        //        return Ok(favoriAdded);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new
        //        {
        //            Error = e.Message,
        //        });
        //    }

        //}

        // PUT api/Unites/1
        /// <summary>
        /// Ressource pour mettre à jour une unité de mesure.
        /// </summary>
        /// <param name="id">L'identifiant de l'unité.</param>
        /// <param name="unite">les données modifiées.</param>
        /// <returns></returns>
        //[HttpPut("{id}")]
        //[ProducesResponseType(typeof(Favori), 200)]
        //public async Task<ActionResult> UpdateUniteAsync(int id, [FromBody] Favori favori)
        //{
        //    if (string.IsNullOrWhiteSpace(favori.FavoriTitle))
        //    {
        //        return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
        //    }

        //    try
        //    {
        //        var favoriUpdated = await _favoriService.UpdateFavoriAsync(id, favori).ConfigureAwait(false);

        //        return Ok(favoriUpdated);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new
        //        {
        //            Error = e.Message,
        //        });
        //    }

        //}

        // DELETE api/Unites/1
        /// <summary>
        /// Ressource pour supprimer une unité de mesure.
        /// </summary>
        /// <param name="id">L'identifiant de l'unité.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FavoriDTO), 200)]
        public async Task<ActionResult> DeleteFavoriyAsync(int id)
        {
            try
            {
                var favoriDeleted = await _favoriService.DeleteFavoriAsync(id).ConfigureAwait(false);

                return Ok(favoriDeleted);
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