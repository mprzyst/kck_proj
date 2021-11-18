using System;


public class CarModel
{
    private int id;
    private String brand;
    private String name;
    private String typeOfBody;
    private int year;
    private double enginePower;
    private CarClass carClass;
    private double pricePerDay;

    public CarModel(int id, String brand, String name, String typeOfBody, int year, double enginePower, CarClass carClass, double pricePerDay)
    {
        this.id = id;
        this.brand = brand;
        this.name = name;
        this.typeOfBody = typeOfBody;
        this.year = year;
        this.enginePower = enginePower;
        this.carClass = carClass;
        this.pricePerDay = pricePerDay;
    }

    public CarClass GetClass()
    {
        return this.carClass;
    }

    public double GetPricePerDay()
    {
        return pricePerDay;
    }

    public int GetId()
    {
        return this.id;
    }

    public String GetBrand()
    {
        return this.brand;
    }

    public String GetName()
    {
        return this.name;
    }

    public String GetTypeOfBody()
    {
        return this.typeOfBody;
    }

    public int GetYear()
    {
        return this.year;
    }

    public int GetAge()
    {
        return DateTime.Now.Year - this.year;
    }


    public double GetEnginePower()
    {
        return this.enginePower;
    }

    public override string ToString() => $"{this.brand} {this.name} {this.year}";

    public bool Equals(CarModel obj)
    {
        return this.GetId().Equals(obj.GetId());
    }

}