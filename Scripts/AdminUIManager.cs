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
    private coffeedailyormonthsaleui thecoffee;
    private dailyormonthsaleUI total;
    private highcoffeedailyormonthsaleui thehigh;
    private tansandailyormonthsaleui thetansan;
    private WaterDrinkdailytotalsale thewater;
    private waterdrinkdailyormonthsaleui thewaterdrink;
    
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
        total.LoadDataAndDrawGraph();
    }
    public void Open_watersalepanel()
    {
        watersalepanel.SetActive(true);
        thewater.LoadDataAndDrawGraph();
    }
    public void Open_totalsalepanelcoffeesalepanel()
    {
        coffeesalepanel.SetActive(true);
        thecoffee.LoadDataAndDrawGraph();
    }
    public void Open_waterdrinksalepanel()
    {
        waterdrinksalepanel.SetActive(true);
        thewaterdrink.LoadDataAndDrawGraph();
    }
    public void Open_highcoffeesalepanel()
    {
        highcoffeesalepanel.SetActive(true);
        thehigh.LoadDataAndDrawGraph();
    }
    public void Open_tansansalepanel()
    {
        tansansalepanel.SetActive(true);
        thetansan.LoadDataAndDrawGraph();
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
        total = FindObjectOfType<dailyormonthsaleUI>();
        thewater = FindObjectOfType<WaterDrinkdailytotalsale>();
        thewaterdrink = FindObjectOfType<waterdrinkdailyormonthsaleui>();
        thehigh = FindObjectOfType<highcoffeedailyormonthsaleui>();
        thetansan = FindObjectOfType<tansandailyormonthsaleui>();
        thecoffee = FindObjectOfType<coffeedailyormonthsaleui>();
    }

    void Update()
    {
        
    }
}
