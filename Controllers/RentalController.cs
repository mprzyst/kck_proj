using System;
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
    [DataContract]
    public class RentalController : ReactiveObject
    {
        readonly ObservableAsPropertyHelper<ListObservable<CarModel>> _cars;
        readonly ObservableAsPropertyHelper<DateTime> _startDate;
        readonly ObservableAsPropertyHelper<DateTime> _endDate;
        //var foundCars = [];
        public RentalController()
        {

            

        }
    }
}
