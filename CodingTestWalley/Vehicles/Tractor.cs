
namespace CodingTestWalley.Vehicles;
public class Tractor : IVehicle
{
    private const TollFreeVehicles vehicleType = TollFreeVehicles.Tractor;
    public string GetVehicleType() => vehicleType.ToString();
}

