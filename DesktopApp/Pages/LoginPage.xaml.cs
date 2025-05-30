using System.Windows;
using System.Windows.Controls;
using Core.Repository.AuthRepository;
using DatabaseService.DBProvider;
using DatabaseService.Repository;

namespace DesktopApp.Pages;

public partial class LoginPage : UserControl
{
    private AuthRepository? _authRepository;
    private DatabaseProvider? _databaseProvider;
    public LoginPage(DatabaseProvider? databaseProvider)
    {
        InitializeComponent();
        _authRepository = new AuthRepositoryImpl(databaseProvider);
    }

    private async void OnLoginButtonClick(object sender, RoutedEventArgs e)
    {
        var login = LoginTextBox.Text;
        var password = PasswordBox.Password;
        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Please enter both login and password.");
            return;
        }
        var isLogin = await _authRepository?.LoginAsync(login, password);
        if (!isLogin)
        {
            MessageBox.Show("Login failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        else
        {
            MessageBox.Show("Login successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}