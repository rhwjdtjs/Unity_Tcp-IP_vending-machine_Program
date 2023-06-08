using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageMoney : MonoBehaviour
{
    [SerializeField] private Text currentMoneyText; //현재 소유 돈 텍스트
    [SerializeField] private Text errorText; //에러 표시 텍스트
    [SerializeField] private Text add10text;
    [SerializeField] private Text add50text;
    [SerializeField] private Text add100text;
    [SerializeField] private Text add500text;
    [SerializeField] private Text add1000text; //돈충전시 각각의 동전 텍스트
    [SerializeField] private Button rechargeButton; //돈 충전 버튼 동적생성하기위해
    [SerializeField] private Text return10text;
    [SerializeField] private Text return50text;
    [SerializeField] private Text return100text;
    [SerializeField] private Text return500text;
    [SerializeField] private Text return1000text; //돈 반환 시 반환한 동전 표시 텍스트

    void Start()
    {
        currentMoneyText.text = "0 원"; //시작할때 현재돈 0원으로 초기화
    }

    void Update()
    {
        currentMoneyText.text = MoneyScript.remainMoney.ToString(); //매프레임마다 현재돈 업데이트
        rechargeButton.onClick.AddListener(press_recharge_button); //돈을 충전할때 동적 이벤트 할당
    }
    public void add_10_button()
    {
        MoneyScript.money10count++;
        add10text.text = MoneyScript.money10count.ToString()+ "개";
    }
    public void add_50_button()
    {
        MoneyScript.money50count++;
        add50text.text = MoneyScript.money50count.ToString() + "개";
    }
    public void add_100_button()
    {
        MoneyScript.money100count++;
        add100text.text = MoneyScript.money100count.ToString() + "개";
    }
    public void add_500_button() 
    {
        MoneyScript.money500count++;
        add500text.text = MoneyScript.money500count.ToString() + "개";
    }
    public void add_1000_button()//각각의 10원,50원.100원.500원,1000언 충전하기 버튼을 누를때마다 실행하는 함수, 다만 1000원은 3개까지만 충전가능
    {
        MoneyScript.money1000count++;
        add1000text.text = MoneyScript.money1000count.ToString() + "개";
        if (MoneyScript.money1000count >= 3)
        {
            MoneyScript.money1000count = 3;
            add1000text.text = MoneyScript.money1000count.ToString() + "개";
        }
    }
    public void press_recharge_button() //충전하기 버튼을 눌렀을때
    {
        MoneyScript.remainMoney = MoneyScript.money50count * 50 + MoneyScript.money100count * 100 +
            MoneyScript.money10count * 10 + MoneyScript.money500count * 500 + MoneyScript.money1000count * 1000; //현재 돈을 동전갯수만큼 더해서 충전
        currentMoneyText.text = MoneyScript.remainMoney.ToString() + "원"; //남은돈 표시
        if(MoneyScript.remainMoney>5000) //만약 5000원초과라면
        {
            errorText.gameObject.SetActive(true);
            errorText.text = "5000원을 넘기지 마세요, 0원으로 초기화됩니다."; //에러텍스트
            MoneyScript.remainMoney = 0;
            MoneyScript.money10count = 0;
            MoneyScript.money50count = 0;
            MoneyScript.money100count = 0;
            MoneyScript.money500count = 0;
            MoneyScript.money1000count = 0;
            currentMoneyText.text = MoneyScript.remainMoney.ToString() + "원";
            add1000text.text = MoneyScript.money1000count.ToString() + "개";
            add500text.text = MoneyScript.money500count.ToString() + "개";
            add100text.text = MoneyScript.money100count.ToString() + "개";
            add50text.text = MoneyScript.money50count.ToString() + "개";
            add10text.text = MoneyScript.money10count.ToString() + "개";
            StartCoroutine(errortextco()); //모두 0으로 초기화
        }

        //   MoneyScript.rechargeMoney = int.Parse(theinputMoney.text);
        //  MoneyScript.remainMoney += MoneyScript.rechargeMoney;
        //  currentMoneyText.text = MoneyScript.remainMoney.ToString()+" 원";
    }
    public void press_changesmoney_Button() //갱신 버튼 누르면
    {
      
        add1000text.text = MoneyScript.money1000count.ToString() + "개";
        add500text.text = MoneyScript.money500count.ToString() + "개";
        add100text.text = MoneyScript.money100count.ToString() + "개";
        add50text.text = MoneyScript.money50count.ToString() + "개";
        add10text.text = MoneyScript.money10count.ToString() + "개";
        currentMoneyText.text = MoneyScript.remainMoney.ToString() + "원";
        MoneyScript.remainMoney = MoneyScript.money50count * 50 + MoneyScript.money100count * 100 +
          MoneyScript.money10count * 10 + MoneyScript.money500count * 500 + MoneyScript.money1000count * 1000;//남은돈 갱신
    }
    public void press_remainmoney_return_Button() //잔돈반환 버튼을 누르면
    {
        BuyItem(0); //잔돈반환하기위해 함수 불러옴
        
       
        MoneyScript.remainMoney = MoneyScript.money50count * 50 + MoneyScript.money100count * 100 +
          MoneyScript.money10count * 10 + MoneyScript.money500count * 500 + MoneyScript.money1000count * 1000;
        MoneyScript.money10count = 0;
        MoneyScript.money50count = 0;
        MoneyScript.money100count = 0;
        MoneyScript.money500count = 0;
        MoneyScript.money1000count = 0;
        MoneyScript.remainMoney = 0; //잔돈반환을 했으므로 다 0으로 초기화
        add1000text.text = MoneyScript.money1000count.ToString() + "개";
        add500text.text = MoneyScript.money500count.ToString() + "개";
        add100text.text = MoneyScript.money100count.ToString() + "개";
        add50text.text = MoneyScript.money50count.ToString() + "개";
        add10text.text = MoneyScript.money10count.ToString() + "개";
        currentMoneyText.text = MoneyScript.remainMoney.ToString() + "원"; //남은 동전 및 돈 텍스트 갱신

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
        Debug.Log("동전의 갯수 1000: " + money1000);
        Debug.Log("동전의 갯수 500: " + money500);
        Debug.Log("동전의 갯수 100: " + money100);
        Debug.Log("동전의 갯수 50: " + money50);
        Debug.Log("동전의 갯수 10: " + money10);
        return10text.text = money10.ToString();
        return50text.text = money50.ToString();
        return100text.text = money100.ToString();
        return500text.text = money500.ToString();
        return1000text.text = money1000.ToString(); //함수는 ButDrink.cs에 있는 것과 같지만 반환된 동전 체크하는것만 수정됨.
        Debug.Log("Change: " + (MoneyScript.remainMoney + price) + " -> " + MoneyScript.remainMoney);
        Debug.Log("동전의 갯수 1000: " + MoneyScript.money1000count);
        Debug.Log("동전의 갯수 500: " + MoneyScript.money500count);
        Debug.Log("동전의 갯수 100: " + MoneyScript.money100count);
        Debug.Log("동전의 갯수 50: " + MoneyScript.money50count);
        Debug.Log("동전의 갯수 10: " + MoneyScript.money10count);
    }
}
