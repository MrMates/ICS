﻿using CommunityToolkit.Mvvm.Input;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Ingredient), nameof(Ingredient))]
public partial class IngredientEditViewModel : ViewModelBase
{
    private readonly IIngredientFacade ingredientFacade;
    private readonly INavigationService navigationService;

    public IngredientDetailModel Ingredient { get; init; } = IngredientDetailModel.Empty;

    public IngredientEditViewModel(
        IIngredientFacade ingredientFacade,
        INavigationService navigationService,
        IMessengerService messengerService)
        : base(messengerService)
    {
        this.ingredientFacade = ingredientFacade;
        this.navigationService = navigationService;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await ingredientFacade.SaveAsync(Ingredient);

        messengerService.Send(new IngredientEditMessage { IngredientId = Ingredient.Id });

        navigationService.SendBackButtonPressed();
    }
}