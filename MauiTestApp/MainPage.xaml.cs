using MauiTestApp.Helpers;
using MauiTestApp.Services;
using MauiTestApp.ViewModel;

namespace MauiTestApp;

public partial class MainPage : ContentPage
{
	int count = 0;
	private readonly LoginViewModel _viewModel;

	public MainPage(LoginViewModel vm)
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

		if (_viewModel.LoginCommand.CanExecute(null))
		{
			_viewModel.LoginCommand.Execute(null);
		}
	}
}

