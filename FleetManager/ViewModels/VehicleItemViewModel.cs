// (ViewModel dla UserControl)

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using ReactiveUI;
using FleetManager.Models;

namespace FleetManager.ViewModels;

public class VehiclesViewModel : ReactiveObject
{
    public ObservableCollection<Vehicle> Vehicles { get; } = new();

    public VehiclesViewModel()
    {
        LoadVehicles();
    }

    private void LoadVehicles()
    {
        var json = File.ReadAllText("vehicles.json");
        var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json);

        if (vehicles is not null)
        {
            foreach (var v in vehicles)
                Vehicles.Add(v);
        }
    }
}
