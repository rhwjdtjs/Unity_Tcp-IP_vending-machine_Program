using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButDrink : MonoBehaviour
{

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
        add10text.text = MoneyScript.money10count.ToString()+"��";
        add50text.text = MoneyScript.money50count.ToString()+"��";
        add100text.text = MoneyScript.money100count.ToString()+"��";
        add500text.text = MoneyScript.money500count.ToString()+"��";
        add1000text.text = MoneyScript.money1000count.ToString()+"��"; //������ ������ ���� ���� ���� ���� �ؽ�Ʈ�� ǥ��
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
                        Debug.Log("ź�� ���� �Ϸ�");
                        Debug.Log("���� ź���� ���: " + node.data.stock);
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

                        Debug.Log("�� ���� �Ϸ�");
                        Debug.Log("���� ���� ���: " + node.data.stock);
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
                        Debug.Log("Ŀ�� ���ſϷ�");
                        Debug.Log("���� Ŀ���� ���: " + node.data.stock);
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
                        Debug.Log("���Ŀ�� ���ſϷ�");
                        Debug.Log("���� ���Ŀ���� ���: " + node.data.stock);
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
                        Debug.Log("�̿����ᱸ�ſϷ�");
                        Debug.Log("���� �̿������� ���: " + node.data.stock);
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
}

