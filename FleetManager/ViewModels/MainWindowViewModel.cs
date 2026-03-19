using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using FleetManager.Models;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static readonly JsonSerializerOptions _options = new() { WriteIndented = true };
    private const string FilePath = "Data/vehicles.json";

    public ObservableCollection<Vehicle> Vehicles { get; } = [];

    public MainWindowViewModel()
    {
        Console.WriteLine(File.ReadAllText(FilePath));
        LoadVehicles();
        Console.WriteLine("Loaded vehicles: " + Vehicles.Count);
    }

    private void LoadVehicles()
    {
        if (!File.Exists(FilePath)) return;

        try
        {
            var jsonData = File.ReadAllText(FilePath);
            var list = JsonSerializer.Deserialize<List<Vehicle>>(jsonData);

            Vehicles.Clear();
            if (list == null) return;

            foreach (var vehicle in list)
            {
                Vehicles.Add(vehicle);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Loading File Error {exception}");
        }
    }
}