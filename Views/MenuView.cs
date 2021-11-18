using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using NStack;
using Terminal.Gui;
using ReactiveMarbles.ObservableEvents;

namespace ReactiveExample {
public class MenuView : Window, IViewFor<MenuController>
	{
		readonly CompositeDisposable _disposable = new CompositeDisposable();
    public MenuView (MenuController controller) :base ("Menu view")
		{
			ViewModel = controller;
			var viewAvailableCarsButton = ViewAvailableCarsButton();
			var viewRentedCarsButton = ViewRentedCarsButton(viewAvailableCarsButton);
			var viewLateRentsButton = ViewLateRentsButton(viewRentedCarsButton);
			var viewAllCarsButton = ViewAllCarsButton(viewLateRentsButton);
			var viewRentsHistoryButton = ViewRentsHistoryButton(viewAllCarsButton);
		}

		public MenuController ViewModel { get; set; }

		protected override void Dispose (bool disposing) {
			_disposable.Dispose ();
			base.Dispose (disposing);
		}

		

		Button ViewAvailableCarsButton()
		{ var viewAvailableCarsButton = new Button("View Available Cars")
		{
			Width = 40
		};
			viewAvailableCarsButton
				.Events()
				.Clicked
				.InvokeCommand(ViewModel, x => x.OpenAvailableCars)
				.DisposeWith(_disposable);
			Add(viewAvailableCarsButton);
			return viewAvailableCarsButton;
		}

		Button ViewRentedCarsButton(Button previous)
		{
			var viewRentedCarsButton = new Button("View Rented Cars")
			{
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
			viewRentedCarsButton
				.Events()
				.Clicked
				.InvokeCommand(ViewModel, x => x.OpenRentedCars)
				.DisposeWith(_disposable);
			Add(viewRentedCarsButton);
			return viewRentedCarsButton;
		}

		Button ViewLateRentsButton(Button previous)
		{
			var viewLateRentsButton = new Button("View Late Rents")
			{
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
			Add(viewLateRentsButton);
			return viewLateRentsButton;
		}

		Button ViewAllCarsButton(Button previous)
		{
			var viewAllCarsButton = new Button("Add New Car")
			{
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
			viewAllCarsButton
				.Events()
				.Clicked
				.InvokeCommand(ViewModel, x => x.OpenNewCarDialog)
				.DisposeWith(_disposable);
			Add(viewAllCarsButton);
			return viewAllCarsButton;
		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (MenuController)value;
		}

		Button ViewRentsHistoryButton(Button previous)
		{
			var viewRentsHistoryButton = new Button("View Rents History")
			{
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
			Add(viewRentsHistoryButton);
			return viewRentsHistoryButton;
		}
	}
}