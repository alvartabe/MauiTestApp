using MauiTestApp.Helpers;
using MauiTestApp.Models;
using MauiTestApp.Services;
using MauiTestApp.ViewModel;
using RestSharp;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiTestApp;
public class PayViaGooglePayMessage { }

public partial class MainPage : ContentPage
{
	int count = 0;
	private readonly MainPageViewModel _viewModel;

	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		_viewModel = vm;
		BindingContext = _viewModel;
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		// Create a new RestSharp client and request.
		//string baseUrl = "https://jsonplaceholder.typicode.com";
		string baseUrl = "http://localhost:9091";
		var client = new RestClient(baseUrl);
		var request = new RestRequest("todos/1", Method.Get);

		// Execute the request asynchronously.
		var response = await client.ExecuteAsync<TodoResponse>(request);

		if (response.IsSuccessful && response.Data != null)
		{
			// For demonstration, display an alert with the fetched title.
			await DisplayAlert("Todo Fetched", response.Data.title, "OK");
		}
		else
		{
			await DisplayAlert("Error", "Unable to fetch the todo item.", "OK");
		}
	}

	private async void OnLoginClicked(object sender, EventArgs e)
	{

		if (_viewModel.LoginCommand.CanExecute(null))
		{
			_viewModel.LoginCommand.Execute(null);
		}
	}

	private async void OnGooglePayClicked(object sender, EventArgs e)
	{
		//await Shell.Current.GoToAsync("WebViewPage");
		 WeakReferenceMessenger.Default.Send(new PayViaGooglePayMessage());
	}
}

