using System;

public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        // Normalize common inputs and check for "USA"
        return _country?.Trim().ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        // Return with newline characters where appropriate
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}
