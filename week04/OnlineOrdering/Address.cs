using System;
using System.Collections.Generic;

class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    // Method to return the full address as a string
    public string GetFullAddress()
    {
        return $"{streetAddress}\n{city}, {stateProvince}\n{country}";
    }
}