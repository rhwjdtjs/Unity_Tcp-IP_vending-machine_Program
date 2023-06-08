using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButDrink : MonoBehaviour
{
    NetworkManager network;
    public MyLinkedList<DrinkScrpit> drinkList; //���Ḯ��Ʈ �ҷ�����
    public Button waterbutton;
    public Button coffeebutton;
    public Button waterdrinkbutton;
    public Button highcoffeebutton;
    public Button tansanbutton; //������ ���� ���� ��ư
    public Text watercount;
    public Text coffeecount;
    public Text waterdrinkcount;
    public Text highcoffeecount;
    public Text tansancount; //������ ���� ���� �ؽ�Ʈ
    public Text waternotext;
    public Text coffeenotext;
    public Text waterdrinknotext;
    public Text highcoffeenotext;
    public Text tansannotext; //���� ǰ�� �ؽ�Ʈ
    public Text leftmoneytext; //���� �� �ؽ�Ʈ
    [SerializeField] private Text add10text;
    [SerializeField] private Text add50text;
    [SerializeField] private Text add100text;
    [SerializeField] private Text add500text;
    [SerializeField] private Text add1000text; //���� ���� ǥ�� �ؽ�Ʈ
    [SerializeField] private Text collect10text;
    [SerializeField] private Text collect50text;
    [SerializeField] private Text collect100text;
    [SerializeField] private Text collect500text;
    [SerializeField] private Text collect1000text; //���� �ؽ�Ʈ
    [SerializeField] private Text collectmoney; //������ �ܾ�
    [SerializeField] private Text stockwater;
    [SerializeField] private Text stockcoffee;
    [SerializeField] private Text stockwaterdrink;
    [SerializeField] private Text stockhighcoffee;
    [SerializeField] private Text stocktansan;

    public void BuyItem(int price) //���� ���� �Լ�
    {
        if (MoneyScript.remainMoney < price) //����ó��
        {
            Debug.Log("Not enough money!");
            return;
        }

        int change = MoneyScript.remainMoney - price; //���� ������ ���� ���ݸ�ŭ �� ���� change ������ �ִ´�

        if (change < 0) //����ó��
        {
            Debug.Log("Price is greater than remainMoney!");
            return;
        }
        MoneyScript.currentAdminMoney += price; //������ ���� �� �߰�
        MoneyScript.remainMoney -= price; //�������� price ��ŭ ���ְ�

        int money1000 = change / 1000;
        change %= 1000;

        int money500 = change / 500;
        change %= 500;

        int money100 = change / 100;
        change %= 100;

        int money50 = change / 50;
        change %= 50;

        int money10 = change / 10;  //�Ž����� ��ȯ ����

        MoneyScript.money1000count = money1000;
        MoneyScript.money500count = money500;
        MoneyScript.money100count = money100;
        MoneyScript.money50count = money50;
        MoneyScript.money10count = money10; //MoneyScript �ɹ� ������ ���� ������ �����Ͽ� ���� ����
        Debug.Log("������ ���� 1000: " + money1000);
        Debug.Log("������ ���� 500: " + money500);
        Debug.Log("������ ���� 100: " + money100);
        Debug.Log("������ ���� 50: " + money50);
        Debug.Log("������ ���� 10: " + money10); //���� Ȯ�� log â����

        Debug.Log("Change: " + (MoneyScript.remainMoney + price) + " -> " + MoneyScript.remainMoney);
        StartCoroutine(moneyco(price));
        Debug.Log("������ ���� 1000: " + MoneyScript.money1000count);
        Debug.Log("������ ���� 500: " + MoneyScript.money500count);
        Debug.Log("������ ���� 100: " + MoneyScript.money100count);
        Debug.Log("������ ���� 50: " + MoneyScript.money50count);
        Debug.Log("������ ���� 10: " + MoneyScript.money10count); //log â���� Ȯ��
        add10text.text = MoneyScript.money10count.ToString() + "��";
        add50text.text = MoneyScript.money50count.ToString() + "��";
        add100text.text = MoneyScript.money100count.ToString() + "��";
        add500text.text = MoneyScript.money500count.ToString() + "��";
        add1000text.text = MoneyScript.money1000count.ToString() + "��"; //������ ������ ���� ���� ���� ���� �ؽ�Ʈ�� ǥ��
        Debug.Log(MoneyScript.currentAdminMoney);
    }
    public void Collectmoney_Button() //���� ���� �Լ�
    {
        int change = MoneyScript.currentAdminMoney; //change�� ���� �ִ´�.
        Debug.Log(change);
        if (change < 0) //����ó��
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

      int money10 = change / 10;  //�Ž����� ��ȯ ����

        MoneyScript.collectmoney1000count = money1000;
        MoneyScript.collectmoney500count = money500;
        MoneyScript.collectmoney100count = money100;
        MoneyScript.collectmoney50count = money50;
        MoneyScript.collectmoney10count = money10; //MoneyScript �ɹ� ������ ���� ������ �����Ͽ� ���� ����
        Debug.Log("������ ���� 1000: " + money1000);
        Debug.Log("������ ���� 500: " + money500);
        Debug.Log("������ ���� 100: " + money100);
        Debug.Log("������ ���� 50: " + money50);
        Debug.Log("������ ���� 10: " + money10); //���� Ȯ�� log â����

        collect10text.text = MoneyScript.collectmoney10count.ToString() + "��";
        collect50text.text = MoneyScript.collectmoney50count.ToString() + "��";
        collect100text.text = MoneyScript.collectmoney100count.ToString() + "��";
        collect500text.text = MoneyScript.collectmoney500count.ToString() + "��";
        collect1000text.text = MoneyScript.collectmoney1000count.ToString() + "��"; //������ ������ ���� ���� ���� ���� �ؽ�Ʈ�� ǥ��
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
    IEnumerator moneyco(int price) //����� �ݾ� ǥ�� �ؽ�Ʈ �Լ�
    {
        leftmoneytext.gameObject.SetActive(true); //�ؽ�Ʈ Ȱ��ȭ
        leftmoneytext.text = MoneyScript.remainMoney + price + " - " + price + " = " + MoneyScript.remainMoney;
        yield return new WaitForSeconds(2f); //�Լ� 2�� ���
        leftmoneytext.gameObject.SetActive(false); //��Ȱ��ȭ
    }

    private void Update()
    {
        if (MoneyScript.remainMoney >= 750) //�������� 750�̻��϶�
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(true);
            highcoffeebutton.gameObject.SetActive(true);
            tansanbutton.gameObject.SetActive(true); //�˸��� ��ư ����
        }
        else if (MoneyScript.remainMoney >= 700) //���� ���� 700�̻��϶�
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(true);
            highcoffeebutton.gameObject.SetActive(true);
            tansanbutton.gameObject.SetActive(false); //�˸��� ��ư ����
        }
        else if (MoneyScript.remainMoney >= 550) //���� ���� 550�̻��϶�
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(true);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false); //�˸��� ��ư ����
        }
        else if (MoneyScript.remainMoney >= 500) //���� ���� 500�̻��϶�
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(true);
            waterdrinkbutton.gameObject.SetActive(false);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false); //�˸��� ������ ��ư ����
        }
        else if (MoneyScript.remainMoney >= 450) //���� ���� 450�̻��϶�
        {
            waterbutton.gameObject.SetActive(true);
            coffeebutton.gameObject.SetActive(false);
            waterdrinkbutton.gameObject.SetActive(false);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false); //�˸��� ������ ��ư ����
        }
        else//�׸����� ���� ������
        {
            waterbutton.gameObject.SetActive(false);
            coffeebutton.gameObject.SetActive(false);
            waterdrinkbutton.gameObject.SetActive(false);
            highcoffeebutton.gameObject.SetActive(false);
            tansanbutton.gameObject.SetActive(false); //��ư ��Ȱ��ȭ
        }

    }


    void Start() //���Ḯ��Ʈ ����
    {
        network = FindObjectOfType<NetworkManager>();
        // ���Ḯ��Ʈ �ʱ�ȭ
        drinkList = new MyLinkedList<DrinkScrpit>(); //�������� ����
        drinkList.AddLast(new DrinkScrpit("Water", 3, 450));
        drinkList.AddLast(new DrinkScrpit("Coffee", 3, 500));
        drinkList.AddLast(new DrinkScrpit("Water Drink", 3, 550));
        drinkList.AddLast(new DrinkScrpit("High Coffee", 3, 700));
        drinkList.AddLast(new DrinkScrpit("Tansan Drink", 3, 750)); //���Ḯ��Ʈ�� ���� �̸�, ����, ������ �߰��Ѵ�.
    }
    public void BuyTansanDrink() //ź�����Ḧ �����ϴ� �Լ� ��ư�� ������ ����ȴ�. ������ �Ʒ� �Լ��� �� ���� ���� ���� �ٸ���.
    {
        if (MoneyScript.remainMoney >= 750) //���� ���� 750�� �̻��������� ����
        {
            MyLinkedListNode<DrinkScrpit> node = drinkList.Head; //��� �߰�
            while (node != null)
            {
                if (node.data.name == "Tansan Drink") //����� �����;ȿ� �ִ� �̸��� tansan drink�̸�
                {
                    if (node.data.stock > 0) //���� ��� 0�� �̻��̸�
                    {
                        BuyItem(750); //���� 750�� �Ҹ�

                        node.data.stock--; //��� 1 ����
                        tansancount.text = "��� : " + node.data.stock.ToString() + " ��"; //�ؽ�Ʈ
                        stocktansan.text = "��� : " + node.data.stock.ToString() + " ��";
                        Debug.Log("ź�� ���� �Ϸ�");
                        Debug.Log("���� ź���� ���: " + node.data.stock);
                        //C_PlayerInfo pkt = new C_PlayerInfo();
                       
                        //pkt.beverage.cnt = node.data.stock;
                        //pkt.beverage.berName = node.data.name;
                        //pkt.beverage.price = node.data.price;
                        //Debug.Log(node.data.stock);
                        //Debug.Log(node.data.name);
                        //Debug.Log(node.data.price);
                        //network._session.Send(pkt.Write());
                        //Debug.Log("��� ������ �Ϸ�");
                    }
                    else //��� ������
                    {
                        tansannotext.text = "ǰ��";
                        Debug.Log("ź�� ��� ����");
                    }
                    break;
                }
                node = node.Next; //��������
            }
        }
        else
        {
            Debug.Log("�� ������");
            return;
        }
    }

    public void BuyWater() //�� �Ʒ����ʹ� ��� ����
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
                        watercount.text = "��� : " + node.data.stock.ToString() + " ��";
                        stockwater.text = "��� : " + node.data.stock.ToString() + " ��";

                        Debug.Log("�� ���� �Ϸ�");
                        Debug.Log("���� ���� ���: " + node.data.stock);
                        //C_PlayerInfo pkt = new C_PlayerInfo();
                        //pkt.beverages[0].cnt = node.data.stock;
                        //pkt.beverages[0].berName = node.data.name;
                        //pkt.beverages[0].price = node.data.price;
                        //Debug.Log(node.data.stock);
                        //Debug.Log(node.data.name);
                        //Debug.Log(node.data.price);
                        //network._session.Send(pkt.Write());
                        //Debug.Log("��� ������ �Ϸ�");
                    }
                    else
                    {
                        waternotext.text = "ǰ��";
                        Debug.Log("�� ��� ����");
                    }
                    break;
                }
                node = node.Next;
            }
        }
        else
        {
            Debug.Log("�� �� ����");
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
                        coffeecount.text = "��� : " + node.data.stock.ToString() + " ��";
                        stockcoffee.text = "��� : " + node.data.stock.ToString() + " ��";
                        Debug.Log("Ŀ�� ���ſϷ�");
                        Debug.Log("���� Ŀ���� ���: " + node.data.stock);
                        //C_PlayerInfo pkt = new C_PlayerInfo();
                        //pkt.beverages[1].cnt = node.data.stock;
                        //pkt.beverages[1].berName = node.data.name;
                        //pkt.beverages[1].price = node.data.price;
                        //Debug.Log(node.data.stock);
                        //Debug.Log(node.data.name);
                        //Debug.Log(node.data.price);
                        //network._session.Send(pkt.Write());
                        //Debug.Log("��� ������ �Ϸ�");
                    }
                    else
                    {
                        coffeenotext.text = "ǰ��";
                        Debug.Log("Ŀ�� ��� ����");
                    }
                    break;
                }
                node = node.Next;
            }
        }
        else
        {
            Debug.Log("�� ������");
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
                        highcoffeecount.text = "��� : " + node.data.stock.ToString() + " ��";
                        stockhighcoffee.text = "��� : " + node.data.stock.ToString() + " ��";
                        Debug.Log("���Ŀ�� ���ſϷ�");
                        Debug.Log("���� ���Ŀ���� ���: " + node.data.stock);
                        //C_PlayerInfo pkt = new C_PlayerInfo();

                        //pkt.beverage.cnt = node.data.stock;
                        //pkt.beverage.berName = node.data.name;
                        //pkt.beverage.price = node.data.price;
                        //Debug.Log(node.data.stock);
                        //Debug.Log(node.data.name);
                        //Debug.Log(node.data.price);
                        //network._session.Send(pkt.Write());
                        //Debug.Log("��� ������ �Ϸ�");
                    }
                    else
                    {
                        highcoffeenotext.text = "ǰ��";
                        Debug.Log("���Ŀ�� ��� ����");
                    }
                    break;
                }
                node = node.Next;
            }
        }
        else
        {
            Debug.Log("�� ������");
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
                        waterdrinkcount.text = "��� : " + node.data.stock.ToString() + " ��";
                        stockwaterdrink.text = "��� : " + node.data.stock.ToString() + " ��";
                        Debug.Log("�̿����ᱸ�ſϷ�");
                        Debug.Log("���� �̿������� ���: " + node.data.stock);
                        //C_PlayerInfo pkt = new C_PlayerInfo();

                        //pkt.beverage.cnt = node.data.stock;
                        //pkt.beverage.berName = node.data.name;
                        //pkt.beverage.price = node.data.price;
                        //Debug.Log(node.data.stock);
                        //Debug.Log(node.data.name);
                        //Debug.Log(node.data.price);
                        //network._session.Send(pkt.Write());
                        //Debug.Log("��� ������ �Ϸ�");
                    }
                    else
                    {
                        waterdrinknotext.text = "ǰ��";
                        Debug.Log("�̿����� ��� ����");
                    }
                    break;
                }
                node = node.Next;
            }
        }
        else
        {
            Debug.Log("�� �� ����");
            return;
        }
    }
    public void AddWater() //��� ���� ��ư
    {

        MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
        while (node != null)
        {
            if (node.data.name == "Water")
            {
                if (node.data.stock < 3)
                {

                    node.data.stock++;
                    watercount.text = "��� : " + node.data.stock.ToString() + " ��";
                    stockwater.text = "��� : " + node.data.stock.ToString() + " ��";
                    waternotext.text = "����";
                    //C_SupBeverage pkt = new C_SupBeverage();

                    //pkt.beverage.cnt = node.data.stock;
                    //pkt.beverage.berName = node.data.name;
                    //pkt.beverage.price = node.data.price;
                    //Debug.Log(node.data.stock);
                    //Debug.Log(node.data.name);
                    //Debug.Log(node.data.price);
                    //network._session.Send(pkt.Write());
                    //Debug.Log("��� ������ �Ϸ�");


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
                        coffeecount.text = "��� : " + node.data.stock.ToString() + " ��";
                        stockcoffee.text = "��� : " + node.data.stock.ToString() + " ��";
                        coffeenotext.text = "����";
                    //C_SupBeverage pkt = new C_SupBeverage();

                    //pkt.beverage.cnt = node.data.stock;
                    //pkt.beverage.berName = node.data.name;
                    //pkt.beverage.price = node.data.price;
                    //Debug.Log(node.data.stock);
                    //Debug.Log(node.data.name);
                    //Debug.Log(node.data.price);
                    //network._session.Send(pkt.Write());
                    //Debug.Log("��� ������ �Ϸ�");

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
                    waterdrinkcount.text = "��� : " + node.data.stock.ToString() + " ��";
                    stockwaterdrink.text = "��� : " + node.data.stock.ToString() + " ��";
                    waterdrinknotext.text = "����";
                    //C_SupBeverage pkt = new C_SupBeverage();

                    //pkt.beverage.cnt = node.data.stock;
                    //pkt.beverage.berName = node.data.name;
                    //pkt.beverage.price = node.data.price;
                    //Debug.Log(node.data.stock);
                    //Debug.Log(node.data.name);
                    //Debug.Log(node.data.price);
                    //network._session.Send(pkt.Write());
                    //Debug.Log("��� ������ �Ϸ�");

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
                    highcoffeecount.text = "��� : " + node.data.stock.ToString() + " ��";
                    stockhighcoffee.text = "��� : " + node.data.stock.ToString() + " ��";
                    highcoffeenotext.text = "����";
                    //C_SupBeverage pkt = new C_SupBeverage();

                    //pkt.beverage.cnt = node.data.stock;
                    //pkt.beverage.berName = node.data.name;
                    //pkt.beverage.price = node.data.price;
                    //Debug.Log(node.data.stock);
                    //Debug.Log(node.data.name);
                    //Debug.Log(node.data.price);
                    //network._session.Send(pkt.Write());
                    //Debug.Log("��� ������ �Ϸ�");

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
    public void AddTansanDrink() //ź�����Ḧ �����ϴ� �Լ� ��ư�� ������ ����ȴ�. ������ �Ʒ� �Լ��� �� ���� ���� ���� �ٸ���.
    {
        MyLinkedListNode<DrinkScrpit> node = drinkList.Head;
        while (node != null)
        {
            if (node.data.name == "Tansan Drink")
            {
                if (node.data.stock < 3)
                {

                    node.data.stock++;
                    tansancount.text = "��� : " + node.data.stock.ToString() + " ��";
                    stocktansan.text = "��� : " + node.data.stock.ToString() + " ��";
                    tansannotext.text = "����";
                //    C_SupBeverage pkt = new C_SupBeverage();

                //    pkt.beverage.cnt = node.data.stock;
                //    pkt.beverage.berName = node.data.name;
               //     pkt.beverage.price = node.data.price;
                //    Debug.Log(node.data.stock);
               //     Debug.Log(node.data.name);
               //     Debug.Log(node.data.price);
                 //   network._session.Send(pkt.Write());
                //    Debug.Log("��� ������ �Ϸ�");

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

    public void CancelDrink() //���� ���� â���� ��� ��ư�� ������ ������ ����� �Ѵ�. ��� ������ ��� �̸� ������ ������ ����;
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
        Debug.Log("��Ŷ ������ ����");
        Debug.Log("��"+pkt.beverages[0].cnt);
        Debug.Log("Ŀ��" + pkt.beverages[1].cnt);
        Debug.Log("�̿�" + pkt.beverages[2].cnt);
        Debug.Log("��Ŀ" + pkt.beverages[3].cnt);
        Debug.Log("ź��" + pkt.beverages[4].cnt);
    }
    public void CancelRecharge() //��� ����â���� ��� ��ư�� ������ ������ ����� �Ѵ�. ��� ������ ��� �̸� ������ ������ ����;
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

