using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Evlow_Foodies.Buisness.DTO
{
    public class PreparationDTO
    {
        public int PreparationId { get; set; }
        public int RecipeId { get; set; }
        public int PreparationEtape { get; set; }
        public string PreparationDescription { get; set; }

    }
}
