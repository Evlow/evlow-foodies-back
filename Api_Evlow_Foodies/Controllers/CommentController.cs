using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        /// <summary>
        ///  Le service de gestion des unités de mesure
        /// </summary>
        private readonly ICommentService _commentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityController"/> class.
        /// </summary>
        /// <param name="unityService">The unite service.</param>
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la liste des unités de mesure.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CommentDTO>), 200)]
        public async Task<ActionResult> GetCommentsAsync()
        {
            var comments = await _commentService.GetCommentsAsync().ConfigureAwait(false);

            return Ok(comments);
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la un Id d'une unité de mesure
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommentDTO), 200)]
        public async Task<ActionResult> ReccipeId(int id)
        {
            try
            {
                var commentId = await _commentService.GetCommentIdAsync(id).ConfigureAwait(false);

                return Ok(commentId);
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
        [ProducesResponseType(typeof(CommentDTO), 200)]
        public async Task<ActionResult> CreateUnityAsync([FromBody] CommentDTO comment)
        {
            if (string.IsNullOrWhiteSpace(comment.CommentTitle))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var commentAdded = await _commentService.CreateCommentAsync(comment).ConfigureAwait(false);

                return Ok(commentAdded);
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
        [ProducesResponseType(typeof(CommentDTO), 200)]
        public async Task<ActionResult> UpdateCommentAsync(int id, [FromBody] CommentDTO comment)
        {
            if (string.IsNullOrWhiteSpace(comment.CommentTitle))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var commentUpdated = await _commentService.UpdateCommentAsync(id, comment).ConfigureAwait(false);

                return Ok(commentUpdated);
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
        [ProducesResponseType(typeof(CommentDTO), 200)]
        public async Task<ActionResult> DeleteCommentyAsync(int id)
        {
            try
            {
                var commentDeleted = await _commentService.DeleteCommentAsync(id).ConfigureAwait(false);

                return Ok(commentDeleted);
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