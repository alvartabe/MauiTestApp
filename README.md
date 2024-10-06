# MauiTestApp

MauiTestApp is an example project demonstrating how to use Dependency Injection (DI) and `IdentityModel.OidcClient` for authentication in a .NET MAUI application. The project includes a simple implementation of login functionality, following the MVVM pattern, using DI to manage dependencies.

## Features

- **.NET MAUI Application**: Cross-platform mobile application built with .NET MAUI.
- **Authentication with OIDC**: Uses `IdentityModel.OidcClient` for handling OpenID Connect (OIDC) authentication.
- **Dependency Injection**: Services are managed and injected throughout the application using Microsoft's built-in DI container.
- **MVVM Pattern**: Implements the Model-View-ViewModel (MVVM) pattern for separation of concerns.

## Technologies Used

- **.NET MAUI**: Multi-platform app UI framework for building native apps.
- **IdentityModel.OidcClient**: A library to help with the OpenID Connect authentication flow.
- **Microsoft.Extensions.DependencyInjection**: Built-in DI container used to manage services.

## Project Structure

- `Services/AuthService.cs`: This service handles authentication using `IdentityModel.OidcClient`. It manages the communication with the identity server, initiating the login process, and returning the result.
  
- `ViewModel/LoginViewModel.cs`: This ViewModel contains the `LoginCommand`, which is bound to the UI button to initiate the login process. It uses `AuthService` to perform authentication.
  
- `MainPage.xaml`: This is the main page of the application, which includes a button to trigger the login.

- `Helpers/ServiceHelper.cs`: Helper to access DI services across the application without using constructor injection, for convenience.
