using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double productTotal = 0.0;
        foreach (var product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        double shipping = _customer.LivesInUSA() ? 5.0 : 35.0;

        return productTotal + shipping;
    }

    public string GetPackingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("PACKING LABEL:");
        foreach (var product in _products)
        {
            sb.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("SHIPPING LABEL:");
        sb.AppendLine(_customer.GetName());
        sb.AppendLine(_customer.GetAddress().GetFullAddress());
        return sb.ToString();
    }
}
