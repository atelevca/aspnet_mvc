using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipe.Models
{
    public class RecipeViewModel
    {
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string Cuisine { get; set; }
        public int Servings { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
    }

}