using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.Service.Contract
{
    public interface ICommentService
    {

        /// <summary>
        /// Cette méthode permet de récupérer les listes des unités de mesure.
        /// </summary>
        /// <returns></returns>
        Task<List<CommentDTO>> GetCommentsAsync();

        /// <summary>
        /// Cette méthode permet de récupérer un id d'une unité de mesure.
        /// </summary>
        /// <returns></returns>
        Task<CommentDTO> GetCommentIdAsync(int commentId);

        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="comment">L'unité à créer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il existe déjà une unité de mesure du même nom !!</exception>
        Task<CommentDTO> CreateCommentAsync(CommentDTO comment);

        /// <summary>
        /// Cette méthode permet de mettre à jour une unité de mesure .
        /// </summary>
        /// <param name="commentId">l'identifiant de unité</param>
        /// <param name="comment">l'unité modifié</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// Il existe déjà une unité de mesure du même nom !!
        /// or
        /// Il n'existe aucune unité de mesure avec cet identifiant : {idUnite}
        /// </exception>
        Task<CommentDTO> UpdateCommentAsync(int commentId, CommentDTO comment);

        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="CommentId">L'identifiant de l'unité à supprimer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il n'existe aucune unité de mesure avec cet identifiant : {idUnite}</exception>
        Task<CommentDTO> DeleteCommentAsync(int CommentId);
    }
}
