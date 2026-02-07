using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using UnitsNet;

namespace ConvertMe.MVVM.ViewModels;

public partial class ConverterViewModel : ObservableObject
{
    [ObservableProperty]
    private string quantityName = "Length";

    [ObservableProperty]
    private ObservableCollection<string> fromMeasures;

    [ObservableProperty]
    private ObservableCollection<string> toMeasures;

    [ObservableProperty]
    private string currentFromMeasure = "Meter";

    [ObservableProperty]
    private string currentToMeasure = "Centimeter";

    [ObservableProperty]
    private double fromValue = 1;

    [ObservableProperty]
    private double toValue;

    private bool isUpdatingMeasures;

    private ICommand ReturnCommand => new Command(() =>
    {
        Convert();
    });

    public ConverterViewModel(string quantityName)
    {
        QuantityName = quantityName;
        FromMeasures = LoadMeasures();
        ToMeasures = LoadMeasures();
        CurrentFromMeasure = FromMeasures.FirstOrDefault() ?? CurrentFromMeasure;
        CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault() ?? CurrentToMeasure;
        Convert();
    }

    public void Convert()
    {
        var result = UnitConverter
            .ConvertByName(
                FromValue,
                QuantityName,
                CurrentFromMeasure,
                CurrentToMeasure
            );
        ToValue = result;
    }

    partial void OnFromValueChanged(double value)
    {
        Convert();
    }

    partial void OnCurrentFromMeasureChanged(string value)
    {
        if (isUpdatingMeasures)
        {
            return;
        }
        Convert();
    }

    partial void OnCurrentToMeasureChanged(string value)
    {
        if (isUpdatingMeasures)
        {
            return;
        }
        Convert();
    }

    partial void OnQuantityNameChanged(string value)
    {
        isUpdatingMeasures = true;
        FromMeasures = LoadMeasures();
        ToMeasures = LoadMeasures();

        CurrentFromMeasure = FromMeasures.FirstOrDefault() ?? CurrentFromMeasure;
        CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault() ?? CurrentFromMeasure;

        isUpdatingMeasures = false;
        Convert();
    }

    private ObservableCollection<string> LoadMeasures()
    {
        var types = Quantity
            .Infos
            .FirstOrDefault(q => q.Name == QuantityName)
            .UnitInfos
            .Select(u => u.Name)
            .ToList();

        return new ObservableCollection<string>(types);
    }
}
