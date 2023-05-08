using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButDrink : MonoBehaviour
{

    public MyLinkedList<DrinkScrpit> drinkList;
    public Button waterbutton;
    public Button coffeebutton;
    public Button waterdrinkbutton;
    public Button highcoffeebutton;
    public Button tansanbutton;
    public Text watercount;
    public Text coffeecount;
    public Text waterdrinkcount;
    public Text highcoffeecount;
    public Text tansancount;
    public Text waternotext;
    public Text coffeenotext;
    public Text waterdrinknotext;
    public Text highcoffeenotext;
    public Text tansannotext;
    public Text leftmoneytext;

    public void BuyItem(int price)
    {
        if (MoneyScript.remainMoney < price)
        {
            Debug.Log("Not enough money!");
            return;
        }

        int change = MoneyScript.remainMoney - price;

        if (change < 0)
        {
            Debug.Log("Price is greater than remainMoney!");
            return;
        }

        MoneyScript.remainMoney -= price;

        int money1000 = change / 1000;
        change %= 1000;

        int money500 = change / 500;
        change %= 500;

        int money100 = change / 100;
        change %= 100;

        int money50 = change / 50;
        change %= 50;

        int money10 = change / 10;

        MoneyScript.money1000count = money1000;
        MoneyScript.money500count = money500;
        MoneyScript.money100count = money100;
        MoneyScript.money50count = money50;
        MoneyScript.money10count = money10;
        Debug.Log("동전의 갯수 1000: " + money1000);
        Debug.Log("동전의 갯수 500: " + money500);
        Debug.Log("동전의 갯수 100: " + money100);
        Debug.Log("동전의 갯수 50: " + money50);
        Debug.Log("동전의 갯수 10: " + money10);

        Debug.Log("Change: " + (MoneyScript.remainMoney + price) + " -> " + MoneyScript.remainMoney);
        StartCoroutine(moneyco(price));
        Debug.Log("동전의 갯수 1000: " + MoneyScript.money1000count);
        Debug.Log("동전의 갯수 500: " + MoneyScript.money500count);
        Debug.Log("동전의 갯수 100: " + MoneyScript.money100count);
        Debug.Log("동전의 갯수 50: " + MoneyScript.money50count);
        Debug.Log("동전의 갯수 10: " + MoneyScript.money10count);
    }
    IEnumerator moneyco(int price)
    {
        leftmoneytext.gameObject.SetActive(true);
        leftmoneytext.text = MoneyScript.remainMoney + price + " - " + price + " = " + MoneyScript.remainMoney;
        yield return new WaitForSeconds(2f);
        leftmoneytext.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (MoneyScript.remainMoney >= 750)
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(true);
            highcoffeebutton.gameObject.SetActive(true);
            tansanbutton.gameObject.SetActive(true);
        }
        else if (MoneyScript.remainMoney >= 700)
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(true);
            highcoffeebutton.gameObject.SetActive(true);
            tansanbutton.gameObject.SetActive(false);
        }
        else if (MoneyScript.remainMoney >= 550)
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(true);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false);
        }
        else if (MoneyScript.remainMoney >= 500)
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(false);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false);
        }
        else if (MoneyScript.remainMoney >= 450)
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(false);
            waterdrinkbutton.gameObject.SetActive(false);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false);
        }
        else
        {
            waterbutton.gameObject.SetActive(false);
            coffeebutton.gameObject.SetActive(false);
            waterdrinkbutton.gameObject.SetActive(false);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false);
        }

    }


    void Start()
    {
        // 연결리스트 초기화
        drinkList = new MyLinkedList<DrinkScrpit>();
        drinkList.AddLast(new DrinkScrpit("Water", 3, 450));
        drinkList.AddLast(new DrinkScrpit("Coffee", 3, 500));
        drinkList.AddLast(new DrinkScrpit("Water Drink", 3, 550));
        drinkList.AddLast(new DrinkScrpit("High Coffee", 3, 700));
        drinkList.AddLast(new DrinkScrpit("Tansan Drink", 3, 750));
    }
    public void BuyTansanDrink()
    {
        if (MoneyScript.remainMoney >= 750)
        {
            MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
            while (node != null)
            {
                if (node.data.name == "Tansan Drink")
                {
                    if (node.data.stock > 0)
                    {
                        BuyItem(750);
                        
                        node.data.stock--;
                        tansancount.text = "재고 : " + node.data.stock.ToString() + " 개";
                        Debug.Log("탄산 구매 완료");
                        Debug.Log("남은 탄산의 재고: " + node.data.stock);
                    }
                    else
                    {
                        tansannotext.text = "품절";
                        Debug.Log("탄산 재고 부족");
                    }
                    break;
                }
                node = node.Next;
            }
        }
        else
        {
            Debug.Log("너 돈없어");
            return;
        }
    }

    public void BuyWater()
    {
        if (MoneyScript.remainMoney >= 450)
        {
            MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
            while (node != null)
            {
                if (node.data.name == "Water")
                {
                    if (node.data.stock > 0)
                    {
                        BuyItem(450);
                        node.data.stock--;
                        watercount.text = "재고 : " + node.data.stock.ToString() + " 개";

                        Debug.Log("물 구매 완료");
                        Debug.Log("남은 물의 재고: " + node.data.stock);
                    }
                    else
                    {
                        waternotext.text = "품절";
                        Debug.Log("물 재고 부족");
                    }
                    break;
                }
                node = node.Next;
            }
        }
        else
        {
            Debug.Log("너 돈 업성");
            return;
        }
    }
    public void BuyCoffee()
    {
        if (MoneyScript.remainMoney >= 500)
        {
            MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
            while (node != null)
            {
                if (node.data.name == "Coffee")
                {
                    if (node.data.stock > 0)
                    {
                        BuyItem(500);
                        node.data.stock--;
                        coffeecount.text = "재고 : " + node.data.stock.ToString() + " 개";
                        Debug.Log("커피 구매완료");
                        Debug.Log("남은 커피의 재고: " + node.data.stock);
                    }
                    else
                    {
                        coffeenotext.text = "품절";
                        Debug.Log("커피 재고 부족");
                    }
                    break;
                }
                node = node.Next;
            }
        }
        else
        {
            Debug.Log("너 돈없어");
            return;
        }
    }
    public void BuyHighCoffee()
    {
        if (MoneyScript.remainMoney >= 700)
        {
            MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
            while (node != null)
            {
                if (node.data.name == "High Coffee")
                {
                    if (node.data.stock > 0)
                    {
                        BuyItem(700);
                        node.data.stock--;
                        highcoffeecount.text = "재고 : " + node.data.stock.ToString() + " 개";
                        Debug.Log("고급커피 구매완료");
                        Debug.Log("남은 고급커피의 재고: " + node.data.stock);
                    }
                    else
                    {
                        highcoffeenotext.text = "품절";
                        Debug.Log("고급커피 재고 부족");
                    }
                    break;
                }
                node = node.Next;
            }
        }
        else
        {
            Debug.Log("너 돈없어");
            return;
        }
    }
    public void BuyWaterDrink()
    {
        if (MoneyScript.remainMoney >= 550)
        {
            MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
            while (node != null)
            {
                if (node.data.name == "Water Drink")
                {
                    if (node.data.stock > 0)
                    {
                        BuyItem(550);
                        node.data.stock--;
                        waterdrinkcount.text = "재고 : " + node.data.stock.ToString() + " 개";
                        Debug.Log("이온음료구매완료");
                        Debug.Log("남은 이온음료의 재고: " + node.data.stock);
                    }
                    else
                    {
                        waterdrinknotext.text = "품절";
                        Debug.Log("이온음료 재고 부족");
                    }
                    break;
                }
                node = node.Next;
            }
        }
        else
        {
            Debug.Log("너 돈 없어");
            return;
        }
    }
}

