using ConvertMe.MVVM.Views;
using Microsoft.Extensions.DependencyInjection;

namespace ConvertMe;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new NavigationPage(new MenuView()));
	}
}