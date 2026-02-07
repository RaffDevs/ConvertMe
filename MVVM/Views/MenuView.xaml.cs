using ConvertMe.MVVM.ViewModels;

namespace ConvertMe.MVVM.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();

	}

    private void OnInformationTapped(object sender, TappedEventArgs e)
	{
		var conveterView = new ConverterView
		{
			BindingContext = new ConverterViewModel("Information")
		};
		Navigation.PushAsync(conveterView);
	}

    private void OnVolumeTapped(object sender, TappedEventArgs e)
	{
		var conveterView = new ConverterView
		{
			BindingContext = new ConverterViewModel("Volume")
		};
		Navigation.PushAsync(conveterView);
	}

    private void OnLengthTapped(object sender, TappedEventArgs e)
    {
        var conveterView = new ConverterView
        {
            BindingContext = new ConverterViewModel("Length")
        };
        Navigation.PushAsync(conveterView);
    }

    private void OnMassTapped(object sender, TappedEventArgs e)
	{
		var conveterView = new ConverterView
		{
			BindingContext = new ConverterViewModel("Mass")
		};
		Navigation.PushAsync(conveterView);
	}

    private void OnTemperatureTapped(object sender, TappedEventArgs e)
	{
		var conveterView = new ConverterView
		{
			BindingContext = new ConverterViewModel("Temperature")
		};
		Navigation.PushAsync(conveterView);
	}

	private void OnEnergyTapped(object sender, TappedEventArgs e)
	{
		var conveterView = new ConverterView
		{
			BindingContext = new ConverterViewModel("Energy")
		};
		Navigation.PushAsync(conveterView);
	}

	private void OnAreaTapped(object sender, TappedEventArgs e)
	{
		var conveterView = new ConverterView
		{
			BindingContext = new ConverterViewModel("Area")
		};
		Navigation.PushAsync(conveterView);
	}

	private void OnSpeedTapped(object sender, TappedEventArgs e)
	{
		var conveterView = new ConverterView
		{
			BindingContext = new ConverterViewModel("Speed")
		};
		Navigation.PushAsync(conveterView);
	}

	private void OnDurationTapped(object sender, TappedEventArgs e)
	{
		var conveterView = new ConverterView
		{
			BindingContext = new ConverterViewModel("Duration")
		};
		Navigation.PushAsync(conveterView);
	}
}
