using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButDrink : MonoBehaviour
{

    public MyLinkedList<DrinkScrpit> drinkList; //연결리스트 불러오기
    public Button waterbutton;
    public Button coffeebutton;
    public Button waterdrinkbutton;
    public Button highcoffeebutton;
    public Button tansanbutton; //각각의 음료 구매 버튼
    public Text watercount;
    public Text coffeecount;
    public Text waterdrinkcount;
    public Text highcoffeecount;
    public Text tansancount; //각각의 음료 갯수 텍스트
    public Text waternotext;
    public Text coffeenotext;
    public Text waterdrinknotext;
    public Text highcoffeenotext;
    public Text tansannotext; //음료 품절 텍스트
    public Text leftmoneytext; //남은 돈 텍스트
    [SerializeField] private Text add10text;
    [SerializeField] private Text add50text;
    [SerializeField] private Text add100text;
    [SerializeField] private Text add500text;
    [SerializeField] private Text add1000text; //동전 갯수 표시 텍스트

    public void BuyItem(int price) //물건 구매 함수
    {
        if (MoneyScript.remainMoney < price) //예외처리
        {
            Debug.Log("Not enough money!");
            return;
        }

        int change = MoneyScript.remainMoney - price; //남은 돈에서 물건 가격만큼 뺀 값을 change 변수에 넣는다

        if (change < 0) //예외처리
        {
            Debug.Log("Price is greater than remainMoney!");
            return;
        }

        MoneyScript.remainMoney -= price; //남은돈을 price 만큼 빼주고

        int money1000 = change / 1000;
        change %= 1000;

        int money500 = change / 500;
        change %= 500;

        int money100 = change / 100;
        change %= 100;

        int money50 = change / 50;
        change %= 50;

        int money10 = change / 10;  //거스름돈 교환 로직

        MoneyScript.money1000count = money1000; 
        MoneyScript.money500count = money500;
        MoneyScript.money100count = money100;
        MoneyScript.money50count = money50;
        MoneyScript.money10count = money10; //MoneyScript 맴버 변수에 지역 변수를 대입하여 값을 수정
        Debug.Log("동전의 갯수 1000: " + money1000);
        Debug.Log("동전의 갯수 500: " + money500);
        Debug.Log("동전의 갯수 100: " + money100);
        Debug.Log("동전의 갯수 50: " + money50);
        Debug.Log("동전의 갯수 10: " + money10); //갯수 확인 log 창으로

        Debug.Log("Change: " + (MoneyScript.remainMoney + price) + " -> " + MoneyScript.remainMoney);
        StartCoroutine(moneyco(price));
        Debug.Log("동전의 갯수 1000: " + MoneyScript.money1000count);
        Debug.Log("동전의 갯수 500: " + MoneyScript.money500count);
        Debug.Log("동전의 갯수 100: " + MoneyScript.money100count);
        Debug.Log("동전의 갯수 50: " + MoneyScript.money50count);
        Debug.Log("동전의 갯수 10: " + MoneyScript.money10count); //log 창으로 확인
        add10text.text = MoneyScript.money10count.ToString()+"개";
        add50text.text = MoneyScript.money50count.ToString()+"개";
        add100text.text = MoneyScript.money100count.ToString()+"개";
        add500text.text = MoneyScript.money500count.ToString()+"개";
        add1000text.text = MoneyScript.money1000count.ToString()+"개"; //아이템 구매후 각각 동전 남은 갯수 텍스트로 표기
    }
    IEnumerator moneyco(int price) //계산한 금액 표기 텍스트 함수
    {
        leftmoneytext.gameObject.SetActive(true); //텍스트 활성화
        leftmoneytext.text = MoneyScript.remainMoney + price + " - " + price + " = " + MoneyScript.remainMoney;
        yield return new WaitForSeconds(2f); //함수 2초 대기
        leftmoneytext.gameObject.SetActive(false); //비활성화
    }

    private void Update()
    {
        if (MoneyScript.remainMoney >= 750) //남은돈이 750이상일때
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(true);
            highcoffeebutton.gameObject.SetActive(true);
            tansanbutton.gameObject.SetActive(true); //알맞은 버튼 오픈
        }
        else if (MoneyScript.remainMoney >= 700) //남은 돈이 700이상일때
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(true);
            highcoffeebutton.gameObject.SetActive(true);
            tansanbutton.gameObject.SetActive(false); //알맞은 버튼 오픈
        }
        else if (MoneyScript.remainMoney >= 550) //남은 돈이 550이상일때
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(true);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false); //알맞은 버튼 오픈
        }
        else if (MoneyScript.remainMoney >= 500) //남은 돈이 500이상일때
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(false);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false); //알맞은 가격의 버튼 오픈
        }
        else if (MoneyScript.remainMoney >= 450) //남은 돈이 450이상일때
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(false);
            waterdrinkbutton.gameObject.SetActive(false);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false); //알맞은 가격의 버튼 오픈
        }
        else//그마저도 돈이 없으면
        {
            waterbutton.gameObject.SetActive(false);
            coffeebutton.gameObject.SetActive(false);
            waterdrinkbutton.gameObject.SetActive(false);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false); //버튼 비활성화
        }

    }


    void Start() //연결리스트 생성
    {
        // 연결리스트 초기화
        drinkList = new MyLinkedList<DrinkScrpit>(); //동적으로 생성
        drinkList.AddLast(new DrinkScrpit("Water", 3, 450));
        drinkList.AddLast(new DrinkScrpit("Coffee", 3, 500));
        drinkList.AddLast(new DrinkScrpit("Water Drink", 3, 550));
        drinkList.AddLast(new DrinkScrpit("High Coffee", 3, 700));
        drinkList.AddLast(new DrinkScrpit("Tansan Drink", 3, 750)); //연결리스트에 음료 이름, 갯수, 가격을 추가한다.
    }
    public void BuyTansanDrink() //탄산음료를 구매하는 함수 버튼을 누를때 실행된다. 나머지 아래 함수는 다 같고 음료 종목만 다르다.
    {
        if (MoneyScript.remainMoney >= 750) //남은 돈이 750원 이상있을때만 실행
        {
            MyLinkedListNode<DrinkScrpit> node = drinkList.Head; //노드 추가
            while (node != null)
            {
                if (node.data.name == "Tansan Drink") //노드의 데이터안에 있는 이름이 tansan drink이면
                {
                    if (node.data.stock > 0) //남은 재고가 0개 이상이면
                    {
                        BuyItem(750); //구매 750원 소모
                        
                        node.data.stock--; //재고 1 감소
                        tansancount.text = "재고 : " + node.data.stock.ToString() + " 개"; //텍스트
                        Debug.Log("탄산 구매 완료");
                        Debug.Log("남은 탄산의 재고: " + node.data.stock);
                    }
                    else //재고가 없으면
                    {
                        tansannotext.text = "품절";
                        Debug.Log("탄산 재고 부족");
                    }
                    break;
                }
                node = node.Next; //다음으로
            }
        }
        else
        {
            Debug.Log("너 돈없어");
            return;
        }
    }

    public void BuyWater() //이 아래부터는 모두 동일
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

