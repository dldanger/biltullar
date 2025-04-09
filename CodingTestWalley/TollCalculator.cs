using CodingTestWalley.Helpers;
using CodingTestWalley.Vehicles;

namespace CodingTestWalley;
public class TollCalculator
{
    /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param passTimes   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

    public int GetTollFee(IVehicle vehicle, DateTime[] passTimes)
    {
        if (IsTollFreeVehicle(vehicle))
            return 0;

        var travelHourStart = passTimes[0];

        if (TollDateHelpers.IsTollFreeDate(travelHourStart))
            return 0;

        var maxFeeDuringTravelHour = GetTimeSlotTollFee(travelHourStart);
        var totalFee = maxFeeDuringTravelHour;

        foreach (DateTime passTime in passTimes.Skip(1))
        {
            var currentFee = GetTimeSlotTollFee(passTime);

            var minutesSinceStartOfTravelHour = (passTime - travelHourStart).TotalMinutes;

            if (minutesSinceStartOfTravelHour <= 60)
            {
                if (maxFeeDuringTravelHour > currentFee)
                    continue;

                totalFee += currentFee - maxFeeDuringTravelHour;
                maxFeeDuringTravelHour = currentFee;
            }
            else
            {
                totalFee += currentFee;

                travelHourStart = passTime;
                maxFeeDuringTravelHour = currentFee;
            }

            if (totalFee > 60)
                break;
        }

        return Math.Min(totalFee, 60);
    }

    private int GetTimeSlotTollFee(DateTime passTime)
    {
        var timeOfDay = passTime.TimeOfDay;

        if (timeOfDay < new TimeSpan(6, 0, 0))
            return 0;
        if (timeOfDay < new TimeSpan(6, 30, 0))
            return 8;
        if (timeOfDay < new TimeSpan(7, 0, 0))
            return 13;
        if (timeOfDay < new TimeSpan(8, 00, 0))
            return 18;
        if (timeOfDay < new TimeSpan(8, 30, 0))
            return 13;
        if (timeOfDay < new TimeSpan(15, 0, 0))
            return 8;
        if (timeOfDay < new TimeSpan(15, 30, 0))
            return 13;
        if (timeOfDay < new TimeSpan(17, 0, 0))
            return 18;
        if (timeOfDay < new TimeSpan(18, 0, 0))
            return 13;
        if (timeOfDay < new TimeSpan(18, 30, 0))
            return 8;

        return 0;
    }

    private bool IsTollFreeVehicle(IVehicle vehicle)
    {
        if (vehicle == null)
            return false;

        var vehicleType = vehicle.GetVehicleType();
        return Enum.TryParse<TollFreeVehicles>(vehicleType, out var _);
    }
}