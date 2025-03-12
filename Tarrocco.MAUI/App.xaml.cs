using Tarrocco.MAUI.ViewModels;
using System.Diagnostics;

namespace Tarrocco.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            CardPageViewModel cardPageInstance = CardPageViewModel.CPVM(); //Instasiera kortsidan så att den laddar snabbare i applikationen
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}