using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServerCore;
using UnityEngine.UI;
public class EnterManager : MonoBehaviour
{
    NetworkManager network;
    // public static EnterManager instance { get; } = new EnterManager();
    void Start()
    {
        network = FindObjectOfType<NetworkManager>();
    }

    void Update()
    {
        
    }
    public void Login_admin()
    {
        C_Login pkt = new C_Login();
        pkt.password = PassWord.password;

        if (adminpassword.ispassword)
        {
            network._session.Send(pkt.Write());
            Debug.Log("관리자 로그인 완료");
        }
    }
    public void EnterLogin()
    {
        C_EnterGame pkt = new C_EnterGame();
        pkt.password = PassWord.password;

        if (adminpassword.ispassword)
        {
            network._session.Send(pkt.Write());
            Debug.Log("비밀번호 설정완료");
        }
    }
    public void TotalSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.TotalId;
        network._session.Send(ptk.Write());
        Debug.Log("토탈 보내기 완료");
    }
    public void WaterSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.WaterId;
        network._session.Send(ptk.Write());
        Debug.Log("물 보내기 완료");
    }
    public void CoffeeSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.CoffeeId;
        network._session.Send(ptk.Write());
        Debug.Log("커피 보내기 완료");
    }
    public void WaterDrinkSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.WaterdrinkId;
        network._session.Send(ptk.Write());
        Debug.Log("이온음료 보내기 완료");
    }
    public void HighcoffeeSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.HighcoffeeId;
        network._session.Send(ptk.Write());
        Debug.Log("고급 커피 보내기 완료");
    }
    public void TansanSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.TansanId;
        network._session.Send(ptk.Write());
        Debug.Log("탄산 보내기 완료");
    }
    public void WaterStockButton()
    {
      
    }

}
