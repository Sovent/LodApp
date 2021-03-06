﻿using System;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginScreen : ContentPage, IView<LoginScreenViewModel>
	{
		public LoginScreen()
		{
			InitializeComponent ();
		}

		public LoginScreenViewModel ViewModel
		{
			get => _viewModel;
			set
			{
				_viewModel = value;
				BindingContext = value;
			} 
		}

		private async void LoginClicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(_viewModel.Email))
			{
				await DisplayAlert("Проблема входа", "Заполните email", "Ок");
				return;
			}
			if (string.IsNullOrEmpty(_viewModel.Password))
			{
				await DisplayAlert("Проблема входа", "Заполните пароль", "Ок");
				return;
			}

			ServerRequestIndicator.IsRunning = true;
			try
			{
				var authenticated = await _viewModel.AuthenticateAsync();
				if (!authenticated)
				{
					await DisplayAlert("Неуспешно", $"Не удалось войти, проверьте введённые данные", "Ок");
				}
			}
			catch (Exception exception)
			{
				await DisplayAlert("Неуспешно", $"Что-то пошло не так {exception.Message}", "Ок");
			}

			ServerRequestIndicator.IsRunning = false;
		}

		private LoginScreenViewModel _viewModel;
	}
}