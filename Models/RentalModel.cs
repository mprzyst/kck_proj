
using System;

public class RentalModel
{
    private DateTime startDate;
    private DateTime endDate;
    private CarModel car;
    private String clientName;
    private String clientSurname;
    private Boolean isReturned;
    private Boolean isLate;
    private Boolean insurance;
    private double fine;

    public RentalModel(DateTime startDate, DateTime endDate, CarModel car, String clientName, String clientSurname, Boolean isReturned, Boolean isLate, Boolean insurance, int fine)
    {
        this.startDate = startDate;
        this.endDate = endDate;
        this.car = car;
        this.clientName = clientName;
        this.clientSurname = clientSurname;
        this.isReturned = isReturned;
        this.isLate = isLate;
        this.insurance = insurance;
        this.fine = fine;
    }

    public double GetFinalPrice()
    {
        int duration = CalculateDuration(this.startDate, this.endDate);
        if(this.insurance)
        {
            var totalPrice = duration * this.car.GetPricePerDay() + this.car.GetClass().GetInsuranceAmount();
            return totalPrice;
        }
        return duration * this.car.GetPricePerDay();
        
    }

    public Boolean GetIfInsurance()
    {
        return this.insurance;
    }


    public String GetClientName()
    {
        return this.clientName;
    }

    public String GetClientSurname()
    {
        return this.clientSurname;
    }

    public double GetFine()
    {
        var fine = this.fine;
        var lateDays = CalculateDuration(this.endDate, DateTime.Now);

        return lateDays*fine;
    }

    public void SetReturned()
    {
        this.isReturned = true;

    }

    public int CalculateDuration(DateTime startDate, DateTime endDate)
    {
        return (endDate - startDate).Days;
    }

    public DateTime GetStartDate()
    {
        return this.startDate;
    }
    public DateTime GetEndDate()
    {
        return this.endDate;
    }

    public CarModel GetCar()
    {
        return this.car;
    }

    public Boolean GetIsReturned()
    {
        return this.isReturned;
    }

    public override string ToString() => $"{this.car.GetBrand()} {this.startDate.Year}-{this.startDate.Month}-{this.startDate.Day} / {this.endDate.Year}-{this.endDate.Month}-{this.endDate.Day}";

}
