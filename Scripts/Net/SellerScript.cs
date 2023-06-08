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
    public static int totalsaledailyall; //���� �Ϻ� �� ����
    public static int totalsalemonthall; //���� ���� �� ����
    public static int totalsaledailywater; //����ǰ�� �Ϻ� �� ����
    public static int totalsalemonthwater; //����ǰ�� ���� �� ����
    public static int totalsaledailycoffee; //Ŀ�ǻ�ǰ�� �Ϻ� �� ����
    public static int totalsalemonthcoffee; //Ŀ�ǻ�ǰ�� ���� �� ����
    public static int totalsaledailywaterdrink;//�̿������ǰ�� �Ϻ� �� ����
    public static int totalsaledmonthwaterdrink;//�̿������ǰ�� ���� �� ����
    public static int totalsaledailyhighcoffee;//���Ŀ�ǻ�ǰ�� �Ϻ� �� ����
    public static int totalsalemonthhighcoffee;//���Ŀ�ǻ�ǰ�� ���� �� ����
    public static int totalsaledailytansan;//ź�������ǰ�� �Ϻ� �� ����
    public static int totalsalemonthtansan;//ź�������ǰ�� ���� �� ����
    public static string[] dailyname; //�ؽ�Ʈ���� �޾ƿ� �Ϻ� �̸� �޾ƿ������� ����
    public static string[] monthname; //�ؽ�Ʈ���Ͽ��� �޾ƿ� ���� �̸� �޾ƿ������� ����
    public static int[] dailysale; //�Ϻ��� �ȸ� �ݾ��� �޾ƿ��� ���� ����
    public static int[] monthsale; //������ �ȸ� �ݾ��� �޾ƿ��� ���� ����
    public static string netdata;
    public static void LoadData()
    {
        // saledata.txt ������ ���
        string filePath = Application.dataPath + "/Data/saledata.txt";

        // ������ �� �پ� �о���̱� ���� StreamReader ��ü ����
        StreamReader reader = new StreamReader(filePath);

        // ���� �ʱ�ȭ
        totalsaledailyall = 0;
        totalsalemonthall = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
      //  netdata.Split(",");
        // ���� ������ �� �پ� �о���̸鼭 ó��
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // �� �� �о����

            // �� ���� ��� ����
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // ���� ������ ������ �߸��� ��� ���� ��� �� ����
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // �� ���� �������� �и��ؼ� ������ ���� ������ ����
            string date = data[0];

            // ���� ���� ó��
            if (date.Contains("��")) // �� �̸��� �ִ� ���
            {
                int monthIndex = date.IndexOf("��");
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
            //�Ϻ� ���� ó��
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" ������ ���
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // �迭 ������ ����� ��� ����ó��
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailyall += sale;
                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // ��ȿ���� ���� ��¥�� �α׷� ���
                }
            }
            else // �߸��� ������ ���
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader ��ü �ݱ�
        reader.Close();
        //Debug.Log(totalsale);
    } //�Ϻ�,���� �ؽ�Ʈ ���Ͽ��� �ҷ���
    public static void LoadDataWater()
    {
        // saledata.txt ������ ���
        string filePath = Application.dataPath + "/Data/Watersaledata.txt";

        // ������ �� �پ� �о���̱� ���� StreamReader ��ü ����
        StreamReader reader = new StreamReader(filePath);

        // ���� �ʱ�ȭ
        totalsaledailywater = 0;
        totalsalemonthwater = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
       // netdata.Split(",");
        // ���� ������ �� �پ� �о���̸鼭 ó��
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // �� �� �о����

            // �� ���� ��� ����
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // ���� ������ ������ �߸��� ��� ���� ��� �� ����
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // �� ���� �������� �и��ؼ� ������ ���� ������ ����
            string date = data[0];

            // ���� ���� ó��
            if (date.Contains("��")) // �� �̸��� �ִ� ���
            {
                int monthIndex = date.IndexOf("��");
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
            //�Ϻ� ����ó��
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" ������ ���
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // �迭 ������ ����� ��� ����ó��
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailywater += sale;
                    
                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // ��ȿ���� ���� ��¥�� �α׷� ���
                }
            }
            else // �߸��� ������ ���
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader ��ü �ݱ�
        reader.Close();

    }//���� �Ϻ�,���� �ؽ�Ʈ ���Ͽ��� �ҷ���
    
    public static void LoadDataCoffee()
    {
        // saledata.txt ������ ���
        string filePath = Application.dataPath + "/Data/Coffeesaledata.txt";

        // ������ �� �پ� �о���̱� ���� StreamReader ��ü ����
        StreamReader reader = new StreamReader(filePath);

        // ���� �ʱ�ȭ
        totalsaledailywater = 0;
        totalsalemonthwater = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
        netdata.Split(",");
        // ���� ������ �� �پ� �о���̸鼭 ó��
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // �� �� �о����

            // �� ���� ��� ����
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // ���� ������ ������ �߸��� ��� ���� ��� �� ����
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // �� ���� �������� �и��ؼ� ������ ���� ������ ����
            string date = data[0];

            // ���� ���� ó��
            if (date.Contains("��")) // �� �̸��� �ִ� ���
            {
                int monthIndex = date.IndexOf("��");
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
            //�Ϻ� ����ó��
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" ������ ���
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // �迭 ������ ����� ��� ����ó��
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailywater += sale;

                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // ��ȿ���� ���� ��¥�� �α׷� ���
                }
            }
            else // �߸��� ������ ���
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader ��ü �ݱ�
        reader.Close();

    }
    
    
    //public static void LoadDataCoffee()
    //{
    //    // ���� �ʱ�ȭ
    //    totalsaledailywater = 0;
    //    totalsalemonthwater = 0;
    //    dailyname = new string[7];
    //    monthname = new string[12];
    //    dailysale = new int[7];
    //    monthsale = new int[12];

    //    // netdata�� ��ǥ�� �и��ؼ� ������ ���� ó��
    //    string[] dataEntries = netdata.Split(',');

    //    foreach (string entry in dataEntries)
    //    {
    //        // �� ĭ�� ��� ����
    //        if (string.IsNullOrEmpty(entry))
    //        {
    //            continue;
    //        }

    //        string[] data = entry.Split(' ');

    //        // ���� ������ ������ �߸��� ��� ���� ��� �� ����
    //        if (data.Length != 2 || !int.TryParse(data[1], out int sale))
    //        {
    //            Debug.LogError("Invalid data format: " + entry);
    //            continue;
    //        }

    //        // �� ���� �������� �и��ؼ� ������ ���� ������ ����
    //        string date = data[0];

    //        // ���� ���� ó��
    //        if (date.Contains("��")) // �� �̸��� �ִ� ���
    //        {
    //            int monthIndex = date.IndexOf("��");
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
    //        //�Ϻ� ����ó��
    //        else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" ������ ���
    //        {
    //            int day = datetime.Day;
    //            if (day > 0 && day <= dailyname.Length) // �迭 ������ ����� ��� ����ó��
    //            {
    //                dailyname[day - 1] = date;
    //                dailysale[day - 1] = sale;
    //                totalsaledailywater += sale;
    //            }
    //            else
    //            {
    //                Debug.LogError("Invalid date: " + date); // ��ȿ���� ���� ��¥�� �α׷� ���
    //            }
    //        }
    //        else // �߸��� ������ ���
    //        {
    //            Debug.LogError("Invalid day format: " + date);
    //        }
    //    }
    //}

    public static void LoadDataWaterdrink()
    {
        // saledata.txt ������ ���
        string filePath = Application.dataPath + "/Data/Waterdrinksaledata.txt";

        // ������ �� �پ� �о���̱� ���� StreamReader ��ü ����
        StreamReader reader = new StreamReader(filePath);

        // ���� �ʱ�ȭ
        totalsaledailywater = 0;
        totalsalemonthwater = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
      //  netdata.Split(",");
        // ���� ������ �� �پ� �о���̸鼭 ó��
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // �� �� �о����

            // �� ���� ��� ����
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // ���� ������ ������ �߸��� ��� ���� ��� �� ����
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // �� ���� �������� �и��ؼ� ������ ���� ������ ����
            string date = data[0];

            // ���� ���� ó��
            if (date.Contains("��")) // �� �̸��� �ִ� ���
            {
                int monthIndex = date.IndexOf("��");
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
            //�Ϻ� ����ó��
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" ������ ���
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // �迭 ������ ����� ��� ����ó��
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailywater += sale;

                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // ��ȿ���� ���� ��¥�� �α׷� ���
                }
            }
            else // �߸��� ������ ���
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader ��ü �ݱ�
        reader.Close();

    }
    public static void LoadDataHighcoffee()
    {
        // saledata.txt ������ ���
        string filePath = Application.dataPath + "/Data/Highcoffeesaledata.txt";

        // ������ �� �پ� �о���̱� ���� StreamReader ��ü ����
        StreamReader reader = new StreamReader(filePath);

        // ���� �ʱ�ȭ
        totalsaledailywater = 0;
        totalsalemonthwater = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
      //  netdata.Split(",");
        // ���� ������ �� �پ� �о���̸鼭 ó��
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // �� �� �о����

            // �� ���� ��� ����
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // ���� ������ ������ �߸��� ��� ���� ��� �� ����
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // �� ���� �������� �и��ؼ� ������ ���� ������ ����
            string date = data[0];

            // ���� ���� ó��
            if (date.Contains("��")) // �� �̸��� �ִ� ���
            {
                int monthIndex = date.IndexOf("��");
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
            //�Ϻ� ����ó��
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" ������ ���
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // �迭 ������ ����� ��� ����ó��
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailywater += sale;

                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // ��ȿ���� ���� ��¥�� �α׷� ���
                }
            }
            else // �߸��� ������ ���
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader ��ü �ݱ�
        reader.Close();

    }
    public static void LoadDataTansan()
    {
        // saledata.txt ������ ���
        string filePath = Application.dataPath + "/Data/Tansansaledata.txt";

        // ������ �� �پ� �о���̱� ���� StreamReader ��ü ����
        StreamReader reader = new StreamReader(filePath);

        // ���� �ʱ�ȭ
        totalsaledailywater = 0;
        totalsalemonthwater = 0;
        dailyname = new string[7];
        monthname = new string[12];
        dailysale = new int[7];
        monthsale = new int[12];
     //   netdata.Split(",");
        // ���� ������ �� �پ� �о���̸鼭 ó��
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // �� �� �о����

            // �� ���� ��� ����
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] data = line.Split(' ');

            // ���� ������ ������ �߸��� ��� ���� ��� �� ����
            if (data.Length != 2 || !int.TryParse(data[1], out int sale))
            {
                Debug.LogError("Invalid data format: " + line);
                continue;
            }

            // �� ���� �������� �и��ؼ� ������ ���� ������ ����
            string date = data[0];

            // ���� ���� ó��
            if (date.Contains("��")) // �� �̸��� �ִ� ���
            {
                int monthIndex = date.IndexOf("��");
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
            //�Ϻ� ����ó��
            else if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime)) // "yyyy-MM-dd" ������ ���
            {
                int day = datetime.Day;
                if (day > 0 && day <= dailyname.Length) // �迭 ������ ����� ��� ����ó��
                {
                    dailyname[day - 1] = date;
                    dailysale[day - 1] = sale;
                    totalsaledailywater += sale;

                }
                else
                {
                    Debug.LogError("Invalid date: " + date); // ��ȿ���� ���� ��¥�� �α׷� ���
                }
            }
            else // �߸��� ������ ���
            {
                Debug.LogError("Invalid day format: " + date);
            }
        }

        // StreamReader ��ü �ݱ�
        reader.Close();

    }
}


