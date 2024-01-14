using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Buisness.Mapper;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using AutoMapper;

namespace Api.Evlow_Foodies.Buisness.Service
{
    public class CommentService : ICommentService
    {
        /// <summary>
        /// Le repository de gestion des unités de mesures
        /// </summary>
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="CommentService"/> class.
        /// </summary>
        /// <param name="unityRepository">The unite repository.</param>
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;

        }

        /// <summary>
        /// Cette méthode permet de récupérer les listes des unités de mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CommentDTO>> GetCommentsAsync()
        {
            var comments = await _commentRepository.GetCommentsAsync().ConfigureAwait(false);
            List<CommentDTO> listCommentDTO = new List<CommentDTO>(comments.Count);

            foreach (var comment in comments)
            {
                listCommentDTO.Add(_mapper.Map<CommentDTO>(comment));
            }

            return listCommentDTO;
        }

        public async Task<CommentDTO> GetCommentIdAsync(int commentId)
        {
            var commentGet = await _commentRepository.GetCommentByIdAsync(commentId).ConfigureAwait(false);
            return _mapper.Map<CommentDTO>(commentGet);

        }

        /// <summary>
        /// Cette méthode permet de créer une unité de mesure.
        /// </summary>
        /// <param name="unity">L'unité à créer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il existe déjà une unité de mesure du même nom !!</exception>
        public async Task<CommentDTO> CreateCommentAsync(CommentDTO comment)
        {
            var isExiste = await CheckCommentTitleExisteAsync(comment.CommentTitle).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà un commentaire identitique !!");

            var commentToAdd = _mapper.Map<Comment>(comment);

            var commentAdded = await _commentRepository.CreateCommentAsync(commentToAdd).ConfigureAwait(false);

            return _mapper.Map<CommentDTO>(commentAdded);
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
        public async Task<CommentDTO> UpdateCommentAsync(int commentId, CommentDTO comment)
        {
            var isExiste = await CheckCommentTitleExisteAsync(comment.CommentTitle).ConfigureAwait(false);
            if (isExiste)
                throw new Exception("Il existe déjà un commentaire identitique !");

            var commentGet = await _commentRepository.GetCommentByIdAsync(commentId).ConfigureAwait(false);
            if (commentGet == null)
                throw new Exception($"Il existe déjà un commentaire id : {commentId}");

            commentGet.CommentTitle = comment.CommentTitle;
            var commentUpdated = await _commentRepository.UpdateCommentAsync(commentGet).ConfigureAwait(false);

            return _mapper.Map<CommentDTO>(commentUpdated);

        }

        /// <summary>
        /// Cette méthode permet de supprimer une unité de mesure.
        /// </summary>
        /// <param name="commentId">L'identifiant de l'unité à supprimer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Il n'existe aucune unité de mesure avec cet identifiant : {idUnite}</exception>
        public async Task<CommentDTO> DeleteCommentAsync(int commentId)
        {
            var commentGet = await _commentRepository.GetCommentByIdAsync(commentId).ConfigureAwait(false);
            if (commentGet == null)
                throw new Exception($"Il n'existe aucune unité de mesure avec cet identifiant : {commentId}");

            var commentDeleted = await _commentRepository.DeleteCommentAsync(commentGet).ConfigureAwait(false);

            return _mapper.Map<CommentDTO>(commentDeleted);
        }

        /// <summary>
        /// Cette méthode permet de vérifier si une unité existe déjà avec le même nom.
        /// </summary>
        /// <param name="commentName">le nom de l'unité.</param>
        private async Task<bool> CheckCommentTitleExisteAsync(string commentTitle)
        {
            var commentGet = await _commentRepository.GetCommentByTitleAsync(commentTitle).ConfigureAwait(false);

            return commentGet != null;
        }
    }
}