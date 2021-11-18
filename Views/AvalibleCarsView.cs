using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using NStack;
using Terminal.Gui;
using ReactiveMarbles.ObservableEvents;
using System.Collections.Generic;
using System;

namespace ReactiveExample
{
    public class AvalibleCarsView : Window, IViewFor<AvalibleCarsController>
    {
        private static FrameView _topPane;
        private static FrameView _leftPane;
        private static FrameView _rightPane;
        private static List<CarModel> _cars;
        private static List<RentalModel> _rentals;
        private static ListView _carsListView;
		private static CarModel _selectedCar;
		private static Label _selectedCarId;
        private static Label _selectedCarBrand;
        private static Label _selectedCarName;
        private static Label _selectedCarYear;
        private static Label _selectedCarAge;
        private static Label _selectedCarTypeOfBody;
        private static Label _selectedCarEnginePower;
        private static Label _selectedCarClassDeposit;
        private static Label _selectedCarClassInsurance;
        private static Label _selectedCarPricePerDay;
        private static Label _selectedCarTotalPrice;
        private static TextField _fromTextField;
        private static TextField _toTextField;



        private static int _carsListViewItem;

        readonly CompositeDisposable _disposable = new CompositeDisposable();
        public AvalibleCarsView(AvalibleCarsController controller)
        {
            var dataService = DataService.GetInstance();

            ViewModel = controller;
            _cars = new List<CarModel>(dataService.GetCarList());
            _rentals = new List<RentalModel>(dataService.GetRentalList());

            var returnLabel = new Label("Return (Ctrl+Q)"){
                X = 0,
                Y = 0,
                Width = 80
            };

            _topPane = new FrameView("Filters")
            {
                X = 0,
                Y = 3,
                Width = Dim.Fill(),
                Height = 8,
                CanFocus = false,
                Shortcut = Key.CtrlMask | Key.W
            };

            _topPane.Title = $"{_topPane.Title} ({_topPane.ShortcutTag})";
            _topPane.ShortcutAction = () => _topPane.SetFocus();

            var info = new Label("If you do not choose the dates, all cars will be displayed.")
            {
                X = 0,
                Y = 0,
                Width = 80
            };

            var formLabel = new Label("Start date:") { 
                X = 20 , 
                Y = 2
            };
            var _fromTextField = new TextField() { 
                X = 20, 
                Y = 3,
                Width = 12
            };

            var toLabel = new Label("End date:") {
                X = 60, 
                Y = 2 
            };
            var _toTextField = new TextField() {
                X = 60, 
                Y = 3,
                Width = 12
            };
            
            var filterButton = new Button("Search") {
                X = 80, 
                Y = 1,
                Width = 10
            };


            _topPane.Add(info);
            _topPane.Add(formLabel);
            _topPane.Add(_fromTextField);
            _topPane.Add(toLabel);
            _topPane.Add(_toTextField);
            _topPane.Add(filterButton);

            filterButton.Clicked += () => {
                _leftPane.Remove(_carsListView);

                var filteredCars = _cars;
                var filteredRentedRentals = _rentals;

                DateTime startDate = DateTime.Parse("1005-05-05");
                try
                {
                    startDate = DateTime.Parse(_fromTextField.Text.ToString());
                }
                catch { }

                DateTime endDate = DateTime.Parse("1005-05-05");
                try
                {
                    endDate = DateTime.Parse(_toTextField.Text.ToString());
                }
                catch { }

                if (!startDate.Year.ToString().Equals("1005") && !endDate.Year.ToString().Equals("1005")) {
                    filteredCars = new List<CarModel>(_cars);
            _topPane.Add(_toTextField);

                    filteredRentedRentals = filteredRentedRentals.FindAll(rental =>
                    {
                        if (DateTime.Compare(rental.GetStartDate(), startDate) > 0
                        && DateTime.Compare(rental.GetEndDate(), endDate) < 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });
                    filteredRentedRentals.ForEach(rental =>
                    {
                        var foundIndex = -1;
                        for (int i = 0; i < filteredCars.Count; i++) {
                            if (foundIndex == -1)
                            {

                                if (filteredCars[i].GetId() == rental.GetCar().GetId())
                                {
                                    foundIndex = i;
                                }
                            }
                        }
                        if (foundIndex != -1)
                        {
                            filteredCars.RemoveAt(foundIndex);
                        }
                    });
                }


                _carsListView = new ListView(filteredCars)
                {
                    X = 0,
                    Y = 0,
                    Width = Dim.Fill(0),
                    Height = Dim.Fill(0),
                    AllowsMarking = false,
                    CanFocus = true,
                };

                _carsListView.OpenSelectedItem += (a) => {
                    _rightPane.SetFocus();
                };
                _carsListView.SelectedItemChanged += CarsListView_SelectedChanged;
                _leftPane.Add(_carsListView);
            };
          

            _leftPane = new FrameView("Cars")
            {
                X = 0,
                Y = 11,
                Width = 35,
                Height = Dim.Fill(1),
                CanFocus = false,
                Shortcut = Key.CtrlMask | Key.A
            };
            _leftPane.Title = $"{_leftPane.Title} ({_leftPane.ShortcutTag})";
            _leftPane.ShortcutAction = () => _leftPane.SetFocus();

            _carsListView = new ListView(_cars)
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(0),
                Height = Dim.Fill(0),
                AllowsMarking = false,
                CanFocus = true,
            };

            _carsListView.OpenSelectedItem += (a) => {
                _rightPane.SetFocus();
            };
            _carsListView.SelectedItemChanged += CarsListView_SelectedChanged;
			_leftPane.Add (_carsListView);

            _rightPane = new FrameView("Details")
            {
                X = 35,
                Y = 11,
                Width = Dim.Fill(),
                Height = Dim.Fill(1),
                CanFocus = true,
                Shortcut = Key.CtrlMask | Key.D
            };
            _rightPane.Title = $"{_rightPane.Title} ({_rightPane.ShortcutTag})";

            var labelId = new Label("Car Id:")
            {
                X = 0,
                Y = 0,
                Width = 20
            };
            _selectedCarId = new Label("")
            {
                X = 20,
                Y = 0,
                Width = 20
            };
            var labelBrand = new Label("Brand:")
            {
                X = 0,
                Y = 1,
                Width = 20
            };
            _selectedCarBrand = new Label("")
            {
                X = 20,
                Y = 1,
                Width = 20
            };
            var labelName = new Label("Name:")
            {
                X = 0,
                Y = 2,
                Width = 20
            };
            _selectedCarName = new Label("")
            {
                X = 20,
                Y = 2,
                Width = 20
            };
            var labelYear = new Label("Year:")
            {
                X = 0,
                Y = 3,
                Width = 20
            };
            _selectedCarYear = new Label("")
            {
                X = 20,
                Y = 3,
                Width = 20
            };
            var labelAge = new Label("Age:")
            {
                X = 0,
                Y = 4,
                Width = 20
            };
            _selectedCarAge = new Label("")
            {
                X = 20,
                Y = 4,
                Width = 20
            };
            var labelTypeOfBody = new Label("Type of body:")
            {
                X = 0,
                Y = 5,
                Width = 20
            };
            _selectedCarTypeOfBody = new Label("")
            {
                X = 20,
                Y = 5,
                Width = 20
            };
            var labelEnginePower = new Label("Engine power:")
            {
                X = 0,
                Y = 6,
                Width = 20
            };
            _selectedCarEnginePower = new Label("")
            {
                X = 20,
                Y = 6,
                Width = 20
            };
            var labelCarDeposit = new Label("Deposit value:")
            {
                X = 0,
                Y = 7,
                Width = 20
            };
            _selectedCarClassDeposit = new Label("")
            {
                X = 20,
                Y = 7,
                Width = 20
            };
            var labelCarInsurance = new Label("Insurance value:")
            {
                X = 0,
                Y = 8,
                Width = 20
            };
            _selectedCarClassInsurance = new Label("")
            {
                X = 20,
                Y = 8,
                Width = 20
            };
            var labelPricePerDay = new Label("Price per day:")
            {
                X = 0,
                Y = 9,
                Width = 20
            };
            _selectedCarPricePerDay = new Label("")
            {
                X = 20,
                Y = 9,
                Width = 20
            };
            var labelTotalPrice = new Label("Total price:")
            {
                X = 0,
                Y = 11,
                Width = 20
            };
            _selectedCarTotalPrice = new Label("")
            {
                X = 20,
                Y = 11,
                Width = 20
            };

            _rightPane.Add(labelId);
            _rightPane.Add(_selectedCarId);
            _rightPane.Add(labelBrand);
            _rightPane.Add(_selectedCarBrand);
            _rightPane.Add(labelName);
            _rightPane.Add(_selectedCarName);
            _rightPane.Add(labelYear);
            _rightPane.Add(_selectedCarYear);
            _rightPane.Add(labelAge);
            _rightPane.Add(_selectedCarAge);
            _rightPane.Add(labelTypeOfBody);
            _rightPane.Add(_selectedCarTypeOfBody);
            _rightPane.Add(labelEnginePower);
           _rightPane.Add(_selectedCarEnginePower);
            _rightPane.Add(labelCarDeposit);
            _rightPane.Add(_selectedCarClassDeposit);
            _rightPane.Add(labelCarInsurance);
            _rightPane.Add(_selectedCarClassInsurance);
            _rightPane.Add(labelPricePerDay);
            _rightPane.Add(_selectedCarPricePerDay);
/*            _rightPane.Add(labelTotalPrice);
            _rightPane.Add(_selectedCarTotalPrice);*/

            Add(returnLabel);
            Add(_topPane);
            Add(_leftPane);
            Add(_rightPane);

        }
        public AvalibleCarsController ViewModel { get; set; }


