using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public class PricingService
{
    public PricingDetails CalculatePrice(Apartment apartament, DateRange period)
    {
        var currency = apartament.Price.Currency;

        var priceForPeriod = new Money(
            apartament.Price.Amount * period.LengthInDays,
            currency);

        decimal percentageUpCharge = 0;

        foreach (var amenity in apartament.Amenities)
        {
            percentageUpCharge += amenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.5m,
                Amenity.AirConditioning => 0.1m,
                Amenity.Parking => 0.1m,
                _ => 0,
            };
        }

        var amenitiesUpCharge = Money.Zero(currency);
        if (percentageUpCharge > 0)
        {
            amenitiesUpCharge = new Money(
                priceForPeriod.Amount * percentageUpCharge,
                currency);
        }

        var totalPrice = Money.Zero();
        totalPrice += priceForPeriod;

        if (!apartament.CleaningFee.IsZero)
        {
            totalPrice += apartament.CleaningFee;
        }

        return new PricingDetails(priceForPeriod, apartament.CleaningFee, amenitiesUpCharge, totalPrice);
    }
}
