
namespace CodingTestWalley.Vehicles;
public class Military : IVehicle
{
    private const TollFreeVehicles vehicleType = TollFreeVehicles.Military;
    public string GetVehicleType() => vehicleType.ToString();
};