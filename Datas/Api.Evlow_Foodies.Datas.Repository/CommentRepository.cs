using Api.Evlow_Foodies.Datas.Context.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Datas.Repository
{
    public class CommentRepository : ICommentRepository
    {
        /// <summary>
        ///  Context de connexion à la base de données
        /// </summary>
        private readonly IEvlow_FoodiesDBContext _dBContext;

        public CommentRepository(IEvlow_FoodiesDBContext dBContext)

        {
            _dBContext = dBContext;
        }


        /// <summary>
        /// Cette méthode permet de récupérer la liste de toutes les unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Comment>> GetCommentsAsync()
        {
            return await _dBContext.Comments.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une unité de mesure par identifiant.
        /// </summary>
        /// <param name="id">L'identifiant.</param>
        /// <returns></returns>
        public async Task<Comment> GetCommentByIdAsync(int id)
        {

            return await _dBContext.Comments.FirstOrDefaultAsync(comment => comment.CommentId == id);

        }

        /// <summary>
        /// Cette méthode permet de récupérer les informations d'une unité de mesure par son nom.
        /// </summary>
        /// <param name="name">le nom de l'unité.</param>
        /// <returns></returns>
        public async Task<Comment> GetCommentByTitleAsync(string title)
        {
            return await _dBContext.Comments.FirstOrDefaultAsync(comment => comment.CommentTitle == title)
                .ConfigureAwait(false);
        }


        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            var elementAdded = await _dBContext.Comments.AddAsync(comment).ConfigureAwait(false);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementAdded.Entity;
        }


        /// <summary>
        /// Cette méthode permet de mettre une unité de mesure .
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Comment> UpdateCommentAsync(Comment comment)
        {
            var elementUpdated = _dBContext.Comments.Update(comment);

            await _dBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }
        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="unity">The unite.</param>
        /// <returns></returns>
        public async Task<Comment> DeleteCommentAsync(Comment comment)
        {
            var elementDeleted = _dBContext.Comments.Remove(comment);
            await _dBContext.SaveChangesAsync().ConfigureAwait(false);
            return elementDeleted.Entity;
        }
    }
}
