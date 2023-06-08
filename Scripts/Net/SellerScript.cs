using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public class SellerScript
{
    public static int WaterId = 1;
    public static int CoffeeId = 2;
    public static int WaterdrinkId = 3;
    public static int HighcoffeeId = 4;
    public static int TansanId = 5;
    public static int TotalId = 0;
    public static int totalsaledailyall; //통합 일별 총 매출
    public static int totalsalemonthall; //통합 월별 총 매출
    public static int totalsaledailywater; //물상품의 일별 총 매출
    public static int totalsalemonthwater; //물상품의 월별 총 매출
    public static int totalsaledailycoffee; //커피상품의 일별 총 매출
    public static int totalsalemonthcoffee; //커피상품의 월별 총 매출
    public static int totalsaledailywaterdrink;//이온음료상품의 일별 총 매출
    public static int totalsaledmonthwaterdrink;//이온음료상품의 월별 총 매출
    public static int totalsaledailyhighcoffee;//고급커피상품의 일별 총 매출
    public static int totalsalemonthhighcoffee;//고급커피상품의 월별 총 매출
    public static int totalsaledailytansan;//탄산음료상품의 일별 총 매출
    public static int totalsalemonthtansan;//탄산음료상품의 월별 총 매출
    public static string[] dailyname; //텍스트에서 받아올 일별 이름 받아오기위한 변수
    public static string[] monthname; //텍스트파일에서 받아올 월별 이름 받아오기위한 변수
    public static int[] dailysale; //일별로 팔린 금액을 받아오기 위한 변수
    public static int[] monthsale; //월별로 팔린 금액을 받아오기 위한 변수
    public static string netdata;
    public static void LoadData()
    {
        // saledata.txt 파일의 경로
        string filePath = Application.dataPath + "/Data/saledata.txt";

        // 파일을 한 줄씩 읽어들이기 위한 StreamReader 객체 생성
        StreamReader reader = new StreamReader(filePath);

        // 변수 초기화
        totalsaledailyall = 0;
        totalsalemonthall = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
      //  netdata.Split(",");
        // 파일 끝까지 한 줄씩 읽어들이면서 처리
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // 한 줄 읽어들임

            // 빈 줄인 경우 무시
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // 매출 데이터 포맷이 잘못된 경우 에러 출력 후 무시
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // 한 줄을 공백으로 분리해서 각각의 값을 변수에 저장
            string date = data[0];

            // 월별 매출 처리
            if (date.Contains("월")) // 월 이름이 있는 경우
            {
                int monthIndex = date.IndexOf("월");
                if (monthIndex != -1)
                {
                    string monthStr = date.Substring(0, monthIndex);
                    if (int.TryParse(monthStr, out int month))
                    {
                        monthname[month - 1] = date;
                        monthsale[month - 1] = sale;
                        totalsalemonthall += sale;
                    }
                    else
                    {
                        Debug.LogError("Invalid month format: " + date);
                    }
                }
            }
            //일별 매출 처리
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" 형식인 경우
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // 배열 범위를 벗어나는 경우 예외처리
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailyall += sale;
                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // 유효하지 않은 날짜를 로그로 출력
                }
            }
            else // 잘못된 형식인 경우
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader 객체 닫기
        reader.Close();
        //Debug.Log(totalsale);
    } //일별,월별 텍스트 파일에서 불러옴
    public static void LoadDataWater()
    {
        // saledata.txt 파일의 경로
        string filePath = Application.dataPath + "/Data/Watersaledata.txt";

        // 파일을 한 줄씩 읽어들이기 위한 StreamReader 객체 생성
        StreamReader reader = new StreamReader(filePath);

        // 변수 초기화
        totalsaledailywater = 0;
        totalsalemonthwater = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
       // netdata.Split(",");
        // 파일 끝까지 한 줄씩 읽어들이면서 처리
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // 한 줄 읽어들임

            // 빈 줄인 경우 무시
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // 매출 데이터 포맷이 잘못된 경우 에러 출력 후 무시
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // 한 줄을 공백으로 분리해서 각각의 값을 변수에 저장
            string date = data[0];

            // 월별 매출 처리
            if (date.Contains("월")) // 월 이름이 있는 경우
            {
                int monthIndex = date.IndexOf("월");
                if (monthIndex != -1)
                {
                    string monthStr = date.Substring(0, monthIndex);
                    if (int.TryParse(monthStr, out int month))
                    {
                        monthname[month - 1] = date;
                        monthsale[month - 1] = sale;
                        totalsalemonthwater += sale;
                       
                    }
                    else
                    {
                        Debug.LogError("Invalid month format: " + date);
                    }
                }
            }
            //일별 매출처리
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" 형식인 경우
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // 배열 범위를 벗어나는 경우 예외처리
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailywater += sale;
                    
                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // 유효하지 않은 날짜를 로그로 출력
                }
            }
            else // 잘못된 형식인 경우
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader 객체 닫기
        reader.Close();

    }//물의 일별,월별 텍스트 파일에서 불러옴
    
    public static void LoadDataCoffee()
    {
        // saledata.txt 파일의 경로
        string filePath = Application.dataPath + "/Data/Coffeesaledata.txt";

        // 파일을 한 줄씩 읽어들이기 위한 StreamReader 객체 생성
        StreamReader reader = new StreamReader(filePath);

        // 변수 초기화
        totalsaledailywater = 0;
        totalsalemonthwater = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
        netdata.Split(",");
        // 파일 끝까지 한 줄씩 읽어들이면서 처리
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // 한 줄 읽어들임

            // 빈 줄인 경우 무시
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // 매출 데이터 포맷이 잘못된 경우 에러 출력 후 무시
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // 한 줄을 공백으로 분리해서 각각의 값을 변수에 저장
            string date = data[0];

            // 월별 매출 처리
            if (date.Contains("월")) // 월 이름이 있는 경우
            {
                int monthIndex = date.IndexOf("월");
                if (monthIndex != -1)
                {
                    string monthStr = date.Substring(0, monthIndex);
                    if (int.TryParse(monthStr, out int month))
                    {
                        monthname[month - 1] = date;
                        monthsale[month - 1] = sale;
                        totalsalemonthwater += sale;

                    }
                    else
                    {
                        Debug.LogError("Invalid month format: " + date);
                    }
                }
            }
            //일별 매출처리
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" 형식인 경우
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // 배열 범위를 벗어나는 경우 예외처리
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailywater += sale;

                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // 유효하지 않은 날짜를 로그로 출력
                }
            }
            else // 잘못된 형식인 경우
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader 객체 닫기
        reader.Close();

    }
    
    
    //public static void LoadDataCoffee()
    //{
    //    // 변수 초기화
    //    totalsaledailywater = 0;
    //    totalsalemonthwater = 0;
    //    dailyname = new string[7];
    //    monthname = new string[12];
    //    dailysale = new int[7];
    //    monthsale = new int[12];

    //    // netdata를 쉼표로 분리해서 각각의 값을 처리
    //    string[] dataEntries = netdata.Split(',');

    //    foreach (string entry in dataEntries)
    //    {
    //        // 빈 칸인 경우 무시
    //        if (string.IsNullOrEmpty(entry))
    //        {
    //            continue;
    //        }

    //        string[] data = entry.Split(' ');

    //        // 매출 데이터 포맷이 잘못된 경우 에러 출력 후 무시
    //        if (data.Length != 2 || !int.TryParse(data[1], out int sale))
    //        {
    //            Debug.LogError("Invalid data format: " + entry);
    //            continue;
    //        }

    //        // 한 줄을 공백으로 분리해서 각각의 값을 변수에 저장
    //        string date = data[0];

    //        // 월별 매출 처리
    //        if (date.Contains("월")) // 월 이름이 있는 경우
    //        {
    //            int monthIndex = date.IndexOf("월");
    //            if (monthIndex != -1)
    //            {
    //                string monthStr = date.Substring(0, monthIndex);
    //                if (int.TryParse(monthStr, out int month))
    //                {
    //                    monthname[month - 1] = date;
    //                    monthsale[month - 1] = sale;
    //                    totalsalemonthwater += sale;
    //                }
    //                else
    //                {
    //                    Debug.LogError("Invalid month format: " + date);
    //                }
    //            }
    //        }
    //        //일별 매출처리
    //        else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" 형식인 경우
    //        {
    //            int day = datetime.Day;
    //            if (day > 0 && day <= dailyname.Length) // 배열 범위를 벗어나는 경우 예외처리
    //            {
    //                dailyname[day - 1] = date;
    //                dailysale[day - 1] = sale;
    //                totalsaledailywater += sale;
    //            }
    //            else
    //            {
    //                Debug.LogError("Invalid date: " + date); // 유효하지 않은 날짜를 로그로 출력
    //            }
    //        }
    //        else // 잘못된 형식인 경우
    //        {
    //            Debug.LogError("Invalid day format: " + date);
    //        }
    //    }
    //}

    public static void LoadDataWaterdrink()
    {
        // saledata.txt 파일의 경로
        string filePath = Application.dataPath + "/Data/Waterdrinksaledata.txt";

        // 파일을 한 줄씩 읽어들이기 위한 StreamReader 객체 생성
        StreamReader reader = new StreamReader(filePath);

        // 변수 초기화
        totalsaledailywater = 0;
        totalsalemonthwater = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
      //  netdata.Split(",");
        // 파일 끝까지 한 줄씩 읽어들이면서 처리
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // 한 줄 읽어들임

            // 빈 줄인 경우 무시
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // 매출 데이터 포맷이 잘못된 경우 에러 출력 후 무시
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // 한 줄을 공백으로 분리해서 각각의 값을 변수에 저장
            string date = data[0];

            // 월별 매출 처리
            if (date.Contains("월")) // 월 이름이 있는 경우
            {
                int monthIndex = date.IndexOf("월");
                if (monthIndex != -1)
                {
                    string monthStr = date.Substring(0, monthIndex);
                    if (int.TryParse(monthStr, out int month))
                    {
                        monthname[month - 1] = date;
                        monthsale[month - 1] = sale;
                        totalsalemonthwater += sale;

                    }
                    else
                    {
                        Debug.LogError("Invalid month format: " + date);
                    }
                }
            }
            //일별 매출처리
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" 형식인 경우
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // 배열 범위를 벗어나는 경우 예외처리
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailywater += sale;

                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // 유효하지 않은 날짜를 로그로 출력
                }
            }
            else // 잘못된 형식인 경우
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader 객체 닫기
        reader.Close();

    }
    public static void LoadDataHighcoffee()
    {
        // saledata.txt 파일의 경로
        string filePath = Application.dataPath + "/Data/Highcoffeesaledata.txt";

        // 파일을 한 줄씩 읽어들이기 위한 StreamReader 객체 생성
        StreamReader reader = new StreamReader(filePath);

        // 변수 초기화
        totalsaledailywater = 0;
        totalsalemonthwater = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
      //  netdata.Split(",");
        // 파일 끝까지 한 줄씩 읽어들이면서 처리
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // 한 줄 읽어들임

            // 빈 줄인 경우 무시
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // 매출 데이터 포맷이 잘못된 경우 에러 출력 후 무시
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // 한 줄을 공백으로 분리해서 각각의 값을 변수에 저장
            string date = data[0];

            // 월별 매출 처리
            if (date.Contains("월")) // 월 이름이 있는 경우
            {
                int monthIndex = date.IndexOf("월");
                if (monthIndex != -1)
                {
                    string monthStr = date.Substring(0, monthIndex);
                    if (int.TryParse(monthStr, out int month))
                    {
                        monthname[month - 1] = date;
                        monthsale[month - 1] = sale;
                        totalsalemonthwater += sale;

                    }
                    else
                    {
                        Debug.LogError("Invalid month format: " + date);
                    }
                }
            }
            //일별 매출처리
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" 형식인 경우
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // 배열 범위를 벗어나는 경우 예외처리
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailywater += sale;

                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // 유효하지 않은 날짜를 로그로 출력
                }
            }
            else // 잘못된 형식인 경우
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader 객체 닫기
        reader.Close();

    }
    public static void LoadDataTansan()
    {
        // saledata.txt 파일의 경로
        string filePath = Application.dataPath + "/Data/Tansansaledata.txt";

        // 파일을 한 줄씩 읽어들이기 위한 StreamReader 객체 생성
        StreamReader reader = new StreamReader(filePath);

        // 변수 초기화
        totalsaledailywater = 0;
        totalsalemonthwater = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
     //   netdata.Split(",");
        // 파일 끝까지 한 줄씩 읽어들이면서 처리
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // 한 줄 읽어들임

            // 빈 줄인 경우 무시
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // 매출 데이터 포맷이 잘못된 경우 에러 출력 후 무시
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // 한 줄을 공백으로 분리해서 각각의 값을 변수에 저장
            string date = data[0];

            // 월별 매출 처리
            if (date.Contains("월")) // 월 이름이 있는 경우
            {
                int monthIndex = date.IndexOf("월");
                if (monthIndex != -1)
                {
                    string monthStr = date.Substring(0, monthIndex);
                    if (int.TryParse(monthStr, out int month))
                    {
                        monthname[month - 1] = date;
                        monthsale[month - 1] = sale;
                        totalsalemonthwater += sale;

                    }
                    else
                    {
                        Debug.LogError("Invalid month format: " + date);
                    }
                }
            }
            //일별 매출처리
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" 형식인 경우
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // 배열 범위를 벗어나는 경우 예외처리
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailywater += sale;

                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // 유효하지 않은 날짜를 로그로 출력
                }
            }
            else // 잘못된 형식인 경우
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader 객체 닫기
        reader.Close();

    }
}


