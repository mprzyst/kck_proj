using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExample
{
    class DataService
    {
        List<CarModel> carList;
        List<RentalModel> rentalList;

        private DataService() {
            this.carList = CarsMock.GetMock();
            this.rentalList = RentalsMock.GetMock();
        }

        public List<CarModel> GetCarList()
        {
            return this.carList;
        }

        public List<RentalModel> GetRentalList()
        {
            return this.rentalList;
        }

        private static DataService _instance; public static DataService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataService();
            }
            return _instance;
        }
    }
}
