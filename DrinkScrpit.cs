using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DrinkScrpit
{
    public string name; //음료 이름
    public int stock; //음료 재고
    public int price; //음료 가격

    public DrinkScrpit(string name, int stock, int price) //생성자
    {
        this.name = name;
        this.stock = stock;
        this.price = price;
    }
}