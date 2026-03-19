using System.Collections.ObjectModel;
using System.Text.Json;
using FleetManager.Models;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static readonly JsonSerializerOptions _options = new() {WriteIndented = true};
    private const string FilePath = "Assets/vehicles.json";

    public ObservableCollection<Vehicle> Vehicles { get; } = [];
    
    public MainWindowViewModel()
    {}
}