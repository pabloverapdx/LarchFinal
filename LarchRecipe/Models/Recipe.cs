﻿using LarchRecipe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LarchRecipe.Models
{
    public class Recipe
    {
        private RecipesDBContext db = new RecipesDBContext();

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int Servings { get; set; }

        public string GetName()
        {
            return Name;
        }
    }

    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public int RecipeId { get; set; }

        public double SingleServing()
        {
            RecipesDBContext db = new RecipesDBContext();
            if (this.RecipeId != 0)
            {
                Recipe recipe = db.Recipe.Find(this.RecipeId);

                double singleServing = this.Amount / recipe.Servings;
                return singleServing;
            }
            else
            {
                return 0;
            }
        }
        /*I am trying to take the recipe ID that was entered and get the recipes name from that */
        
        public string GetRecipeName()
        {
            RecipesDBContext db = new RecipesDBContext();

            if (RecipeId != 0)
            {
                Recipe recipe = db.Recipe.Find(this.RecipeId);

                string recipeName = recipe.GetName();

                return recipeName;
            }
            else
            {
                return "";
            }
        }
    }

    public class RecipesDBContext : DbContext
    {
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}