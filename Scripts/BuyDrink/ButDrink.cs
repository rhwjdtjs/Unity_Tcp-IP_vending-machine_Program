using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButDrink : MonoBehaviour
{
    NetworkManager network;
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
    [SerializeField] private Text collect10text;
    [SerializeField] private Text collect50text;
    [SerializeField] private Text collect100text;
    [SerializeField] private Text collect500text;
    [SerializeField] private Text collect1000text; //수금 텍스트
    [SerializeField] private Text collectmoney; //수금한 잔액
    [SerializeField] private Text stockwater;
    [SerializeField] private Text stockcoffee;
    [SerializeField] private Text stockwaterdrink;
    [SerializeField] private Text stockhighcoffee;
    [SerializeField] private Text stocktansan;

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
        MoneyScript.currentAdminMoney += price; //수금을 위한 돈 추가
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
        add10text.text = MoneyScript.money10count.ToString() + "개";
        add50text.text = MoneyScript.money50count.ToString() + "개";
        add100text.text = MoneyScript.money100count.ToString() + "개";
        add500text.text = MoneyScript.money500count.ToString() + "개";
        add1000text.text = MoneyScript.money1000count.ToString() + "개"; //아이템 구매후 각각 동전 남은 갯수 텍스트로 표기
        Debug.Log(MoneyScript.currentAdminMoney);
    }
    public void Collectmoney_Button() //물건 구매 함수
    {
        int change = MoneyScript.currentAdminMoney; //change에 돈을 넣는다.
        Debug.Log(change);
        if (change < 0) //예외처리
        {
            Debug.Log("Price is greater than remainMoney!");
            return;
        }
 
       int money1000 = change / 1000;
        change %= 1000;

       int money500 = change / 500;
        change %= 500;

       int money100 = change / 100;
        change %= 100;

       int money50 = change / 50;
        change %= 50;

      int money10 = change / 10;  //거스름돈 교환 로직

        MoneyScript.collectmoney1000count = money1000;
        MoneyScript.collectmoney500count = money500;
        MoneyScript.collectmoney100count = money100;
        MoneyScript.collectmoney50count = money50;
        MoneyScript.collectmoney10count = money10; //MoneyScript 맴버 변수에 지역 변수를 대입하여 값을 수정
        Debug.Log("동전의 갯수 1000: " + money1000);
        Debug.Log("동전의 갯수 500: " + money500);
        Debug.Log("동전의 갯수 100: " + money100);
        Debug.Log("동전의 갯수 50: " + money50);
        Debug.Log("동전의 갯수 10: " + money10); //갯수 확인 log 창으로

        collect10text.text = MoneyScript.collectmoney10count.ToString() + "개";
        collect50text.text = MoneyScript.collectmoney50count.ToString() + "개";
        collect100text.text = MoneyScript.collectmoney100count.ToString() + "개";
        collect500text.text = MoneyScript.collectmoney500count.ToString() + "개";
        collect1000text.text = MoneyScript.collectmoney1000count.ToString() + "개"; //아이템 구매후 각각 동전 남은 갯수 텍스트로 표기
        collectmoney.text = MoneyScript.currentAdminMoney.ToString();
        C_CollectMoney pkt = new C_CollectMoney();
        C_CollectMoney.Money pkt1 = new C_CollectMoney.Money();
        pkt1.cnt = MoneyScript.collectmoney10count;
        pkt.moneys.Add(pkt1);
        C_CollectMoney.Money pkt2 = new C_CollectMoney.Money();
        pkt2.cnt = MoneyScript.collectmoney50count;
        pkt.moneys.Add(pkt2);
        C_CollectMoney.Money pkt3 = new C_CollectMoney.Money();
        pkt3.cnt = MoneyScript.collectmoney100count;
        pkt.moneys.Add(pkt3);
        C_CollectMoney.Money pkt4 = new C_CollectMoney.Money();
        pkt4.cnt = MoneyScript.collectmoney500count;
        pkt.moneys.Add(pkt4);
        C_CollectMoney.Money pkt5 = new C_CollectMoney.Money();
        pkt5.cnt = MoneyScript.collectmoney1000count;
        pkt.moneys.Add(pkt5);
        network._session.Send(pkt.Write());

       
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
        network = FindObjectOfType<NetworkManager>();
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
                        stocktansan.text = "재고 : " + node.data.stock.ToString() + " 개";
                        Debug.Log("탄산 구매 완료");
                        Debug.Log("남은 탄산의 재고: " + node.data.stock);
                        //C_PlayerInfo pkt = new C_PlayerInfo();
                       
                        //pkt.beverage.cnt = node.data.stock;
                        //pkt.beverage.berName = node.data.name;
                        //pkt.beverage.price = node.data.price;
                        //Debug.Log(node.data.stock);
                        //Debug.Log(node.data.name);
                        //Debug.Log(node.data.price);
                        //network._session.Send(pkt.Write());
                        //Debug.Log("재고 보내기 완료");
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
                        stockwater.text = "재고 : " + node.data.stock.ToString() + " 개";

                        Debug.Log("물 구매 완료");
                        Debug.Log("남은 물의 재고: " + node.data.stock);
                        //C_PlayerInfo pkt = new C_PlayerInfo();
                        //pkt.beverages[0].cnt = node.data.stock;
                        //pkt.beverages[0].berName = node.data.name;
                        //pkt.beverages[0].price = node.data.price;
                        //Debug.Log(node.data.stock);
                        //Debug.Log(node.data.name);
                        //Debug.Log(node.data.price);
                        //network._session.Send(pkt.Write());
                        //Debug.Log("재고 보내기 완료");
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
                        stockcoffee.text = "재고 : " + node.data.stock.ToString() + " 개";
                        Debug.Log("커피 구매완료");
                        Debug.Log("남은 커피의 재고: " + node.data.stock);
                        //C_PlayerInfo pkt = new C_PlayerInfo();
                        //pkt.beverages[1].cnt = node.data.stock;
                        //pkt.beverages[1].berName = node.data.name;
                        //pkt.beverages[1].price = node.data.price;
                        //Debug.Log(node.data.stock);
                        //Debug.Log(node.data.name);
                        //Debug.Log(node.data.price);
                        //network._session.Send(pkt.Write());
                        //Debug.Log("재고 보내기 완료");
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
                        stockhighcoffee.text = "재고 : " + node.data.stock.ToString() + " 개";
                        Debug.Log("고급커피 구매완료");
                        Debug.Log("남은 고급커피의 재고: " + node.data.stock);
                        //C_PlayerInfo pkt = new C_PlayerInfo();

                        //pkt.beverage.cnt = node.data.stock;
                        //pkt.beverage.berName = node.data.name;
                        //pkt.beverage.price = node.data.price;
                        //Debug.Log(node.data.stock);
                        //Debug.Log(node.data.name);
                        //Debug.Log(node.data.price);
                        //network._session.Send(pkt.Write());
                        //Debug.Log("재고 보내기 완료");
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
                        stockwaterdrink.text = "재고 : " + node.data.stock.ToString() + " 개";
                        Debug.Log("이온음료구매완료");
                        Debug.Log("남은 이온음료의 재고: " + node.data.stock);
                        //C_PlayerInfo pkt = new C_PlayerInfo();

                        //pkt.beverage.cnt = node.data.stock;
                        //pkt.beverage.berName = node.data.name;
                        //pkt.beverage.price = node.data.price;
                        //Debug.Log(node.data.stock);
                        //Debug.Log(node.data.name);
                        //Debug.Log(node.data.price);
                        //network._session.Send(pkt.Write());
                        //Debug.Log("재고 보내기 완료");
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
    public void AddWater() //재고 충전 버튼
    {

        MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
        while (node != null)
        {
            if (node.data.name == "Water")
            {
                if (node.data.stock < 3)
                {

                    node.data.stock++;
                    watercount.text = "재고 : " + node.data.stock.ToString() + " 개";
                    stockwater.text = "재고 : " + node.data.stock.ToString() + " 개";
                    waternotext.text = "구매";
                    //C_SupBeverage pkt = new C_SupBeverage();

                    //pkt.beverage.cnt = node.data.stock;
                    //pkt.beverage.berName = node.data.name;
                    //pkt.beverage.price = node.data.price;
                    //Debug.Log(node.data.stock);
                    //Debug.Log(node.data.name);
                    //Debug.Log(node.data.price);
                    //network._session.Send(pkt.Write());
                    //Debug.Log("재고 보내기 완료");


                }
                else if (node.data.stock >= 3)
                {
                    node.data.stock = 3;
                    break;
                }
                break;
            }
            node = node.Next;

        }
    }


        public void AddCoffee()
        {

            MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
            while (node != null)
            {
                if (node.data.name == "Coffee")
                {
                    if (node.data.stock < 3)
                    {

                        node.data.stock++;
                        coffeecount.text = "재고 : " + node.data.stock.ToString() + " 개";
                        stockcoffee.text = "재고 : " + node.data.stock.ToString() + " 개";
                        coffeenotext.text = "구매";
                    //C_SupBeverage pkt = new C_SupBeverage();

                    //pkt.beverage.cnt = node.data.stock;
                    //pkt.beverage.berName = node.data.name;
                    //pkt.beverage.price = node.data.price;
                    //Debug.Log(node.data.stock);
                    //Debug.Log(node.data.name);
                    //Debug.Log(node.data.price);
                    //network._session.Send(pkt.Write());
                    //Debug.Log("재고 보내기 완료");

                }
                    else if (node.data.stock >= 3)
                    {
                        node.data.stock = 3;
                    break;
                    }
                    break;
                }
                node = node.Next;
            }

        }
    public void AddWaterDrink()
    {
        MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
        while (node != null)
        {
            if (node.data.name == "Water Drink")
            {
                if (node.data.stock < 3)
                {

                    node.data.stock++;
                    waterdrinkcount.text = "재고 : " + node.data.stock.ToString() + " 개";
                    stockwaterdrink.text = "재고 : " + node.data.stock.ToString() + " 개";
                    waterdrinknotext.text = "구매";
                    //C_SupBeverage pkt = new C_SupBeverage();

                    //pkt.beverage.cnt = node.data.stock;
                    //pkt.beverage.berName = node.data.name;
                    //pkt.beverage.price = node.data.price;
                    //Debug.Log(node.data.stock);
                    //Debug.Log(node.data.name);
                    //Debug.Log(node.data.price);
                    //network._session.Send(pkt.Write());
                    //Debug.Log("재고 보내기 완료");

                }
                else if (node.data.stock >= 3)
                {
                    node.data.stock = 3;
                    break;
                }
                break;
            }
            node = node.Next;
        }
    }
    public void AddHighCoffee()
    {
        MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
        while (node != null)
        {
            if (node.data.name == "High Coffee")
            {
                if (node.data.stock < 3)
                {

                    node.data.stock++;
                    highcoffeecount.text = "재고 : " + node.data.stock.ToString() + " 개";
                    stockhighcoffee.text = "재고 : " + node.data.stock.ToString() + " 개";
                    highcoffeenotext.text = "구매";
                    //C_SupBeverage pkt = new C_SupBeverage();

                    //pkt.beverage.cnt = node.data.stock;
                    //pkt.beverage.berName = node.data.name;
                    //pkt.beverage.price = node.data.price;
                    //Debug.Log(node.data.stock);
                    //Debug.Log(node.data.name);
                    //Debug.Log(node.data.price);
                    //network._session.Send(pkt.Write());
                    //Debug.Log("재고 보내기 완료");

                }
                else if (node.data.stock >= 3)
                {
                    node.data.stock = 3;
                    break;
                }
                break;
            }
            node = node.Next;
        }
    }
    public void AddTansanDrink() //탄산음료를 구매하는 함수 버튼을 누를때 실행된다. 나머지 아래 함수는 다 같고 음료 종목만 다르다.
    {
        MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
        while (node != null)
        {
            if (node.data.name == "Tansan Drink")
            {
                if (node.data.stock < 3)
                {

                    node.data.stock++;
                    tansancount.text = "재고 : " + node.data.stock.ToString() + " 개";
                    stocktansan.text = "재고 : " + node.data.stock.ToString() + " 개";
                    tansannotext.text = "구매";
                //    C_SupBeverage pkt = new C_SupBeverage();

                //    pkt.beverage.cnt = node.data.stock;
                //    pkt.beverage.berName = node.data.name;
               //     pkt.beverage.price = node.data.price;
                //    Debug.Log(node.data.stock);
               //     Debug.Log(node.data.name);
               //     Debug.Log(node.data.price);
                 //   network._session.Send(pkt.Write());
                //    Debug.Log("재고 보내기 완료");

                }
                else if (node.data.stock >= 3)
                {
                    node.data.stock = 3;
                    break;
                }
                break;
            }
            node = node.Next;
        }
    }

    public void CancelDrink() //음료 구매 창에서 취소 버튼을 누르면 서버와 통신을 한다. 모든 음료의 재고 이름 가격을 서버로 보냄;
    {
        MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
        C_PlayerInfo pkt = new C_PlayerInfo();
        while (node != null)
        {
            if (node.data.name == "Water")
            {
                C_PlayerInfo.Beverage pkt1 = new C_PlayerInfo.Beverage();
                pkt1.berName = node.data.name;
                pkt1.cnt = node.data.stock;
                pkt1.price = node.data.price;

             //   C_PlayerInfo pkt = new C_PlayerInfo();
                pkt.beverages.Add(pkt1);
                Debug.Log(node.data.stock);
                Debug.Log(node.data.name);
                Debug.Log(node.data.price);
            //    network._session.Send(pkt.Write());
                node = node.Next;
            }
            if (node.data.name == "Coffee")
            {
                C_PlayerInfo.Beverage pkt1 = new C_PlayerInfo.Beverage();
                pkt1.berName = node.data.name;
                pkt1.cnt = node.data.stock;
                pkt1.price = node.data.price;
                //C_PlayerInfo pkt = new C_PlayerInfo();
              //  C_PlayerInfo pkt = new C_PlayerInfo();
                pkt.beverages.Add(pkt1);
                Debug.Log(node.data.stock);
                Debug.Log(node.data.name);
                Debug.Log(node.data.price);
       //         network._session.Send(pkt.Write());
                node = node.Next;
            }
            if (node.data.name == "Water Drink")
            {
                C_PlayerInfo.Beverage pkt1 = new C_PlayerInfo.Beverage();
                pkt1.berName = node.data.name;
                pkt1.cnt = node.data.stock;
                pkt1.price = node.data.price;
                //C_PlayerInfo pkt = new C_PlayerInfo();
              //  C_PlayerInfo pkt = new C_PlayerInfo();
                pkt.beverages.Add(pkt1);
                Debug.Log(node.data.stock);
                Debug.Log(node.data.name);
                Debug.Log(node.data.price);
          //      network._session.Send(pkt.Write());
                node = node.Next;
            }
            if (node.data.name == "High Coffee")
            {
                C_PlayerInfo.Beverage pkt1 = new C_PlayerInfo.Beverage();
                pkt1.berName = node.data.name;
                pkt1.cnt = node.data.stock;
                pkt1.price = node.data.price;
                //C_PlayerInfo pkt = new C_PlayerInfo();
           //     C_PlayerInfo pkt = new C_PlayerInfo();
                pkt.beverages.Add(pkt1);
                Debug.Log(node.data.stock);
                Debug.Log(node.data.name);
                Debug.Log(node.data.price);
            //    network._session.Send(pkt.Write());
                node = node.Next;
            }
            if (node.data.name == "Tansan Drink")
            {
                C_PlayerInfo.Beverage pkt1 = new C_PlayerInfo.Beverage();
                pkt1.berName = node.data.name;
                pkt1.cnt = node.data.stock;
                pkt1.price = node.data.price;
               // 
                pkt.beverages.Add(pkt1);
                Debug.Log(node.data.stock);
                Debug.Log(node.data.name);
                Debug.Log(node.data.price);
                
                node = node.Next;
            }
            break;

        }
        
        network._session.Send(pkt.Write());
        Debug.Log("패킷 보내기 성공");
        Debug.Log("물"+pkt.beverages[0].cnt);
        Debug.Log("커피" + pkt.beverages[1].cnt);
        Debug.Log("이온" + pkt.beverages[2].cnt);
        Debug.Log("고커" + pkt.beverages[3].cnt);
        Debug.Log("탄산" + pkt.beverages[4].cnt);
    }
    public void CancelRecharge() //재고 관리창에서 취소 버튼을 누르면 서버와 통신을 한다. 모든 음료의 재고 이름 가격을 서버로 보냄;
    {
        MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
        C_SupBeverage pkt = new C_SupBeverage();
        while (node != null)
        {
            if (node.data.name == "Water")
            {
                C_SupBeverage.Beverage pkt1 = new C_SupBeverage.Beverage();
                pkt1.berName = node.data.name;
                pkt1.cnt = node.data.stock;
                pkt1.price = node.data.price;
                
                pkt.beverages.Add(pkt1);
                Debug.Log(node.data.stock);
                Debug.Log(node.data.name);
                Debug.Log(node.data.price);
               
                node = node.Next;
            }
            if (node.data.name == "Coffee")
            {
                C_SupBeverage.Beverage pkt1 = new C_SupBeverage.Beverage();
                pkt1.berName = node.data.name;
                pkt1.cnt = node.data.stock;
                pkt1.price = node.data.price;
                //C_SupBeverage pkt = new C_SupBeverage();
                pkt.beverages.Add(pkt1);
                Debug.Log(node.data.stock);
                Debug.Log(node.data.name);
                Debug.Log(node.data.price);
                //etwork._session.Send(pkt.Write());
                node = node.Next;
            }
            if (node.data.name == "Water Drink")
            {
                C_SupBeverage.Beverage pkt1 = new C_SupBeverage.Beverage();
                pkt1.berName = node.data.name;
                pkt1.cnt = node.data.stock;
                pkt1.price = node.data.price;
                //C_SupBeverage pkt = new C_SupBeverage();
                pkt.beverages.Add(pkt1);
                Debug.Log(node.data.stock);
                Debug.Log(node.data.name);
                Debug.Log(node.data.price);
                //network._session.Send(pkt.Write());
                node = node.Next;
            }
            if (node.data.name == "High Coffee")
            {
                C_SupBeverage.Beverage pkt1 = new C_SupBeverage.Beverage();
                pkt1.berName = node.data.name;
                pkt1.cnt = node.data.stock;
                pkt1.price = node.data.price;
                //C_SupBeverage pkt = new C_SupBeverage();
                pkt.beverages.Add(pkt1);
                Debug.Log(node.data.stock);
                Debug.Log(node.data.name);
                Debug.Log(node.data.price);
                //network._session.Send(pkt.Write());
                node = node.Next;
            }
            if (node.data.name == "Tansan Drink")
            {
                C_SupBeverage.Beverage pkt1 = new C_SupBeverage.Beverage();
                pkt1.berName = node.data.name;
                pkt1.cnt = node.data.stock;
                pkt1.price = node.data.price;
                //C_SupBeverage pkt = new C_SupBeverage();
                pkt.beverages.Add(pkt1);
                Debug.Log(node.data.stock);
                Debug.Log(node.data.name);
                Debug.Log(node.data.price);
                //network._session.Send(pkt.Write());
                node = node.Next;
            }
            break;
        }
        network._session.Send(pkt.Write());
    }
}

