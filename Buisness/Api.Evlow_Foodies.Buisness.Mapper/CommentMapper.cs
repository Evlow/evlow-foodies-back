using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;


namespace Api.Evlow_Foodies.Buisness.Mapper
{
    public static class CommentMapper
    {
        public static Comment TransformDTOToEntity(CommentDTO commentDTO)
        {
            return new Comment()
            {
                CommentTitle = commentDTO.CommentTitle,
                CommentContent = commentDTO.CommentContent,
                CommentStars = commentDTO.CommentStars
            };
        }
        public static CommentDTO TransformEntityToDTO(Comment commentEntity)
        {
            return new CommentDTO()
            {
                CommentId = commentEntity.CommentId,
                CommentTitle = commentEntity.CommentTitle,
                CommentContent = commentEntity.CommentContent,
                CommentStars = commentEntity.CommentStars
            };
        }

    }
}


