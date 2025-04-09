
namespace CodingTestWalley.Vehicles;
public class Foreign : IVehicle
{
    private const TollFreeVehicles vehicleType = TollFreeVehicles.Foreign;
    public string GetVehicleType() => vehicleType.ToString();
}
