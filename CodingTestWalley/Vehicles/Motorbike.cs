
namespace CodingTestWalley.Vehicles;
public class Motorbike : IVehicle
{
    private const TollFreeVehicles vehicleType = TollFreeVehicles.Motorbike;
    public string GetVehicleType() => vehicleType.ToString();
};