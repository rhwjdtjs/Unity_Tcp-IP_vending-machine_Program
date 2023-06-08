using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tansandailyormonthsaleui : MonoBehaviour
{
    [SerializeField] Text[] daily_total_sale; //일별 팔린 금액 텍스트
    [SerializeField] Text[] daily_name; //일별 이름 텍스트
    [SerializeField] Text[] month_total_sale; //월별 판매 금액 텍스트
    [SerializeField] Text[] month_name; //월별 이름 텍스트
    [SerializeField] Image[] daily_gaege; //일별 판매 그래프
    [SerializeField] Image[] month_gaege; //월별 판매 그래프
    void Start()
    {
      //  LoadDataAndDrawGraph();
    }

    void Update()
    {
        // 데이터 로드 및 그래프 그리기
        //LoadDataAndDrawGraph();
    }

    // 데이터 로드 및 그래프 그리기 함수
   public void LoadDataAndDrawGraph()
    {
        // 데이터 로드
        SellerScript.LoadDataTansan();

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
