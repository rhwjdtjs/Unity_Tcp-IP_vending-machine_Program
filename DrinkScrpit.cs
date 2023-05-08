using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DrinkScrpit
{
    public string name;
    public int stock;
    public int price;

    public DrinkScrpit(string name, int stock, int price)
    {
        this.name = name;
        this.stock = stock;
        this.price = price;
    }
}