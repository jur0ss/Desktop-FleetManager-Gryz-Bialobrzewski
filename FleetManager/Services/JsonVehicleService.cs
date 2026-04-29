using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FleetManager.Models;

namespace FleetManager.Services;

public class JsonVehicleService : IVehicleService
{
    private const string FilePath = "Data/vehicles.json";

    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        AllowTrailingCommas = true
    };

    public async Task<List<Vehicle>> LoadVehiclesAsync()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory("Data");
                await File.WriteAllTextAsync(FilePath, "[]");
                return new List<Vehicle>();
            }

            var json = await File.ReadAllTextAsync(FilePath);
            var list = JsonSerializer.Deserialize<List<Vehicle>>(json, _options);

            return list ?? new List<Vehicle>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to load vehicles: {ex.Message}");
            return new List<Vehicle>();
        }
    }

    public async Task SaveVehiclesAsync(List<Vehicle> vehicles)
    {
        try
        {
            var json = JsonSerializer.Serialize(vehicles, _options);
            await File.WriteAllTextAsync(FilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to save vehicles: {ex.Message}");
        }
    }
}