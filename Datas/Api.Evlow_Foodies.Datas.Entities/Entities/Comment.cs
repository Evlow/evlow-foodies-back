using System;
using System.Collections.Generic;

namespace Api.Evlow_Foodies.Datas.Entities.Entities
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? UserId { get; set; }
        public string? CommentTitle { get; set; }
        public string? CommentContent { get; set; }
        public int? RecipeId { get; set; }
        public decimal? CommentStars { get; set; }

        public virtual Recipe? Recipe { get; set; }
        public virtual User? User { get; set; }
    }
}
