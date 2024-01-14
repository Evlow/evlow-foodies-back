using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityController"/> class.
        /// </summary>
        /// <param name="unityService">The unite service.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la liste des unités

        /// <summary>
        ///  Le service de gestion des unités de mesure de mesure.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDTO>), 200)]
        public async Task<ActionResult> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync().ConfigureAwait(false);

            return Ok(users);
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la un Id d'une unité de mesure
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        public async Task<ActionResult> RecipeId(int id)
        {
            try
            {
                var userId = await _userService.GetUserIdAsync(id).ConfigureAwait(false);

                return Ok(userId);
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
        [ProducesResponseType(typeof(UserDTO), 200)]
        public async Task<ActionResult> CreateUnityAsync([FromBody] UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.UserPseudo))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var userAdded = await _userService.CreateUserAsync(user).ConfigureAwait(false);

                return Ok(userAdded);
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
        [ProducesResponseType(typeof(UserDTO), 200)]
        public async Task<ActionResult> UpdateUniteAsync(int id, [FromBody] UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.UserPseudo))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var userUpdated = await _userService.UpdateUserAsync(id, user).ConfigureAwait(false);

                return Ok(userUpdated);
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
        [ProducesResponseType(typeof(UserDTO), 200)]
        public async Task<ActionResult> DeleteUseryAsync(int id)
        {
            try
            {
                var userDeleted = await _userService.DeleteUserAsync(id).ConfigureAwait(false);

                return Ok(userDeleted);
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