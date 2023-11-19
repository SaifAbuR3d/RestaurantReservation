namespace RestaurantReservation.Domain.Entities;

public record ReservationDetails(int ReservationID, int CustomerID, string CustomerFirstName, string CustomerLastName, DateTime ReservationDate, int PartySize, int RestaurantID, string RestaurantName, string RestaurantAddress);