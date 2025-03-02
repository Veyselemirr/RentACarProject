namespace RentACarDomain.Entities;

public class RentaCar
{
    public int RentACarId { get; set; }
    public int LocationID { get; set; }
    public Location Location { get; set; }
    public int CarID { get; set; }
    public Car Car { get; set; }
    public bool Available { get; set; }

}
