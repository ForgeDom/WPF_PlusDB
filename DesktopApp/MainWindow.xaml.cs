using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseService.DBProvider;

namespace DesktopApp;

public partial class MainWindow : Window
{
    private DatabaseProvider _provider;
    public MainWindow()
    {
        InitializeComponent();
        var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=True;";
        _provider = new DatabaseProvider(connectionString);
        
    }
    [Obsolete("Obsolete")]
    private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await _provider.InitializeDatabaseAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            await _provider.ResetDatabaseAsync();
            await _provider.InitializeDatabaseAsync();
        }
        finally
        {
            MainWindowFrame.Navigate(new Pages.LoginPage(_provider));
        }
    }
}