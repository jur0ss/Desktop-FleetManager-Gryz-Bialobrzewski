using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;


namespace FleetManager.Models;

public class Vehicle : ReactiveObject
{
    
    [Reactive] public string Name { get; set; } = string.Empty;
    
    [Reactive] public string RegNumber { get; set; } = string.Empty;
    
    private int _fuelLevel;
    public int FuelLevel
    {
        get => _fuelLevel;
        set
        {
            var clamped = Math.Clamp(value, 0, 100);
            this.RaiseAndSetIfChanged(ref _fuelLevel, clamped);
        }
    }
    
    [Reactive] public VehicleStatus Status { get; set; } = VehicleStatus.Available;

}