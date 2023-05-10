using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageMoney : MonoBehaviour
{
    [SerializeField] private Text currentMoneyText; //���� ���� �� �ؽ�Ʈ
    [SerializeField] private Text errorText; //���� ǥ�� �ؽ�Ʈ
    [SerializeField] private Text add10text;
    [SerializeField] private Text add50text;
    [SerializeField] private Text add100text;
    [SerializeField] private Text add500text;
    [SerializeField] private Text add1000text; //�������� ������ ���� �ؽ�Ʈ
    [SerializeField] private Button rechargeButton; //�� ���� ��ư ���������ϱ�����
    [SerializeField] private Text return10text;
    [SerializeField] private Text return50text;
    [SerializeField] private Text return100text;
    [SerializeField] private Text return500text;
    [SerializeField] private Text return1000text; //�� ��ȯ �� ��ȯ�� ���� ǥ�� �ؽ�Ʈ

    void Start()
    {
        currentMoneyText.text = "0 ��"; //�����Ҷ� ���絷 0������ �ʱ�ȭ
    }

    void Update()
    {
        currentMoneyText.text = MoneyScript.remainMoney.ToString(); //�������Ӹ��� ���絷 ������Ʈ
        rechargeButton.onClick.AddListener(press_recharge_button); //���� �����Ҷ� ���� �̺�Ʈ �Ҵ�
    }
    public void add_10_button()
    {
        MoneyScript.money10count++;
        add10text.text = MoneyScript.money10count.ToString()+ "��";
    }
    public void add_50_button()
    {
        MoneyScript.money50count++;
        add50text.text = MoneyScript.money50count.ToString() + "��";
    }
    public void add_100_button()
    {
        MoneyScript.money100count++;
        add100text.text = MoneyScript.money100count.ToString() + "��";
    }
    public void add_500_button() 
    {
        MoneyScript.money500count++;
        add500text.text = MoneyScript.money500count.ToString() + "��";
    }
    public void add_1000_button()//������ 10��,50��.100��.500��,1000�� �����ϱ� ��ư�� ���������� �����ϴ� �Լ�, �ٸ� 1000���� 3�������� ��������
    {
        MoneyScript.money1000count++;
        add1000text.text = MoneyScript.money1000count.ToString() + "��";
        if (MoneyScript.money1000count >= 3)
        {
            MoneyScript.money1000count = 3;
            add1000text.text = MoneyScript.money1000count.ToString() + "��";
        }
    }
    public void press_recharge_button() //�����ϱ� ��ư�� ��������
    {
        MoneyScript.remainMoney = MoneyScript.money50count * 50 + MoneyScript.money100count * 100 +
            MoneyScript.money10count * 10 + MoneyScript.money500count * 500 + MoneyScript.money1000count * 1000; //���� ���� ����������ŭ ���ؼ� ����
        currentMoneyText.text = MoneyScript.remainMoney.ToString() + "��"; //������ ǥ��
        if(MoneyScript.remainMoney>5000) //���� 5000���ʰ����
        {
            errorText.gameObject.SetActive(true);
            errorText.text = "5000���� �ѱ��� ������, 0������ �ʱ�ȭ�˴ϴ�."; //�����ؽ�Ʈ
            MoneyScript.remainMoney = 0;
            MoneyScript.money10count = 0;
            MoneyScript.money50count = 0;
            MoneyScript.money100count = 0;
            MoneyScript.money500count = 0;
            MoneyScript.money1000count = 0;
            currentMoneyText.text = MoneyScript.remainMoney.ToString() + "��";
            add1000text.text = MoneyScript.money1000count.ToString() + "��";
            add500text.text = MoneyScript.money500count.ToString() + "��";
            add100text.text = MoneyScript.money100count.ToString() + "��";
            add50text.text = MoneyScript.money50count.ToString() + "��";
            add10text.text = MoneyScript.money10count.ToString() + "��";
            StartCoroutine(errortextco()); //��� 0���� �ʱ�ȭ
        }

        //   MoneyScript.rechargeMoney = int.Parse(theinputMoney.text);
        //  MoneyScript.remainMoney += MoneyScript.rechargeMoney;
        //  currentMoneyText.text = MoneyScript.remainMoney.ToString()+" ��";
    }
    public void press_changesmoney_Button() //���� ��ư ������
    {
      
        add1000text.text = MoneyScript.money1000count.ToString() + "��";
        add500text.text = MoneyScript.money500count.ToString() + "��";
        add100text.text = MoneyScript.money100count.ToString() + "��";
        add50text.text = MoneyScript.money50count.ToString() + "��";
        add10text.text = MoneyScript.money10count.ToString() + "��";
        currentMoneyText.text = MoneyScript.remainMoney.ToString() + "��";
        MoneyScript.remainMoney = MoneyScript.money50count * 50 + MoneyScript.money100count * 100 +
          MoneyScript.money10count * 10 + MoneyScript.money500count * 500 + MoneyScript.money1000count * 1000;//������ ����
    }
    public void press_remainmoney_return_Button() //�ܵ���ȯ ��ư�� ������
    {
        BuyItem(0); //�ܵ���ȯ�ϱ����� �Լ� �ҷ���
        
       
        MoneyScript.remainMoney = MoneyScript.money50count * 50 + MoneyScript.money100count * 100 +
          MoneyScript.money10count * 10 + MoneyScript.money500count * 500 + MoneyScript.money1000count * 1000;
        MoneyScript.money10count = 0;
        MoneyScript.money50count = 0;
        MoneyScript.money100count = 0;
        MoneyScript.money500count = 0;
        MoneyScript.money1000count = 0;
        MoneyScript.remainMoney = 0; //�ܵ���ȯ�� �����Ƿ� �� 0���� �ʱ�ȭ
        add1000text.text = MoneyScript.money1000count.ToString() + "��";
        add500text.text = MoneyScript.money500count.ToString() + "��";
        add100text.text = MoneyScript.money100count.ToString() + "��";
        add50text.text = MoneyScript.money50count.ToString() + "��";
        add10text.text = MoneyScript.money10count.ToString() + "��";
        currentMoneyText.text = MoneyScript.remainMoney.ToString() + "��"; //���� ���� �� �� �ؽ�Ʈ ����

    }
    IEnumerator errortextco()
    {
        yield return new WaitForSeconds(1.5f);
        errorText.gameObject.SetActive(false);
    }
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
        Debug.Log("������ ���� 1000: " + money1000);
        Debug.Log("������ ���� 500: " + money500);
        Debug.Log("������ ���� 100: " + money100);
        Debug.Log("������ ���� 50: " + money50);
        Debug.Log("������ ���� 10: " + money10);
        return10text.text = money10.ToString();
        return50text.text = money50.ToString();
        return100text.text = money100.ToString();
        return500text.text = money500.ToString();
        return1000text.text = money1000.ToString(); //�Լ��� ButDrink.cs�� �ִ� �Ͱ� ������ ��ȯ�� ���� üũ�ϴ°͸� ������.
        Debug.Log("Change: " + (MoneyScript.remainMoney + price) + " -> " + MoneyScript.remainMoney);
        Debug.Log("������ ���� 1000: " + MoneyScript.money1000count);
        Debug.Log("������ ���� 500: " + MoneyScript.money500count);
        Debug.Log("������ ���� 100: " + MoneyScript.money100count);
        Debug.Log("������ ���� 50: " + MoneyScript.money50count);
        Debug.Log("������ ���� 10: " + MoneyScript.money10count);
    }
}
