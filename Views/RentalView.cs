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
    public class RentalView : Window, IViewFor<RentalController>
    {
        private static FrameView _leftPane;
        private static FrameView _rightPane;
        private static List<RentalModel> _rentals;
        private static ListView _rentalsListView;
        private static int _rentalsListViewItem;
		private static RentalModel _selectedRental;
		private static Label _selectedCarId;
        private static Label _selectedCarBrand;
        private static Label _selectedCarName;
        private static Label _selectedCarYear;
        private static Label _selectedCarAge;
        private static Label _selectedCarClassDeposit;
        private static Label _selectedCarClassInsurance;
        private static Label _selectedRentStartDate;
        private static Label _selectedRentEndDate;
        private static Label _selectedRentClientName;
        private static Label _selectedRentClientSurname;
        private static Label _selectedRentIsReturned;
        private static Label _selectedRentIsLate;
        private static Label _selectedCarPricePerDay;
        private static Label _selectedRentInsurance;
        private static Label _selectedRentTotalPrice;



        readonly CompositeDisposable _disposable = new CompositeDisposable();
        public RentalView(RentalController controller)
        {
            var dataService = DataService.GetInstance();

            ViewModel = controller;
            _rentals = new List<RentalModel>(dataService.GetRentalList());

            var returnLabel = new Label("Return (Ctrl+Q)"){
                X = 0,
                Y = 0,
                Width = 80
            };
          

            _leftPane = new FrameView("Rentals")
            {
                X = 0,
                Y = 2,
                Width = 35,
                Height = Dim.Fill(1),
                CanFocus = false,
                Shortcut = Key.CtrlMask | Key.A
            };
            _leftPane.Title = $"{_leftPane.Title}";
            _leftPane.ShortcutAction = () => _leftPane.SetFocus();

           _rentalsListView = new ListView(_rentals)
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(0),
                Height = Dim.Fill(0),
                AllowsMarking = false,
                CanFocus = true,
            };

            _rentalsListView.OpenSelectedItem += (a) => {
                _rightPane.SetFocus();
            };
            _rentalsListView.SelectedItemChanged += RentalsListView_SelectedChanged;
			_leftPane.Add (_rentalsListView);

            _rightPane = new FrameView("Details")
            {
                X = 35,
                Y = 2,
                Width = Dim.Fill(),
                Height = Dim.Fill(1),
                CanFocus = true,
                Shortcut = Key.CtrlMask | Key.D
            };
            _rightPane.Title = $"{_rightPane.Title}";

            var labelRentalTime = new Label("Rental time:")
            {
                X = 1,
                Y = 1,
                Width = 20
            };
            var labelRentalStart = new Label("Start  ->")
            {
                X = 1,
                Y = 2,
                Width = 20
            };
            _selectedRentStartDate = new Label("")
            {
                X = 20,
                Y = 2,
                Width = 20
            };
            var labelRentalEnd = new Label("End    ->")
            {
                X = 1,
                Y = 3,
                Width = 20
            };
            _selectedRentEndDate = new Label("")
            {
                X = 20,
                Y = 3,
                Width = 20
            };
            var clientName = new Label("Client name:")
            {
                X = 1,
                Y = 5,
                Width = 20
            };
            _selectedRentClientName = new Label("")
            {
                X = 20,
                Y = 5,
                Width = 20
            };
            var clientSurname = new Label("Client surname:")
            {
                X = 1,
                Y = 6,
                Width = 20
            };
            _selectedRentClientSurname = new Label("")
            {
                X = 20,
                Y = 6,
                Width = 20
            };
            var labelBrand = new Label("Brand:")
            {
                X = 1,
                Y = 8,
                Width = 20
            };
            _selectedCarBrand = new Label("")
            {
                X = 20,
                Y = 8,
                Width = 20
            };
            var labelName = new Label("Name:")
            {
                X = 1,
                Y = 9,
                Width = 20
            };
            _selectedCarName = new Label("")
            {
                X = 20,
                Y = 9,
                Width = 20
            };
            var labelYear = new Label("Year:")
            {
                X = 1,
                Y = 10,
                Width = 20
            };
            _selectedCarYear = new Label("")
            {
                X = 20,
                Y = 10,
                Width = 20
            };
            var labelStatus = new Label("Status:")
            {
                X = 1,
                Y = 13,
                Width = 20
            };
            _selectedRentIsReturned = new Label("")
            {
                X = 20,
                Y = 13,
                Width = 20
            };
            var labelInsurance = new Label("Insurance:")
            {
                X = 1,
                Y = 14,
                Width = 20
            };
            _selectedRentInsurance = new Label("")
            {
                X = 20,
                Y = 14,
                Width = 20
            };
            var labelCarClassInsurance = new Label("Insurance value:")
            {
                X = 1,
                Y = 15,
                Width = 20
            };
            _selectedCarClassInsurance = new Label("")
            {
                X = 20,
                Y = 15,
                Width = 20
            };
            var labelCarDeposit = new Label("Deposit value:")
            {
                X = 1,
                Y = 16,
                Width = 20
            };
            _selectedCarClassDeposit = new Label("")
            {
                X = 20,
                Y = 16,
                Width = 20
            };
            var labelPricePerDay = new Label("Price per day:")
            {
                X = 1,
                Y = 18,
                Width = 20
            };
            _selectedCarPricePerDay = new Label("")
            {
                X = 20,
                Y = 18,
                Width = 20
            };
            var labelTotalPrice = new Label("Total price:")
            {
                X = 1,
                Y = 19,
                Width = 20
            };
            _selectedRentTotalPrice = new Label("")
            {
                X = 20,
                Y = 19,
                Width = 20
            };

            _rightPane.Add(labelRentalTime);
            _rightPane.Add(labelRentalStart);
            _rightPane.Add(_selectedRentStartDate);
            _rightPane.Add(labelRentalEnd);
            _rightPane.Add(_selectedRentEndDate);
            _rightPane.Add(clientName);
            _rightPane.Add(_selectedRentClientName);
            _rightPane.Add(clientSurname);
            _rightPane.Add(_selectedRentClientSurname);
            _rightPane.Add(labelBrand);
            _rightPane.Add(_selectedCarBrand);
            _rightPane.Add(labelName);
            _rightPane.Add(_selectedCarName);
            _rightPane.Add(labelYear);
            _rightPane.Add(_selectedCarYear);
            _rightPane.Add(labelStatus);
            _rightPane.Add(_selectedRentIsReturned);
            _rightPane.Add(labelInsurance);
           _rightPane.Add(_selectedRentInsurance);
           _rightPane.Add(labelCarClassInsurance);
           _rightPane.Add(_selectedCarClassInsurance);
            _rightPane.Add(labelCarDeposit);
            _rightPane.Add(_selectedCarClassDeposit);
            _rightPane.Add(labelPricePerDay);
            _rightPane.Add(_selectedCarPricePerDay);
            _rightPane.Add(labelTotalPrice);
            _rightPane.Add(_selectedRentTotalPrice);

            Add(returnLabel);
            Add(_leftPane);
            Add(_rightPane);

        }
        public RentalController ViewModel { get; set; }



        private static void RentalsListView_SelectedChanged(ListViewItemEventArgs e)
        {

            _rentalsListViewItem = _rentalsListView.SelectedItem;
            _selectedRental = _rentals[_rentalsListView.SelectedItem];
            _selectedCarBrand.Clear();
            _selectedCarName.Clear();
            _selectedCarYear.Clear();
            _selectedRentStartDate.Clear();
            _selectedRentEndDate.Clear();
            _selectedCarClassDeposit.Clear();
            _selectedCarClassInsurance.Clear();
            _selectedCarPricePerDay.Clear();
            _selectedRentClientName.Clear();
            _selectedRentClientSurname.Clear();
            _selectedRentInsurance.Clear();
            _selectedRentIsReturned.Clear();
            _selectedRentTotalPrice.Clear();

            _selectedRentStartDate.Text = _selectedRental.GetStartDate().ToString();
            _selectedRentEndDate.Text = _selectedRental.GetEndDate().ToString();
            _selectedRentClientName.Text = _selectedRental.GetClientSurname();
            _selectedRentClientSurname.Text = _selectedRental.GetClientName();
            _selectedCarBrand.Text = _selectedRental.GetCar().GetBrand();
            _selectedCarName.Text = _selectedRental.GetCar().GetName();
            _selectedCarYear.Text = _selectedRental.GetCar().GetYear().ToString();
            if (_selectedRental.GetIsReturned() == true) { _selectedRentIsReturned.Text = "Returned"; }
            else { _selectedRentIsReturned.Text = "Not returned"; }
            if (_selectedRental.GetIfInsurance() == true) { _selectedRentInsurance.Text = "Yes"; }
            else { _selectedRentInsurance.Text = "No"; }

            _selectedCarClassInsurance.Text = _selectedRental.GetCar().GetClass().GetInsuranceAmount().ToString();
            _selectedCarClassDeposit.Text = _selectedRental.GetCar().GetClass().GetDepositAmount().ToString();
            _selectedCarPricePerDay.Text = _selectedRental.GetCar().GetPricePerDay().ToString();
            _selectedRentTotalPrice.Text = _selectedRental.GetFinalPrice().ToString();



        }

        protected override void Dispose(bool disposing)
        {
            _disposable.Dispose();
            base.Dispose(disposing);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (RentalController)value;
        }
    }
}
