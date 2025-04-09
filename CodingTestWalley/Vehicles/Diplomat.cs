
namespace CodingTestWalley.Vehicles;
public class Diplomat : IVehicle
{
    private const TollFreeVehicles vehicleType = TollFreeVehicles.Diplomat; 
    public string GetVehicleType() => vehicleType.ToString();
}

