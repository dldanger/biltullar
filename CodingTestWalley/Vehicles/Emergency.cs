
namespace CodingTestWalley.Vehicles;
public class Emergency : IVehicle
{
    private const TollFreeVehicles vehicleType = TollFreeVehicles.Emergency;
    public string GetVehicleType() => vehicleType.ToString();
}
