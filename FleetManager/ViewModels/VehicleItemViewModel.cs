using System;
using System.Reactive;
using ReactiveUI;
using FleetManager.Models;

namespace FleetManager.ViewModels;

public class VehicleItemViewModel : ReactiveObject
{
    public Vehicle Vehicle { get; }

    public ReactiveCommand<Unit, Unit> RefuelCommand { get; }
    public ReactiveCommand<Unit, Unit> SendInRouteCommand { get; }
    public ReactiveCommand<Unit, Unit> SetAvailableCommand { get; }
    public ReactiveCommand<Unit, Unit> SetServiceCommand { get; }

    public VehicleItemViewModel(Vehicle vehicle)
    {
        Vehicle = vehicle;

        RefuelCommand = ReactiveCommand.Create(Refuel);
        SendInRouteCommand = ReactiveCommand.Create(SendInRoute);
        SetAvailableCommand = ReactiveCommand.Create(() => Vehicle.Status = VehicleStatus.Available);
        SetServiceCommand = ReactiveCommand.Create(() => Vehicle.Status = VehicleStatus.Service);
    }

    private void Refuel()
    {
        if (Vehicle.Status == VehicleStatus.InRoute)
        {
            Console.WriteLine("Pojazd jest niedostępny.");
            return;
        }

        Vehicle.FuelLevel = 100;
    }

    private void SendInRoute()
    {
        if (Vehicle.Status == VehicleStatus.Service)
        {
            Console.WriteLine("Pojazd jest w serwisie.");
            return;
        }

        if (Vehicle.FuelLevel < 15)
        {
            Console.WriteLine("Pojazd ma za mało paliwa.");
            return;
        }

        Vehicle.Status = VehicleStatus.InRoute;
    }
}