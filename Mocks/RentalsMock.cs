using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExample
{
    public class RentalsMock
    {
        public static List<RentalModel> GetMock()
        {
            var cars = CarsMock.GetMock();

            List<RentalModel> rentals = new List<RentalModel>();

            rentals.Add(new RentalModel(new DateTime(2021, 9, 10), new DateTime(2021, 10, 10), cars[0], "Anna", "Kowalska", true, false,true, 0));
            rentals.Add(new RentalModel(new DateTime(2021, 9, 29), new DateTime(2021, 10, 10), cars[1], "Marek", "Nowak", true, false, true, 0));
            rentals.Add(new RentalModel(new DateTime(2021, 11, 12), new DateTime(2021, 11, 17), cars[2], "Adam", "Malysz", true, false, true, 0));
            rentals.Add(new RentalModel(new DateTime(2021, 11, 7), new DateTime(2021, 11, 15), cars[3], "Maria", "Kowalska", true, false, true, 0));
            rentals.Add(new RentalModel(new DateTime(2021, 11, 6), new DateTime(2021, 11, 15), cars[4], "Angelina", "Jolie", false, true, true, 0));
            rentals.Add(new RentalModel(new DateTime(2021, 11, 10), new DateTime(2021, 12, 10), cars[5], "Brad", "Pitt", false, false,true, 0));
            rentals.Add(new RentalModel(new DateTime(2021, 12, 10), new DateTime(2021, 12, 6), cars[6], "Johny", "Depp", false, false, true, 0));
            rentals.Add(new RentalModel(new DateTime(2021, 11, 9), new DateTime(2021, 11, 29), cars[7], "Leonardo", "DiCaprio", false, false, true, 0));



            return rentals;
        }
    }
}