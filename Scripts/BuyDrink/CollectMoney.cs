using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CollectMoney : MonoBehaviour
{
    private string filePath;
    private ButDrink thebutdrink;

    private void Awake()
    {
        thebutdrink = FindObjectOfType<ButDrink>();
        filePath = Application.dataPath + "/Data/collectmoney.txt"; // 파일 경로 설정
        LoadData(); // 파일에서 데이터 읽어오기
    }

    private void OnApplicationQuit()
    {
        SaveData(); // 애플리케이션 종료 시점에 데이터 저장
    }

    private void LoadData()
    {
        // 파일에서 데이터 읽어오기
        if (File.Exists(filePath))
        {
            string savedData = File.ReadAllText(filePath);
            string[] dataArray = savedData.Split(',');

            MoneyScript.currentAdminMoney = int.Parse(dataArray[0]);
            MoneyScript.collectmoney10count = int.Parse(dataArray[1]);
            MoneyScript.collectmoney50count = int.Parse(dataArray[2]);
            MoneyScript.collectmoney100count = int.Parse(dataArray[3]);
            MoneyScript.collectmoney500count = int.Parse(dataArray[4]);
            MoneyScript.collectmoney1000count = int.Parse(dataArray[5]);
            Debug.Log("load 완료");
            Debug.Log("currentAdminMoney: " + MoneyScript.currentAdminMoney);
            Debug.Log("collectmoney10count: " + MoneyScript.collectmoney10count);
            Debug.Log("collectmoney50count: " + MoneyScript.collectmoney50count);
            Debug.Log("collectmoney100count: " + MoneyScript.collectmoney100count);
            Debug.Log("collectmoney500count: " + MoneyScript.collectmoney500count);
            Debug.Log("collectmoney1000count: " + MoneyScript.collectmoney1000count);
            //thebutdrink.Collectmoney_Button();
        }
    }

    private void SaveData()
    {
        // 파일에 데이터 저장
        string data = string.Format("{0},{1},{2},{3},{4},{5}",
            MoneyScript.currentAdminMoney, MoneyScript.collectmoney10count, MoneyScript.collectmoney50count,
            MoneyScript.collectmoney100count, MoneyScript.collectmoney500count, MoneyScript.collectmoney1000count);

        File.WriteAllText(filePath, data);
    }

}
