using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class adminpassword : MonoBehaviour
{

    [SerializeField] private InputField theinputpassword; //패스워드 입력 칸
    [SerializeField] private Button thestartbutton; //다음 씬으로 넘어가기위한 버튼
    [SerializeField] private Text correctpassword; //올바른 비번일때 나오는 텍스트
    [SerializeField] private Text incorrectpassword; //틀린 비번일때 나오는 텍스트
    void Start()
    {
        thestartbutton.gameObject.SetActive(false); //버튼 비활성화
    }

    void Update()
    {
        PassWord.password = theinputpassword.text.ToString(); //PassWord 의 맴버변수 password에 입력받은 비번값 대입
        //Debug.Log(PassWord.password);
    }
    public void afterpasswordOkButton()
    {

        if (PassWord.password.Length >= 8 && PassWord.password.Any(c => !Char.IsLetterOrDigit(c)) && PassWord.password.Any(c => Char.IsDigit(c))) //특수문자가 하나이 상 포함되어 있고
            //숫자가 하나 이상 있으며 8자 이상일때
        {
            Debug.Log("비밀번호가 규칙에 맞습니다.");
            Debug.Log(PassWord.password);
            StartCoroutine(correctpasswordco()); //함수 실행
        }
        else
        {
            Debug.Log("비밀번호는 8자리 이상, 특수문자 및 숫자가 포함되어야 합니다.");
            Debug.Log(PassWord.password);
            StartCoroutine(incorrectpasswordco()); //함수 실행
        }


    }
    IEnumerator correctpasswordco() //올바른 비밀번호 일때
    {
        incorrectpassword.gameObject.SetActive(false);
        correctpassword.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        correctpassword.gameObject.SetActive(false);
        theinputpassword.gameObject.SetActive(false);
        thestartbutton.gameObject.SetActive(true); //다음으로 넘어가기위한 버튼 활성화
    }
    IEnumerator incorrectpasswordco() //틀린 비밀번호 일때
    {
        correctpassword.gameObject.SetActive(false);
        incorrectpassword.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        incorrectpassword.gameObject.SetActive(false);
    }
}
