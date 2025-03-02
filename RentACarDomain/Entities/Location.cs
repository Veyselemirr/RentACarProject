namespace RentACarDomain.Entities;

public class Location
{
    public int LocationID { get; set; }
    public string Name { get; set; }
    public List<RentaCar> RentACars { get; set; }
    public List<Reservation> PickUpReservation { get; set; }
    public List<Reservation> DropOffReservation { get; set; }
}
