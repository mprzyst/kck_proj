using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using NStack;
using Terminal.Gui;
using ReactiveMarbles.ObservableEvents;

namespace ReactiveExample {
	public class LoginView : Window, IViewFor<LoginController> {
		readonly CompositeDisposable _disposable = new CompositeDisposable();
		
		public LoginView (LoginController viewModel) : base("Reactive Extensions Example") {
			ViewModel = viewModel;
			var title = TitleLabel ();
			var usernameLabel = UsernameLabel (title);
			var usernameInput = UsernameInput (usernameLabel);
			var passwordLabel = PasswordLabel (usernameInput);
			var passwordInput = PasswordInput (passwordLabel);
			var loginButton = LoginButton (passwordInput);
			var clearButton = ClearButton (loginButton);
			LoginProgressLabel (clearButton);
		}
		
		public LoginController ViewModel { get; set; }

		protected override void Dispose (bool disposing) {
			_disposable.Dispose ();
			base.Dispose (disposing);
		}

		Label TitleLabel () {
			var label = new Label("Login Form");
			Add (label);
			return label;
		}

		TextField UsernameInput (View previous) {
			var usernameInput = new TextField (ViewModel.Username) {
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
			ViewModel
				.WhenAnyValue (x => x.Username)
				.BindTo (usernameInput, x => x.Text)
				.DisposeWith (_disposable);
			usernameInput
				.Events ()
				.TextChanged
				.Select (old => usernameInput.Text)
				.DistinctUntilChanged ()
				.BindTo (ViewModel, x => x.Username)
				.DisposeWith (_disposable);
			Add (usernameInput);
			return usernameInput;
		}

		Label UsernameLabel (View previous) {
			var usernameLabel = new Label("Login") {
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
			// ViewModel
			// 	.WhenAnyValue (x => x.UsernameLength)
			// 	.Select (length => ustring.Make ($"Username ({length} characters)"))
			// 	.BindTo (usernameLengthLabel, x => x.Text)
			// 	.DisposeWith (_disposable);
			Add (usernameLabel);
			return usernameLabel;
		}

		TextField PasswordInput (View previous) {
			var passwordInput = new TextField (ViewModel.Password) {
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
			ViewModel
				.WhenAnyValue (x => x.Password)
				.BindTo (passwordInput, x => x.Text)
				.DisposeWith (_disposable);
			passwordInput
				.Events ()
				.TextChanged
				.Select (old => passwordInput.Text)
				.DistinctUntilChanged ()
				.BindTo (ViewModel, x => x.Password)
				.DisposeWith (_disposable);
			Add (passwordInput);
			return passwordInput;
		}

		Label PasswordLabel (View previous) {
			var passwordLabel = new Label("Password") {
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
			// ViewModel
			// 	.WhenAnyValue (x => x.PasswordLength)
			// 	.Select (length => ustring.Make ($"Password ({length} characters)"))
			// 	.BindTo (passwordLengthLabel, x => x.Text)
			// 	.DisposeWith (_disposable);
			Add (passwordLabel);
			return passwordLabel;
		}


		Label LoginProgressLabel (View previous) {
			var progress = ustring.Make ("Logging in...");
			var idle = ustring.Make ("Press 'Login' to log in.");
			var loginProgressLabel = new Label(idle) {
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
			ViewModel
				.WhenAnyObservable (x => x.Login.IsExecuting)
				.Select (executing => executing ? progress : idle)
				.ObserveOn (RxApp.MainThreadScheduler)
				.BindTo (loginProgressLabel, x => x.Text)
				.DisposeWith (_disposable);
			Add (loginProgressLabel);
			return loginProgressLabel;
		}

		Button LoginButton (View previous) {
			var loginButton = new Button ("Login") {
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
	
			loginButton
				.Events ()
				.Clicked
				.InvokeCommand (ViewModel, x => x.Login)
				.DisposeWith (_disposable);
			Add (loginButton);
			return loginButton;
		}

		Button ClearButton (View previous) {
			var clearButton = new Button("Clear") {
				X = Pos.Left(previous),
				Y = Pos.Top(previous) + 1,
				Width = 40
			};
			clearButton
				.Events ()
				.Clicked
				.InvokeCommand (ViewModel, x => x.Clear)
				.DisposeWith (_disposable);
			Add (clearButton);
			return clearButton;
		}
		
		object IViewFor.ViewModel {
			get => ViewModel;
			set => ViewModel = (LoginController) value;
		}
	}
}