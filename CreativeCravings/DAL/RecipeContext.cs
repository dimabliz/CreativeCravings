﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CreativeCravings.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CreativeCravings.DAL
{
    public class RecipeContext : DbContext
    {

        public RecipeContext() : base("RecipeContext")
        {
        }

        // each DbSet corresponds to a database table
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredientXref> RecipeIngredientXrefs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // prevent tables from being pluralized
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // many to many relationship mapping
            /**
            modelBuilder.Entity<Recipe>()
                .HasMany(c => c.RecipeIngredientXrefs).WithMany(i => i.Ingredients)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("InstructorID")
                    .ToTable("CourseInstructor"));
            */
        }
    }
}