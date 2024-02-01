﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Context.Contract;

namespace Api.Evlow_Foodies.Datas.Entities
{
    public partial class Evlow_FoodiesDBContext : DbContext, IEvlow_FoodiesDBContext
    {
        public Evlow_FoodiesDBContext()
        {
        }

        public Evlow_FoodiesDBContext(DbContextOptions<Evlow_FoodiesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Favori> Favoris { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Preparation> Preparations { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
        public virtual DbSet<Unity> Unities { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=evlow_foodies_simplon;port=3306;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.RecipeId, "recipe_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CommentContent)
                    .HasColumnType("text")
                    .HasColumnName("comment_content");

                entity.Property(e => e.CommentStars)
                    .HasPrecision(2, 1)
                    .HasColumnName("comment_stars");

                entity.Property(e => e.CommentTitle)
                    .HasMaxLength(50)
                    .HasColumnName("comment_title");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("comment_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("comment_ibfk_1");
            });

            modelBuilder.Entity<Favori>(entity =>
            {
                entity.HasKey(e => e.FavorisId)
                    .HasName("PRIMARY");

                entity.ToTable("favoris");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.RecipeId, "recipe_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.FavorisId).HasColumnName("favoris_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Favoris)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("favoris_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favoris)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("favoris_ibfk_1");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("ingredient");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.IngredientName)
                    .HasMaxLength(50)
                    .HasColumnName("ingredient_name");
            });

            modelBuilder.Entity<Preparation>(entity =>
            {
                entity.ToTable("preparation");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.RecipeId, "preparation_ibfk_1");

                entity.Property(e => e.PreparationId).HasColumnName("preparation_id");

                entity.Property(e => e.PreparationDescription)
                    .HasMaxLength(50)
                    .HasColumnName("preparation_description");

                entity.Property(e => e.PreparationEtape).HasColumnName("preparation_etape");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Preparations)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preparation_ibfk_1");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipe");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.CategoryId, "category_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.RecipeCreatedAt).HasColumnName("recipe_created_at");

                entity.Property(e => e.RecipePicture)
                    .HasMaxLength(50)
                    .HasColumnName("recipe_picture");

                entity.Property(e => e.RecipeStarNote)
                    .HasPrecision(3, 2)
                    .HasColumnName("recipe_star_note");

                entity.Property(e => e.RecipeTitle)
                    .HasMaxLength(50)
                    .HasColumnName("recipe_title");

                entity.Property(e => e.RecipeUpdatedAt).HasColumnName("recipe_updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("recipe_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("recipe_ibfk_1");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.IngredientId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("recipe_ingredient");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.IngredientId, "ingredient_id");

                entity.HasIndex(e => e.UnityId, "unity_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.RecipeIngredientQuantity)
                    .HasPrecision(10, 2)
                    .HasColumnName("recipe_ingredient_quantity");

                entity.Property(e => e.UnityId).HasColumnName("unity_id");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_ingredient_ibfk_2");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_ingredient_ibfk_1");

                entity.HasOne(d => d.Unity)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.UnityId)
                    .HasConstraintName("recipe_ingredient_ibfk_3");
            });

            modelBuilder.Entity<Unity>(entity =>
            {
                entity.ToTable("unity");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.UnityId).HasColumnName("unity_id");

                entity.Property(e => e.UnityName)
                    .HasMaxLength(50)
                    .HasColumnName("unity_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("user_firstName");

                entity.Property(e => e.UserLastName)
                    .HasMaxLength(50)
                    .HasColumnName("user_lastName");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserPseudo)
                    .HasMaxLength(50)
                    .HasColumnName("user_pseudo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
