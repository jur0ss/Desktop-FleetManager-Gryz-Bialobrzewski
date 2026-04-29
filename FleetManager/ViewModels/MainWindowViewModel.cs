using System.Collections.ObjectModel;
using FleetManager.Models;
using FleetManager.Services;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IVehicleService _service;

    public ObservableCollection<VehicleItemViewModel> Vehicles { get; } = new();

    public MainWindowViewModel()
    {
        _service = new JsonVehicleService();
        LoadAsync();
    }

    private async void LoadAsync()
    {
        var list = await _service.LoadVehiclesAsync();

        Vehicles.Clear();
        foreach (var v in list)
            Vehicles.Add(new VehicleItemViewModel(v));
    }
}