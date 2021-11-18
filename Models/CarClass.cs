using System;

public class CarClass
{
    private int insuranceAmount;
    private int depositAmount;

    public CarClass(int insuranceAmount, int depositAmount)
    {
        this.insuranceAmount = insuranceAmount;
        this.depositAmount = depositAmount;
    }

    
    public int GetInsuranceAmount()
    {
        return this.insuranceAmount;
    }

    public int GetDepositAmount()
    {
        return this.depositAmount;
    }
}