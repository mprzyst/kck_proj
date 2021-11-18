

using System.Collections.Generic;

public class CarRentalModel
{
    private List<CarModel> cars = new List<CarModel>();
    private List<RentalModel> rentals = new List<RentalModel>();
    private List<RentalModel> lateRentals = new List<RentalModel>();
    private List<RentalModel> rentalsHistory = new List<RentalModel>();

    

    public void AddRental(RentalModel rental)
    {
        //take care of all exceptions
        rentals.Add(rental);
    }
    public void ReturnRental(RentalModel rental)
    {
        //co z late rentals -> powinno byc cos jak sprawdz czy nie late, zaplac kare
        rentals.Remove(rental);
    }
    public void AddCar(CarModel car)
    {
        cars.Add(car);
    }
    public void RemoveCar(CarModel car)
    {
        //co z wypozyczeniami, ktore istnialy dla tego samochodu?
        /*
        chyba dobrze byloby wstawic tu "czy na pewno chcesz usunac? wszystkie rentals beda usuniete"
         */
        cars.Remove(car);
    }

    public void PrintAllCars()
    {

    }

    public void PrintAllRentals()
    {
    }

    public void PrintAllLateRentals() { }
}
