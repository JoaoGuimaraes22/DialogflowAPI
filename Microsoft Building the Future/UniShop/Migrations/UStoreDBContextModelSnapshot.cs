﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using UStoreBot.Models;

namespace UStoreBot.Migrations
{
    [DbContext(typeof(UStoreDBContext))]
    partial class UStoreDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UStoreBot.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IndActive");

                    b.Property<double>("Total");

                    b.Property<bool>("TransactionCompleted");

                    b.Property<DateTime>("TransactionTimeStamp");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("UStoreBot.Models.CartIngredient", b =>
                {
                    b.Property<int>("CartIngredientId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CartId");

                    b.Property<int>("IngredientId");

                    b.Property<int>("Quantity");

                    b.HasKey("CartIngredientId");

                    b.HasIndex("CartId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CartIngredient");
                });

            modelBuilder.Entity("UStoreBot.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("DiscountPercentValue");

                    b.Property<int?>("IngredientId");

                    b.HasKey("DiscountId");

                    b.HasIndex("IngredientId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("UStoreBot.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("PricePerUnit");

                    b.Property<int>("Quantity");

                    b.Property<string>("QuantityUnitMeasurement");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("UStoreBot.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool>("RecipeOfTheWeek");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("UStoreBot.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeIngredientId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IngredientId");

                    b.Property<int>("Quantity");

                    b.Property<int>("RecipeId");

                    b.HasKey("RecipeIngredientId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("UStoreBot.Models.StoreRoomItem", b =>
                {
                    b.Property<int>("StoreRoomItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("IngredientId");

                    b.Property<int>("Quantity");

                    b.HasKey("StoreRoomItemId");

                    b.HasIndex("IngredientId");

                    b.ToTable("StoreRoomItems");
                });

            modelBuilder.Entity("UStoreBot.Models.CartIngredient", b =>
                {
                    b.HasOne("UStoreBot.Models.Cart", "Cart")
                        .WithMany("CartIngredients")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UStoreBot.Models.Ingredient", "Ingredient")
                        .WithMany("CartIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UStoreBot.Models.Discount", b =>
                {
                    b.HasOne("UStoreBot.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId");
                });

            modelBuilder.Entity("UStoreBot.Models.RecipeIngredient", b =>
                {
                    b.HasOne("UStoreBot.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UStoreBot.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UStoreBot.Models.StoreRoomItem", b =>
                {
                    b.HasOne("UStoreBot.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId");
                });
#pragma warning restore 612, 618
        }
    }
}
