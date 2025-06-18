using MauiTestApp.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiTestApp.ViewModel
{
    public class MainPageViewModel
    {
        private readonly IAuthService _authService;

        public MainPageViewModel(IAuthService authService)
        {
            _authService = authService;
            LoginCommand = new Command(async () => await LoginAsync());
        }

        public ICommand LoginCommand { get; }

        private async Task LoginAsync()
        {
            var result = await _authService.LoginAsync();
            if (result.IsError)
            {
                // Handle login error, e.g., logging or other error handling
            }
            else
            {
                // Handle successful login, e.g., navigate to another page
            }
        }
    }
}
