using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminPanelScrpit : MonoBehaviour
{
    [SerializeField] private GameObject sellerpanel;
    [SerializeField] private GameObject returnmoneypanel;
    [SerializeField] private GameObject remaindrinkpanel;
    [SerializeField] private GameObject adminpanel;
    void Start()
    {

    }

    void Update()
    {

    }
    public void press_seller_button() //�Ϻ� ���� ���� ��ư ��������.
    {
      //  adminpanel.SetActive(false);
        sellerpanel.SetActive(true);
    }
    public void press_cancel_button_in_sellerpanel()
    {
       // adminpanel.SetActive(true);
        sellerpanel.SetActive(false);
    }
    public void press_return_money_button() //�����ϱ� ��ư ��������
    {
     //   adminpanel.SetActive(false);
        returnmoneypanel.SetActive(true);
    }
    public void press_cancel_button_in_returnmoneypanel()
    {
      //  adminpanel.SetActive(true);
        returnmoneypanel.SetActive(false);
    }
    public void press_remain_drink_panel()
    {
      //  adminpanel.SetActive(false);
        remaindrinkpanel.SetActive(true);

    }
    public void press_cancel_button_in_remaindrinkpanel()
    {
//adminpanel.SetActive(true);
        remaindrinkpanel.SetActive(false);
    }
}
