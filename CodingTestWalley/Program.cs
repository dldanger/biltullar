using CodingTestWalley;
using CodingTestWalley.Vehicles;

var vehicle = new Car();

var tollCalculator = new TollCalculator();
var passTimes = new DateTime[] {
    new DateTime(2025, 4, 9, 6, 15, 0),
    new DateTime(2025, 4, 9, 6, 55, 0),
    new DateTime(2025, 4, 9, 7, 10, 0),
    new DateTime(2025, 4, 9, 8, 15, 0),
    new DateTime(2025, 4, 9, 8, 16, 0),
    new DateTime(2025, 4, 9, 8, 17, 0),
    new DateTime(2025, 4, 9, 8, 18, 0),
    new DateTime(2025, 4, 9, 12, 15, 0),
    new DateTime(2025, 4, 9, 20, 0, 0)
};
var vehicleToll = tollCalculator.GetTollFee(vehicle, passTimes);

var tollSkartorsdag = tollCalculator.GetTollFee(vehicle, [new DateTime(2025, 4, 17)]);

var otherTollCalculator = new TollCalculator();
var tollLangfredag = otherTollCalculator.GetTollFee(vehicle, [new DateTime(2025, 4, 18)]);

var tollAllHallows = tollCalculator.GetTollFee(vehicle, [new DateTime(2025, 10, 31)]);

var otherVehicle = new Car();
var otherVehiclePasstimes = new DateTime[] {
    new DateTime(2025, 4, 9, 6, 15, 0),
    new DateTime(2025, 4, 9, 8, 15, 0),
    new DateTime(2025, 4, 9, 10, 15, 0),
    new DateTime(2025, 4, 9, 12, 15, 0),
    new DateTime(2025, 4, 9, 14, 15, 0),
    new DateTime(2025, 4, 9, 16, 15, 0),
    new DateTime(2025, 4, 9, 18, 15, 0)
};
var otherVehicleToll = otherTollCalculator.GetTollFee(otherVehicle, otherVehiclePasstimes);

var motorbike = new Motorbike();
var motorbikeToll = tollCalculator.GetTollFee(motorbike, otherVehiclePasstimes);

var tollInJuly = tollCalculator.GetTollFee(vehicle, [new DateTime(2025, 7, 1)]);
var tollXmas = tollCalculator.GetTollFee(vehicle, [new DateTime(2025, 12, 24)]);
var tollSaturday = tollCalculator.GetTollFee(vehicle, [new DateTime(2025, 4, 12)]);