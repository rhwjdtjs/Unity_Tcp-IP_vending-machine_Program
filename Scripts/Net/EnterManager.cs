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
            Debug.Log("������ �α��� �Ϸ�");
        }
    }
    public void EnterLogin()
    {
        C_EnterGame pkt = new C_EnterGame();
        pkt.password = PassWord.password;

        if (adminpassword.ispassword)
        {
            network._session.Send(pkt.Write());
            Debug.Log("��й�ȣ �����Ϸ�");
        }
    }
    public void TotalSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.TotalId;
        network._session.Send(ptk.Write());
        Debug.Log("��Ż ������ �Ϸ�");
    }
    public void WaterSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.WaterId;
        network._session.Send(ptk.Write());
        Debug.Log("�� ������ �Ϸ�");
    }
    public void CoffeeSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.CoffeeId;
        network._session.Send(ptk.Write());
        Debug.Log("Ŀ�� ������ �Ϸ�");
    }
    public void WaterDrinkSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.WaterdrinkId;
        network._session.Send(ptk.Write());
        Debug.Log("�̿����� ������ �Ϸ�");
    }
    public void HighcoffeeSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.HighcoffeeId;
        network._session.Send(ptk.Write());
        Debug.Log("��� Ŀ�� ������ �Ϸ�");
    }
    public void TansanSalesButton()
    {
        C_SalesInfo ptk = new C_SalesInfo();
        ptk.beverageId = SellerScript.TansanId;
        network._session.Send(ptk.Write());
        Debug.Log("ź�� ������ �Ϸ�");
    }
    public void WaterStockButton()
    {
      
    }

}
