using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Mapper;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Service
{
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Le repository de gestion des unités de mesures
        /// </summary>
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="unityRepository">The unite repository.</param>
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Cette méthode permet de récupérer les listes des unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync().ConfigureAwait(false);
            List<CategoryDTO> listCategoryDTO = new List<CategoryDTO>(categories.Count);

            foreach (var category in categories)
            {
                listCategoryDTO.Add(_mapper.Map<CategoryDTO>(category));
            }

            return listCategoryDTO;
        }


        public async Task<CategoryDTO> GetCategoryIdAsync(int categoryId)
        {
            var categoryGet = await _categoryRepository.GetCategoryByIdAsync(categoryId).ConfigureAwait(false);
            return _mapper.Map<CategoryDTO>(categoryGet);
        }



        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">L'unité à créer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il existe déjà une unité de mesure du même nom !!</exception>
        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO category)
        {
            var isExiste = await CheckCategoryNameExisteAsync(category.CategoryName).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà une unité de mesure du même nom !!");

            var categoryToAdd = _mapper.Map<Category>(category);

            var categoryAdded = await _categoryRepository.CreateCategoryAsync(categoryToAdd).ConfigureAwait(false);

            return _mapper.Map<CategoryDTO>(categoryAdded);

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
        public async Task<CategoryDTO> UpdateCategoryAsync(int categoryId, CategoryDTO category)
        {
            var isExiste = await CheckCategoryNameExisteAsync(category.CategoryName).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà une unité de mesure du même nom !!");

            var categoryGet = await _categoryRepository.GetCategoryByIdAsync(categoryId).ConfigureAwait(false);
            if (categoryGet == null)
                throw new Exception($"Il n'existe aucune categorie de mesure avec cet identifiant : {categoryId}");

            categoryGet.CategoryName = category.CategoryName;

            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(categoryGet).ConfigureAwait(false);

            return _mapper.Map<CategoryDTO>(categoryUpdated);

        }

        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="categoryId">L'identifiant de l'unité à supprimer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il n'existe aucune unité de mesure avec cet identifiant : {idUnite}</exception>
        public async Task<CategoryDTO> DeleteCategoryAsync(int categoryId)
        {
            var categoryGet = await _categoryRepository.GetCategoryByIdAsync(categoryId).ConfigureAwait(false);
            if (categoryGet == null)
                throw new Exception($"Il n'existe aucune unité de mesure avec cet identifiant : {categoryId}");

            var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(categoryGet).ConfigureAwait(false);

            return _mapper.Map<CategoryDTO>(categoryDeleted);
        }




        /// <summary>
        /// Cette méthode permet de vérifier si une unité existe déjà avec le même nom.
        /// </summary>
        /// <param name="categoryName">le nom de l'unité.</param>
        private async Task<bool> CheckCategoryNameExisteAsync(string categoryName)
        {
            var categoryGet = await _categoryRepository.GetCategoryByNameAsync(categoryName).ConfigureAwait(false);

            return categoryGet != null;
        }




    }
}