        public static double TotalPrice(TextField start, TextField end)
        {
            try
            {
                DateTime from = DateTime.Parse(start.ToString());
                DateTime to = DateTime.Parse(end.ToString());
                int duration = (to - from).Days;
                double totalPrice = _selectedCar.GetPricePerDay() * duration;
                return totalPrice;
            }
            catch
            {
                return 0;
            }
            
        }

        private static void CarsListView_SelectedChanged(ListViewItemEventArgs e)
        {

            _carsListViewItem = _carsListView.SelectedItem;
            _selectedCar = _cars[_carsListView.SelectedItem];
            _selectedCarId.Clear();
            _selectedCarBrand.Clear();
            _selectedCarName.Clear();
            _selectedCarYear.Clear();
            _selectedCarAge.Clear();
            _selectedCarTypeOfBody.Clear();
            _selectedCarEnginePower.Clear();
            _selectedCarClassDeposit.Clear();
            _selectedCarClassInsurance.Clear();
            _selectedCarPricePerDay.Clear();
            _selectedCarTotalPrice.Clear();

            _selectedCarId.Text = _selectedCar.GetId().ToString();
            _selectedCarBrand.Text = _selectedCar.GetBrand();
            _selectedCarName.Text = _selectedCar.GetName();
            _selectedCarYear.Text = _selectedCar.GetYear().ToString();
            _selectedCarAge.Text = _selectedCar.GetAge().ToString();
            _selectedCarTypeOfBody.Text = _selectedCar.GetTypeOfBody();
            _selectedCarEnginePower.Text = _selectedCar.GetEnginePower().ToString();
            _selectedCarClassDeposit.Text = _selectedCar.GetClass().GetDepositAmount().ToString();
            _selectedCarClassInsurance.Text = _selectedCar.GetClass().GetInsuranceAmount().ToString();
            _selectedCarPricePerDay.Text = _selectedCar.GetPricePerDay().ToString();
            var price = TotalPrice(_fromTextField, _toTextField).ToString();
            _selectedCarTotalPrice.Text = price;


        }

        protected override void Dispose(bool disposing)
        {
            _disposable.Dispose();
            base.Dispose(disposing);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (AvalibleCarsController)value;
        }
    }
}
