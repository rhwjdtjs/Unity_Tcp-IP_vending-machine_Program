using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaterDrinkdailytotalsale : MonoBehaviour //dailyormonthsaleui와 동일 해당은 물을 위한 스크립트.
{
    [SerializeField] Text[] daily_total_sale;
    [SerializeField] Text[] daily_name;
    [SerializeField] Text[] month_total_sale;
    [SerializeField] Text[] month_name;
    [SerializeField] Image[] daily_gaege;
    [SerializeField] Image[] month_gaege;
    void Start()
    {
        LoadDataAndDrawGraph();
    }

    void Update()
    {
        // 데이터 로드 및 그래프 그리기
        LoadDataAndDrawGraph();
    }

    // 데이터 로드 및 그래프 그리기 함수
    void LoadDataAndDrawGraph()
    {
        // 데이터 로드
        SellerScript.LoadDataWater();

        // 일별 매출 그래프 그리기
        for (int i = 0; i < daily_total_sale.Length; i++)
        {
            daily_total_sale[i].text = SellerScript.dailysale[i].ToString();
            daily_name[i].text = SellerScript.dailyname[i];

            float gaugeFillAmount = (float)SellerScript.dailysale[i] / 10000f;//(float)SellerScript.totalsale;
            daily_gaege[i].fillAmount = gaugeFillAmount; //* 2.5f; // fillAmount 값을 2배로 조정
        }

        // 월별 매출 그래프 그리기
        for (int i = 0; i < month_total_sale.Length; i++)
        {
            month_total_sale[i].text = SellerScript.monthsale[i].ToString();
            month_name[i].text = SellerScript.monthname[i];

            float gaugeFillAmount = (float)SellerScript.monthsale[i] / 100000f;//(float)SellerScript.totalsale;
            month_gaege[i].fillAmount = gaugeFillAmount; //* 900f; // fillAmount 값을 2배로 조정
        }
    }
}
