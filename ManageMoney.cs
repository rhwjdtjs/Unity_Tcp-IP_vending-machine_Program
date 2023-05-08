using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageMoney : MonoBehaviour
{
    [SerializeField] private Text currentMoneyText;
    [SerializeField] private Text errorText;
    [SerializeField] private Text add10text;
    [SerializeField] private Text add50text;
    [SerializeField] private Text add100text;
    [SerializeField] private Text add500text;
    [SerializeField] private Text add1000text;
    [SerializeField] private Button rechargeButton;

    void Start()
    {
        currentMoneyText.text = "0 ��";
    }

    void Update()
    {
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
    public void add_1000_button()
    {
        MoneyScript.money1000count++;
        add1000text.text = MoneyScript.money1000count.ToString() + "��";
        if (MoneyScript.money1000count >= 3)
        {
            MoneyScript.money1000count = 3;
            add1000text.text = MoneyScript.money1000count.ToString() + "��";
        }
    }
    public void press_recharge_button()
    {
        MoneyScript.remainMoney = MoneyScript.money50count * 50 + MoneyScript.money100count * 100 +
            MoneyScript.money10count * 10 + MoneyScript.money500count * 500 + MoneyScript.money1000count * 1000;
        currentMoneyText.text = MoneyScript.remainMoney.ToString() + "��";
        if(MoneyScript.remainMoney>5000)
        {
            errorText.gameObject.SetActive(true);
            errorText.text = "5000���� �ѱ��� ������, 0������ �ʱ�ȭ�˴ϴ�.";
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
            StartCoroutine(errortextco());
        }

        //   MoneyScript.rechargeMoney = int.Parse(theinputMoney.text);
        //  MoneyScript.remainMoney += MoneyScript.rechargeMoney;
        //  currentMoneyText.text = MoneyScript.remainMoney.ToString()+" ��";
    }
    public void press_changesmoney_Button()
    {
      
        add1000text.text = MoneyScript.money1000count.ToString() + "��";
        add500text.text = MoneyScript.money500count.ToString() + "��";
        add100text.text = MoneyScript.money100count.ToString() + "��";
        add50text.text = MoneyScript.money50count.ToString() + "��";
        add10text.text = MoneyScript.money10count.ToString() + "��";
        currentMoneyText.text = MoneyScript.remainMoney.ToString() + "��";
        MoneyScript.remainMoney = MoneyScript.money50count * 50 + MoneyScript.money100count * 100 +
          MoneyScript.money10count * 10 + MoneyScript.money500count * 500 + MoneyScript.money1000count * 1000;
    }
    IEnumerator errortextco()
    {
        yield return new WaitForSeconds(1.5f);
        errorText.gameObject.SetActive(false);
    }
}
