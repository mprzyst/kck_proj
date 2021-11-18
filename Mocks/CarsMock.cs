using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExample
{
    public class CarsMock
    {
        public static List<CarModel> GetMock() {
            List<CarModel> cars = new List<CarModel>();
            CarClass class1 = new CarClass(1000, 200);
            CarClass class2 = new CarClass(2000, 400);
            CarClass class3 = new CarClass(3000, 600);
            CarClass class4 = new CarClass(4000, 700);
            CarClass class5 = new CarClass(5000, 900);


            cars.Add(new CarModel(001, "Opel", "Astra", "hatchback", 2003, 1.4, class3, 130));
            cars.Add(new CarModel(002, "Toyota", "Yaris", "hatchback", 2011, 1.6, class2, 150));
            cars.Add(new CarModel(003, "Audi", "A4", "hatchback", 2010, 2.0, class1, 230));
            cars.Add(new CarModel(004, "BMW", "E360", "coupe", 2000, 2.4, class1, 220));
            cars.Add(new CarModel(005, "Opel", "Insignia", "hatchback", 2020, 1.2, class1, 260));
            cars.Add(new CarModel(006, "Toyota", "Corolla", "hatchback", 2019, 1.1, class4, 150));
            cars.Add(new CarModel(007, "Ford", "CMAX", "hatchback", 2003, 1.4, class3, 180));
            cars.Add(new CarModel(008, "Ford", "Focus", "cabriolet", 1999, 1.6, class3, 110));
            cars.Add(new CarModel(009, "Honda", "Civic", "hatchback", 2001, 1.7, class2, 210));
            cars.Add(new CarModel(010, "Opel", "Astra", "hatchback", 2002, 1.1, class5, 70));


            return cars;
                }

    }
}
