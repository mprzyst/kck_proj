using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using NStack;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Terminal.Gui;

namespace ReactiveExample
{
	public class MenuController : ReactiveObject
	{
		public MenuController()
		{
			OpenAvailableCars = ReactiveCommand.Create(() => { });
			OpenAvailableCars.Subscribe(unit => {
				

				Application.Run(new AvalibleCarsView(new AvalibleCarsController()));
			});

			OpenRentedCars = ReactiveCommand.Create(() => { });
			OpenRentedCars.Subscribe(unit => {


				Application.Run(new RentalView(new RentalController()));
			});

			OpenNewCarDialog = ReactiveCommand.Create(() => { });
			OpenNewCarDialog.Subscribe(unit =>
			{
				CarModel newCar;

				

				var dialog = new Dialog("New car", 0, 0);

				var labelBrand = new Label("Brand")
				{
					X = 1,
					Y = 1,
					Width = 20
				}; ;
				var textFieldBrand = new TextField()
				{
					X = 1,
					Y = 2,
					Width = 20,
					DesiredCursorVisibility = CursorVisibility.Box
				};
				var labelName = new Label("Name")
				{
					X = 1,
					Y = 3,
					Width = 20
				};
				var textFieldName = new TextField()
				{
					X = 1,
					Y = 4,
					Width = 20
				};
				var labelYear = new Label("Year")
				{
					X = 1,
					Y = 5,
					Width = 20
				};
				var textFieldYear = new TextField()
				{
					X = 1,
					Y = 6,
					Width = 20
				};
				var labelTypeOfBody = new Label("Type of body")
				{
					X = 1,
					Y = 7,
					Width = 20
				};
				var textFieldTypeOfBody = new TextField()
				{
					X = 1,
					Y = 8,
					Width = 20
				};
				var labelEnginePower = new Label("Engine power")
				{
					X = 1,
					Y = 9,
					Width = 20
				};
				var textFieldEnginePower = new TextField()
				{
					X = 1,
					Y = 10,
					Width = 20
				};
				var labelCarClassInsurance = new Label("Value of insurance")
				{
					X = 1,
					Y = 11,
					Width = 20
				};
				var textFieldCarClassInsurance = new TextField()
				{
					X = 1,
					Y = 12,
					Width = 20
				};
				var labelCarClassDeposit = new Label("Value of deposit")
				{
					X = 1,
					Y = 13,
					Width = 20
				};
				var textFieldCarClassDeposit = new TextField()
				{
					X = 1,
					Y = 14,
					Width = 20
				};
				var labelPricePerDay = new Label("Price per day")
				{
					X = 1,
					Y = 15,
					Width = 20
				};
				var textFieldPricePerDay = new TextField()
				{
					X = 1,
					Y = 16,
					Width = 20
				};

				var saveButton = new Button("Save car")
				{
					X = 1,
					Y = 20
				};

				var labelReturn = new Label("Return (Ctrl+Q)")
				{
					X = 1,
					Y = 24
				};




				dialog.Add(labelBrand);
				dialog.Add(textFieldBrand);
				dialog.Add(labelName);
				dialog.Add(textFieldName);
				dialog.Add(labelYear);
				dialog.Add(textFieldYear);
				dialog.Add(labelTypeOfBody);
				dialog.Add(textFieldTypeOfBody);
				dialog.Add(labelEnginePower);
				dialog.Add(textFieldEnginePower);
				dialog.Add(labelCarClassInsurance);
				dialog.Add(textFieldCarClassInsurance);
				dialog.Add(labelCarClassDeposit);
				dialog.Add(textFieldCarClassDeposit);
				dialog.Add(labelPricePerDay);
				dialog.Add(textFieldPricePerDay);
				dialog.Add(labelReturn);


				dialog.Add(saveButton);


				saveButton.Clicked += () =>
				{

					newCar = new CarModel(15, textFieldBrand.Text.ToString(), textFieldName.Text.ToString(), textFieldTypeOfBody.Text.ToString(), Int32.Parse(textFieldYear.Text.ToString()), Double.Parse(textFieldEnginePower.Text.ToString()), new CarClass(Int32.Parse(textFieldCarClassInsurance.Text.ToString()), Int32.Parse(textFieldCarClassDeposit.Text.ToString())), Double.Parse(textFieldPricePerDay.Text.ToString()));
					var dataService = DataService.GetInstance();
					dataService.GetCarList().Add(newCar);
					Application.RequestStop();
				};

				Application.Run(dialog);
			});
		}
		[IgnoreDataMember]
		public ReactiveCommand<Unit, Unit> OpenAvailableCars { get; }


		[IgnoreDataMember]
		public ReactiveCommand<Unit, Unit> OpenRentedCars { get; }

		[IgnoreDataMember]
		public ReactiveCommand<Unit, Unit> OpenNewCarDialog { get; }
	}


}
