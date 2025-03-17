using System.Diagnostics;
using Tarrocco.MAUI.Data.Repositories;
using Tarrocco.MAUI.Models;

namespace Tarrocco.MAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var sw = new Stopwatch();
        sw.Start();
        List<Card> cardListInstance = CardRepository.GetCards();
        sw.Stop();
        Debug.WriteLine(sw.Elapsed.TotalMilliseconds);
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
