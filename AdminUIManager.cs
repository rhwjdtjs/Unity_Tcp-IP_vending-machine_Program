using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdminUIManager : MonoBehaviour
{
    public GameObject openselectpanel;
    public GameObject totalsalepanel;
    public GameObject watersalepanel;
    public GameObject coffeesalepanel;
    public GameObject waterdrinksalepanel;
    public GameObject highcoffeesalepanel;
    public GameObject tansansalepanel;
    public void Open_openselectpanel()
    {
        openselectpanel.SetActive(true);
    }
    public void Close_openselectpanel()
    {
        openselectpanel.SetActive(false);
    }
    public void Open_totalsalepanel()
    {
        totalsalepanel.SetActive(true);
    }
    public void Open_watersalepanel()
    {
        watersalepanel.SetActive(true);
    }
    public void Open_totalsalepanelcoffeesalepanel()
    {
        coffeesalepanel.SetActive(true);
    }
    public void Open_waterdrinksalepanel()
    {
        waterdrinksalepanel.SetActive(true);
    }
    public void Open_highcoffeesalepanel()
    {
        highcoffeesalepanel.SetActive(true);
    }
    public void Open_tansansalepanel()
    {
        tansansalepanel.SetActive(true);
    }
    public void Cancel_totalsalepanel()
    {
        totalsalepanel.SetActive(false);
    }
    public void Cancel_watersalepanel()
    {
        watersalepanel.SetActive(false);
    }
    public void Cancel_coffeesalepanel()
    {
        coffeesalepanel.SetActive(false);
    }
    public void Cancel_waterdrinksalepanel()
    {
        waterdrinksalepanel.SetActive(false);
    }
    public void Cancel_highcoffeesalepanel()
    {
        highcoffeesalepanel.SetActive(false);
    }
    public void Cancel_tansansalepanel()
    {
        tansansalepanel.SetActive(false);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
