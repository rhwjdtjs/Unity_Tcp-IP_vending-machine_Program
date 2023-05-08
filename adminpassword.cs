using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class adminpassword : MonoBehaviour
{

    [SerializeField] private InputField theinputpassword;
    [SerializeField] private Button thestartbutton;
    [SerializeField] private Text correctpassword;
    [SerializeField] private Text incorrectpassword;
    void Start()
    {
        thestartbutton.gameObject.SetActive(false);
    }

    void Update()
    {
        PassWord.password = theinputpassword.text.ToString();
        //Debug.Log(PassWord.password);
    }
    public void afterpasswordOkButton()
    {

        if (PassWord.password.Length >= 8 && PassWord.password.Any(c => !Char.IsLetterOrDigit(c)) && PassWord.password.Any(c => Char.IsDigit(c)))
        {
            Debug.Log("��й�ȣ�� ��Ģ�� �½��ϴ�.");
            Debug.Log(PassWord.password);
            StartCoroutine(correctpasswordco());
        }
        else
        {
            Debug.Log("��й�ȣ�� 8�ڸ� �̻�, Ư������ �� ���ڰ� ���ԵǾ�� �մϴ�.");
            Debug.Log(PassWord.password);
            StartCoroutine(incorrectpasswordco());
        }


    }
    IEnumerator correctpasswordco()
    {
        incorrectpassword.gameObject.SetActive(false);
        correctpassword.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        correctpassword.gameObject.SetActive(false);
        theinputpassword.gameObject.SetActive(false);
        thestartbutton.gameObject.SetActive(true);
    }
    IEnumerator incorrectpasswordco()
    {
        correctpassword.gameObject.SetActive(false);
        incorrectpassword.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        incorrectpassword.gameObject.SetActive(false);
    }
}
