﻿using CookBook.DAL.Entities;

namespace CookBook.DAL.Mappers;

public class IngredientAmountEntityMapper
{
    public void Map(IngredientAmountEntity existingEntity, IngredientAmountEntity newEntity)
    {
        existingEntity.RecipeId = newEntity.RecipeId;
        existingEntity.IngredientId = newEntity.IngredientId;
        existingEntity.Amount = newEntity.Amount;
        existingEntity.Unit = newEntity.Unit;
    }
}