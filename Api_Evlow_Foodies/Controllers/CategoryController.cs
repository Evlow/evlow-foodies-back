using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        /// <summary>
        ///  Le service de gestion des unités de mesure
        /// </summary>
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityController"/> class.
        /// </summary>
        /// <param name="unityService">The unite service.</param>
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la liste des unités de mesure.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryDTO>), 200)]
        public async Task<ActionResult> GetCategorysAsync()
        {
            var categorys = await _categoryService.GetCategoriesAsync().ConfigureAwait(false);

            return Ok(categorys);
        }

        // GET api/Unites
        /// <summary>
        /// Ressource pour récupérer la un Id d'une unité de mesure
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryDTO), 200)]
        public async Task<ActionResult> ReccipeId(int id)
        {
            try
            {
                var categoryId = await _categoryService.GetCategoryIdAsync(id).ConfigureAwait(false);

                return Ok(categoryId);
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
        [ProducesResponseType(typeof(CategoryDTO), 200)]
        public async Task<ActionResult> CreateUnityAsync([FromBody] CategoryDTO category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var categoryAdded = await _categoryService.CreateCategoryAsync(category).ConfigureAwait(false);

                return Ok(categoryAdded);
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
        [ProducesResponseType(typeof(CategoryDTO), 200)]
        public async Task<ActionResult> UpdateUniteAsync(int id, [FromBody] CategoryDTO category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                return Problem("Echec : nous avons un nom d'unité de mesure vide !!");
            }

            try
            {
                var categoryUpdated = await _categoryService.UpdateCategoryAsync(id, category).ConfigureAwait(false);

                return Ok(categoryUpdated);
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
        [ProducesResponseType(typeof(CategoryDTO), 200)]
        public async Task<ActionResult> DeleteCategoryyAsync(int id)
        {
            try
            {
                var categoryDeleted = await _categoryService.DeleteCategoryAsync(id).ConfigureAwait(false);

                return Ok(categoryDeleted);
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