using Tarrocco.MAUI.AI;
using Tarrocco.MAUI.ViewModels;

namespace Tarrocco.MAUI;

public partial class App : Application
{
    private GemeniStartup Startup = new GemeniStartup();
    public static ServiceCollection Services { get; } = new ServiceCollection();
    public static ServiceProvider ServiceProvider { get; }

    public App()
    {
        Startup.ConfigureServices(Services);

        InitializeComponent();
        CardPageViewModel cardPageInstance = CardPageViewModel.CPVM(); //Instasiera kortsidan så att den laddar snabbare i applikationen
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
